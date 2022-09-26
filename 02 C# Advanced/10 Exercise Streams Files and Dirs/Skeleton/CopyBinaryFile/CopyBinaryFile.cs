namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
            {
                using(FileStream fsOutput = new FileStream(outputFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[fsInput.Length];
                    fsInput.Read(buffer, 0, buffer.Length);
                    fsOutput.Write(buffer, 0, buffer.Length);
                }
            }

        }
    }
}
