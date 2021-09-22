namespace LogAn.Tests.Unit.Fakes
{
    public class TestableLogAnalyzer : LogAnalyzerUsingFactoryMethod
    {
        public IExtensionManager manager;

        public TestableLogAnalyzer(IExtensionManager manager)
        {
            this.manager = manager;
        }

        protected override IExtensionManager GetManager()
        {
            return manager;
        }
    }
}
