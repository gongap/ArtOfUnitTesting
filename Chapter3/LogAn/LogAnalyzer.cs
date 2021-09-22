using System;

namespace LogAn
{
    public class LogAnalyzer
    {
        private IWebService webService;
        private IEmailService emailService;

        public LogAnalyzer(IWebService webService, IEmailService emailService)
        {
            this.webService = webService;
            this.emailService = emailService;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                    // 在产品代码中写错误日志
                    webService.LogError(string.Format("Filename too short : {0}", fileName));
                }
                catch (Exception ex)
                {
                    emailService.SendEmail(new EmailInfo("someone@qq.com", "can't log", ex.Message));
                }
            }
        }
    }
}
