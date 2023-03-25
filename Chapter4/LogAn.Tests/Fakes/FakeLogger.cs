namespace LogAn.UnitTests.Fakes
{
    public class FakeLogger : ILogger
    {
        public string LastError;
        public void LogError(string message)
        {
            LastError = message;
        }
    }
}
