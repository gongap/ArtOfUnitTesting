using System;
using NSubstitute;
using Xunit;

namespace LogAn.UnitTests
{
    //NSub������ʹ��
    public partial class LogAnalyzerTests
    {
       [Fact]
        public void Analyze_TooShortFileName_CallLogger()
        {
            // ����ģ��������ڲ��Խ�β�Ķ���
            ILogger logger = Substitute.For<ILogger>();
            LogAnalyzer analyzer = new LogAnalyzer(logger);
            analyzer.MinNameLength = 6;

            analyzer.Analyze("a.txt");

            // ʹ��NSub API����Ԥ���ַ���
            logger.Received().LogError("Filename too short : a.txt");
        }

        // ģ��һ������ֵ
       [Fact]
        public void Returns_ByDefault_WorksForHardCodeArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            // ǿ�Ʒ������ؼ�ֵ
            fakeRules.IsValidLogFileName("strict.txt").Returns(true);

            Assert.True(fakeRules.IsValidLogFileName("strict.txt"));
        }

        // ʹ�ò���ƥ����
       [Fact]
        public void Returns_ByDefault_WorksForAnyArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            // ǿ�Ʒ������ؼ�ֵ
            fakeRules.IsValidLogFileName(Arg.Any<string>()).Returns(true);

            Assert.True(fakeRules.IsValidLogFileName("anything.txt"));
        }

        // ģ��һ���쳣
       [Fact]
        public void Returns_ArgAny_Throws()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.When(x => x.IsValidLogFileName(Arg.Any<string>())).
                Do(context => { throw new Exception("fake exception"); });

            Assert.Throws<Exception>(() => fakeRules.IsValidLogFileName("anything"));
        }

        // ͬʱʹ��ģ�����ʹ��
       [Fact]
        public void Analyze_LoggerThrows_CallsWebService()
        {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();

            // ��������ʲô���׳��쳣
            stubLogger.When(logger => logger.LogError(Arg.Any<string>()))
                .Do(info => { throw new Exception("fake exception"); });

            var analyzer = new LogAnalyzerNew(stubLogger, mockWebService);
            analyzer.MinNameLength = 10;
            analyzer.Analyze("short.txt");

            //��֤�ڲ����е�����Web Service��ģ����󣬵��ò����ַ������� "fake exception"
            mockWebService.Received().Write(Arg.Is<string>(s => s.Contains("fake exception")));
        }
    }
}