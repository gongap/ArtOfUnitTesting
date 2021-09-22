namespace LogAn
{
    public class LogAnalyzerUsingFactoryMethod
    {
        public bool IsValidLogFileName(string fileName)
        {
            // use virtual method
            return GetManager().IsValid(fileName);
        }

        protected virtual IExtensionManager GetManager()
        {
            // hard code
            return new FileExtensionManager();
        }
    }
}
