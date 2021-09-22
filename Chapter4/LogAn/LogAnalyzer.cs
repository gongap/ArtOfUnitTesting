namespace LogAn
{
    public class LogAnalyzer
    {
        private ILogger log;
        public LogAnalyzer(ILogger log)
        {
            this.log = log;
        }

        public int MinNameLength
        {
            get; set;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < MinNameLength)
            {
                log.LogError(string.Format("Filename too short : {0}", fileName));
            }
        }
    }
}
