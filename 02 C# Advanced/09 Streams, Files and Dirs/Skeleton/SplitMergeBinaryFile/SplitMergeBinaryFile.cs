namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {

            using (FileStream fsSourceFile = new FileStream(sourceFilePath, FileMode.Open))
            {
                byte[] buffer = new byte[fsSourceFile.Length];

                int bytesRead = fsSourceFile.Read(buffer);
                int bytesWrite = (int)((fsSourceFile.Length / 2) + (fsSourceFile.Length % 2));

                using (FileStream fsPartOneFile = new FileStream(partOneFilePath, FileMode.Create))
                {
                    fsPartOneFile.Write(buffer, 0, bytesWrite);
                }

                using (FileStream fsPartTwoFile = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    fsPartTwoFile.Write(buffer, bytesWrite, (int)(fsSourceFile.Length / 2));
                }

            }

        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream fsJoinedFile = new FileStream(joinedFilePath, FileMode.Create))
            {
                using (FileStream fsPartOneFile = new FileStream(partOneFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[fsPartOneFile.Length];

                    int bytesRead = fsPartOneFile.Read(buffer);
                    fsJoinedFile.Write(buffer);
                }

                using (FileStream fsPartTwoFile = new FileStream(partTwoFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[fsPartTwoFile.Length];

                    int bytesRead = fsPartTwoFile.Read(buffer);
                    fsJoinedFile.Write(buffer);
                }

            }


        }
    }
}