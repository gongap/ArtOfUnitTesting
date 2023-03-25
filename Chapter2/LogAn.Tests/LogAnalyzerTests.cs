using LogAn.Tests.Fakes;
using Xunit;

namespace LogAn.Tests
{
    public partial class LogAnalyzerTests
    {
        #region 构造函数注入
       [Fact]
        public void IsValidFileName_NameSupportExtension_ReturnsTrue()
        {
            // 准备一个返回true的存根
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillBeValid = true;
            // 通过构造器注入传入存根
            LogAnalyzer analyzer = new LogAnalyzer(myFakeManager);
            bool result = analyzer.IsValidLogFileName("shortname.ext");

            Assert.Equal(true, result);
        }

        #endregion

        #region 属性注入
       [Fact]
        public void IsValidFileName_SupportExtension_ReturnsTrue()
        {
            // 设置要使用的存根，确保其返回true
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillBeValid = true;
            // 创建analyzer，注入存根
            LogAnalyzer log = new LogAnalyzer();
            log.ExtensionManager = myFakeManager;
            bool result = log.IsValidLogFileName("testfilename.ext");

            Assert.Equal(true, result);
        }

        #endregion

        #region 在方法调用之前注入
        /// <summary>
        /// 在测试运行时设置工厂类返回一个存根
        /// </summary>
       [Fact]
        public void IsValidFileName_SupportedExtension_ReturnsTrue()
        {
            // 设置要使用的存根，确保其返回true
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillBeValid = true;
            // 通过工厂类注入存根
            ExtensionManagerFactory.SetManager(myFakeManager);
            // 创建analyzer，注入存根
            LogAnalyzer log = new LogAnalyzer();
            bool result = log.IsValidLogFileName("testfilename.ext");

            Assert.Equal(true, result);
        }

       [Fact]
        public void OverrideTest()
        {
            FakeExtensionManager stub = new FakeExtensionManager();
            stub.WillBeValid = true;
            // 创建被测试类的派生类的实例
            TestableLogAnalyzer logan = new TestableLogAnalyzer(stub);
            bool result = logan.IsValidLogFileName("stubfile.ext");

            Assert.Equal(true, result);
        }
        #endregion
    }
}
