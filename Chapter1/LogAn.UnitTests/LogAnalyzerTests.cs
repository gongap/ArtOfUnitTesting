using System;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzer analyzer = MakeAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");

            Assert.False(result);
        }

        [Test]
        public void IsValidFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithgoodextension.slf");

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsValidFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithgoodextension.SLF");

            Assert.AreEqual(true, result);
        }

        [TestCase("filewithgoodextension.slf")]
        [TestCase("filewithgoodextension.SLF")]
        public void IsValidFileName_ValidExtensions_ReturnsTrue(string fileName)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName(fileName);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsValidFileName_EmptyName_Throws()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            var ex = Assert.Catch<Exception>(() => analyzer.IsValidLogFileName(string.Empty));

            StringAssert.Contains("filename has to be provided", ex.Message);
        }

        [TestCase("badfile.foo", false)]
        [TestCase("goodfile.slf", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string fileName, bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            analyzer.IsValidLogFileName(fileName);

            Assert.AreEqual(expected, analyzer.WasLastFileNameValid);
        }

        [Test]
        [Ignore("there is a problem with this test!")]
        public void IsValidFileName_ValidFile_ReturnsTrue()
        {
            LogAnalyzer analyzer = MakeAnalyzer();
            // ToDo...
        }

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
