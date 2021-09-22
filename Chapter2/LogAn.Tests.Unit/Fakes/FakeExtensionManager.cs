using System;

namespace LogAn.Tests.Unit.Fakes
{
    // 定义一个最简单的存根
    internal class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid = false;

        public bool WasLastFileNameValid
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsValid(string fileName)
        {
            return WillBeValid;
        }
    }
}
