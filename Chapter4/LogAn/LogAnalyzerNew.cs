using System;

namespace LogAn
{
    public class LogAnalyzerNew
    {
        private ILogger _logger;
        private IWebService _webService;

        public LogAnalyzerNew(ILogger logger, IWebService webService)
        {
            _logger = logger;
            _webService = webService;
        }

        public int MinNameLength
        {
            get; set;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < MinNameLength)
            {
                try
                {
                    _logger.LogError(string.Format("Filename too short : {0}", fileName));
                }
                catch (Exception ex)
                {
                    _webService.Write("Error From Logger : " + ex.Message);
                }
            }
        }
    }
}
