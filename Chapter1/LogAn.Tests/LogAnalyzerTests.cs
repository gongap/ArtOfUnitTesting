using System;
using Xunit;

namespace LogAn.Tests
{
    public class LogAnalyzerTests
    {
        [Fact]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzer analyzer = MakeAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");

            Assert.False(result);
        }

        [Fact]
        public void IsValidFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithgoodextension.slf");

            Assert.Equal(true, result);
        }

        [Fact]
        public void IsValidFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithgoodextension.SLF");

            Assert.Equal(true, result);
        }

        [Theory]
        [InlineData("filewithgoodextension.slf")]
        [InlineData("filewithgoodextension.SLF")]
        public void IsValidFileName_ValidExtensions_ReturnsTrue(string fileName)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName(fileName);

            Assert.Equal(true, result);
        }

        [Fact]
        public void IsValidFileName_EmptyName_Throws()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            var ex = Assert.Throws<ArgumentException>(() => analyzer.IsValidLogFileName(string.Empty));

            Assert.Contains("filename has to be provided", ex.Message);
        }

        [Theory]
        [InlineData("badfile.foo", false)]
        [InlineData("goodfile.slf", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string fileName, bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            analyzer.IsValidLogFileName(fileName);

            Assert.Equal(expected, analyzer.WasLastFileNameValid);
        }

        //[Fact(Skip = "there is a problem with this test!")]
        //public void IsValidFileName_ValidFile_ReturnsTrue()
        //{
        //    LogAnalyzer analyzer = MakeAnalyzer();
        //    // ToDo...
        //}

        /// <summary>
        /// 工厂方法初始化 LogAnalyzer 
        /// 既节省编写代码的时间，又使每个测试内的代码更简洁易读
        /// 同时保证 LogAnalyzer 总是用同样的方式初始化
        /// </summary>
        private static LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }
    }
}
