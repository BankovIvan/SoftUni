//namespace ExtractSpecialBytes
namespace ExtractBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    //public class ExtractSpecialBytes
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            HashSet<byte> setSpecial = new HashSet<byte>();

            using (StreamReader smBytes = new StreamReader(bytesFilePath))
            {
                string sData;

                while((sData = smBytes.ReadLine()) != null)
                {
                    setSpecial.Add(byte.Parse(sData));
                }
            }

            using (FileStream fsBinaryFile = new FileStream(binaryFilePath, FileMode.Open))
            {
                using (FileStream fsOutput = new FileStream(outputPath, FileMode.Create))
                {
                    byte[] btData = new byte[4096];

                    while (true)
                    {
                        int bytesRead = fsBinaryFile.Read(btData);
                        if (bytesRead == 0)
                        {
                            break;
                        }

                        for (int i = 0; i < bytesRead; i++)
                        {
                            if (setSpecial.Contains(btData[i]))
                            {
                                fsOutput.Write(btData, i, 1);
                            }
                        }
                    }
                }

            }

        }
    }
}
