using System;

namespace LogAn
{
    public class FileExtensionManager : IExtensionManager
    {
        public bool WasLastFileNameValid { get; set; }

        public bool IsValid(string fileName)
        {
            // 读取文件
            // 读取配置文件
            // 如果配置文件说支持这个扩展名，则返回true
            // 改变系统状态
            WasLastFileNameValid = false;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("filename has to be provided");
            }

            if (!fileName.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            // 改变系统状态
            WasLastFileNameValid = true;

            return true;
        }
    }
}
