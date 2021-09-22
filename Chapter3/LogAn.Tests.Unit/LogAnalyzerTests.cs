using System;
using LogAn.Tests.Unit.Fakes;
using NUnit.Framework;

namespace LogAn.Tests.Unit
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            FakeWebService stubService = new FakeWebService();
            stubService.ToThrow = new Exception("fake exception");
            FakeEmailService mockEmail = new FakeEmailService();

            LogAnalyzer log = new LogAnalyzer(stubService, mockEmail);
            string tooShortFileName = "abc.ext";

            log.Analyze(tooShortFileName);

            // 创建预期对象
            EmailInfo expectedEmail = new EmailInfo("someone@qq.com", "can't log", "fake exception");
            // 用预期对象同时断言所有属性
            Assert.AreEqual(expectedEmail, mockEmail.email);
        }
    }
}
