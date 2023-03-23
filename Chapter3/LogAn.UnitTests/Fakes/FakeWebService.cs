using System;

namespace LogAn.UnitTests.Fakes
{
    public class FakeWebService : IWebService
    {
        public Exception ToThrow;

        public string LastError;

        public void LogError(string message)
        {
            LastError = message;
            if (ToThrow != null)
            {
                throw ToThrow;
            }
        }
    }
}
