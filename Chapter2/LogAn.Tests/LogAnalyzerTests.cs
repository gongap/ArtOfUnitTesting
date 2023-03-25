using LogAn.Tests.Fakes;
using Xunit;

namespace LogAn.Tests
{
    public partial class LogAnalyzerTests
    {
        #region ���캯��ע��
       [Fact]
        public void IsValidFileName_NameSupportExtension_ReturnsTrue()
        {
            // ׼��һ������true�Ĵ��
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillBeValid = true;
            // ͨ��������ע�봫����
            LogAnalyzer analyzer = new LogAnalyzer(myFakeManager);
            bool result = analyzer.IsValidLogFileName("shortname.ext");

            Assert.Equal(true, result);
        }

        #endregion

        #region ����ע��
       [Fact]
        public void IsValidFileName_SupportExtension_ReturnsTrue()
        {
            // ����Ҫʹ�õĴ����ȷ���䷵��true
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillBeValid = true;
            // ����analyzer��ע����
            LogAnalyzer log = new LogAnalyzer();
            log.ExtensionManager = myFakeManager;
            bool result = log.IsValidLogFileName("testfilename.ext");

            Assert.Equal(true, result);
        }

        #endregion

        #region �ڷ�������֮ǰע��
        /// <summary>
        /// �ڲ�������ʱ���ù����෵��һ�����
        /// </summary>
       [Fact]
        public void IsValidFileName_SupportedExtension_ReturnsTrue()
        {
            // ����Ҫʹ�õĴ����ȷ���䷵��true
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillBeValid = true;
            // ͨ��������ע����
            ExtensionManagerFactory.SetManager(myFakeManager);
            // ����analyzer��ע����
            LogAnalyzer log = new LogAnalyzer();
            bool result = log.IsValidLogFileName("testfilename.ext");

            Assert.Equal(true, result);
        }

       [Fact]
        public void OverrideTest()
        {
            FakeExtensionManager stub = new FakeExtensionManager();
            stub.WillBeValid = true;
            // ��������������������ʵ��
            TestableLogAnalyzer logan = new TestableLogAnalyzer(stub);
            bool result = logan.IsValidLogFileName("stubfile.ext");

            Assert.Equal(true, result);
        }
        #endregion
    }
}
