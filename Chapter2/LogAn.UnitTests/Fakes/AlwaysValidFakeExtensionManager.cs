namespace LogAn.UnitTests.Fakes
{
    ///<summary>
    /// 始终有效的扩展管理器存根
    /// </summary>
    public class AlwaysValidFakeExtensionManager : IExtensionManager
    {
        public bool WasLastFileNameValid { get; set; }

        public bool IsValid(string fileName)
        {
            return true;
        }
    }
}