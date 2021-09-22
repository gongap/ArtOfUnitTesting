using System;

namespace LogAn.Tests.Unit.Fakes
{
    public class FakeWebService : IWebService
    {
        public Exception ToThrow;

        public void LogError(string message)
        {
            if (ToThrow != null)
            {
                throw ToThrow;
            }
        }
    }
}
