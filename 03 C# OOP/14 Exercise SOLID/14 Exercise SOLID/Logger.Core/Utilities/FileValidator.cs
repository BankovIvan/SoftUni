namespace Logger.Core.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public static class FileValidator
    {
        public static bool PathExists(string path)
        {
            return Directory.Exists(path);
        }
    }
}
