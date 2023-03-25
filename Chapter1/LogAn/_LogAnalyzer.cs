using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    /// <summary>
    /// 日志分析器
    /// </summary>
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }

        /// <summary>
        /// 验证是否为有效的日志文件名
        /// </summary>
        public bool IsValidLogFileName(string fileName)
        {
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
}
