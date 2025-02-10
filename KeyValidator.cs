using System;

namespace LibrarySystem.Utilities
{
    public static class KeyValidator
    {
        public static bool ValidateKey(string key)
        {
            return !string.IsNullOrWhiteSpace(key);
        }
    }
}
