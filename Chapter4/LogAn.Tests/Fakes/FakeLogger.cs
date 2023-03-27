namespace LogAn.Tests.Fakes
{
    /// <summary>
    ///  手写的伪对象FakeLogger
    /// </summary>
    /// <seealso cref="LogAn.ILogger" />
    public class FakeLogger : ILogger
    {
        public string LastError;
        public void LogError(string message)
        {
            LastError = message;
        }
    }
}
