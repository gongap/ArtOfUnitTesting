namespace LogAn
{
    public interface IExtensionManager
    {
        bool WasLastFileNameValid { get; set; }

        bool IsValid(string fileName);
    }
}
