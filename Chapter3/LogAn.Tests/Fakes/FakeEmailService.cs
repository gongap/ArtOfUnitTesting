namespace LogAn.Tests.Fakes
{
    public class FakeEmailService : IEmailService
    {
        public EmailInfo email = null;

        public void SendEmail(EmailInfo emailInfo)
        {
            this.email = emailInfo;
        }
    }
}
