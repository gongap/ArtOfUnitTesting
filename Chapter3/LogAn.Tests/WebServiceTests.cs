using System;
using LogAn.Tests.Fakes;
using Xunit;

namespace LogAn.Tests
{
    
    public class WebServiceTests
    {
       [Fact]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            FakeWebService mockService = new FakeWebService();
            LogAnalyzer log = new LogAnalyzer(mockService, null);

            string tooShortFileName = "abc.ext";
            log.Analyze(tooShortFileName);
            // 使用模拟对象进行断言
            Assert.Contains("Filename too short : abc.ext", mockService.LastError);
        }

       [Fact]
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
            Assert.Equal(expectedEmail, mockEmail.email);
        }
    }
}
