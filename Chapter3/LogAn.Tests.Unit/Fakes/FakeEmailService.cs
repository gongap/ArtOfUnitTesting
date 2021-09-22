namespace LogAn.Tests.Unit.Fakes
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
