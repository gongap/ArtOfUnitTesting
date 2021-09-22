using System.IO;

namespace LogAn
{
    public class LogAnalyzer
    {
        // 允许通过属性设置依赖项
        public IExtensionManager ExtensionManager { get; set; }

        public LogAnalyzer(IExtensionManager manager)
        {
            ExtensionManager = manager;
        }

        public LogAnalyzer()
        {
            ExtensionManager = ExtensionManagerFactory.Create();
        }


        public bool IsValidLogFileName(string fileName)
        {
            return ExtensionManager.IsValid(fileName) && Path.GetFileNameWithoutExtension(fileName).Length > 5;
        }
    }
}
