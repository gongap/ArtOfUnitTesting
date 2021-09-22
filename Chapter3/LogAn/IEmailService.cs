namespace LogAn
{
    public interface IEmailService
    {
        void SendEmail(EmailInfo emailInfo);
    }

    public class EmailInfo
    {
        public string Body;
        public string To;
        public string Subject;

        public EmailInfo(string to, string subject, string body)
        {
            this.To = to;
            this.Subject = subject;
            this.Body = body;
        }

        public override bool Equals(object obj)
        {
            EmailInfo compared = obj as EmailInfo;

            return To == compared.To && Subject == compared.Subject
                                     && Body == compared.Body;
        }
    }
}
