using System;
using NSubstitute;
using Xunit;

namespace LogAn.Tests
{
    public partial class LogAnalyzerTests
    {
        [Fact]
        public void Analyze_TooShortFileName_CallLogger()
        {
            // 创建模拟对象，用于测试结尾的断言
            ILogger logger = Substitute.For<ILogger>();
            LogAnalyzer analyzer = new LogAnalyzer(logger);
            analyzer.MinNameLength = 6;

            analyzer.Analyze("a.txt");

            // 使用NSub API设置预期字符串
            logger.Received().LogError("Filename too short : a.txt");
        }

        // 模拟一个返回值
        [Fact]
        public void Returns_ByDefault_WorksForHardCodeArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            // 强制方法返回假值
            fakeRules.IsValidLogFileName("strict.txt").Returns(true);

            Assert.True(fakeRules.IsValidLogFileName("strict.txt"));
        }

        // 使用参数匹配器
       [Fact]
        public void Returns_ByDefault_WorksForAnyArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            // 强制方法返回假值
            fakeRules.IsValidLogFileName(Arg.Any<string>()).Returns(true);

            Assert.True(fakeRules.IsValidLogFileName("anything.txt"));
        }

        // 模拟一个异常
       [Fact]
        public void Returns_ArgAny_Throws()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.When(x => x.IsValidLogFileName(Arg.Any<string>())).
               Do(context => { throw new Exception("fake exception"); });

            Assert.Throws<Exception>(() => fakeRules.IsValidLogFileName("anything"));
        }

        // 同时使用模拟对象和存根
       [Fact]
        public void Analyze_LoggerThrows_CallsWebService()
        {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();

            // 无论输入什么都抛出异常
            stubLogger.When(logger => logger.LogError(Arg.Any<string>()))
                .Do(info => { throw new Exception("fake exception"); });

            var analyzer = new LogAnalyzerNew(stubLogger, mockWebService);
            analyzer.MinNameLength = 10;
            analyzer.Analyze("short.txt");

            //验证在测试中调用了Web Service的模拟对象，调用参数字符串包含 "fake exception"
            mockWebService.Received().Write(Arg.Is<string>(s => s.Contains("fake exception")));
        }

        //// 手写的伪对象FakeLogger
        //[Fact]
        //public void Analyze_TooShortFileName_CallLogger()
        //{
        //    var logger = new FakeLogger();
        //    LogAnalyzer analyzer = new LogAnalyzer(logger);
        //    analyzer.MinNameLength = 6;

        //    analyzer.Analyze("a.txt");

        //    Assert.Contains("too short", logger.LastError);
        //}
    }
}
