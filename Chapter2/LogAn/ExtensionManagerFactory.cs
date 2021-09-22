namespace LogAn
{
    public static class ExtensionManagerFactory
    {
        private static IExtensionManager customManger = null;

        public static IExtensionManager Create()
        {
            if (customManger == null)
            {
                customManger = new FileExtensionManager();
            }

            return customManger;
        }

        public static void SetManager(IExtensionManager manager)
        {
            customManger = manager;
        }
    }
}
