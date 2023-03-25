namespace LogAn
{
    /// <summary>
    /// 日志分析器
    /// </summary>
    public class LogAnalyzer
    {
        /// <summary>
        /// 验证是否为有效的日志文件名
        /// </summary>
        public bool IsValidLogFileName(string fileName)
        {
            if (fileName.EndsWith(".SLF"))
            {
                return false;
            }

            return true;
        }
    }
}
