namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            //https://stackoverflow.com/questions/58744/copy-the-entire-contents-of-a-directory-in-c-sharp

            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(inputPath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(inputPath, outputPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(inputPath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(inputPath, outputPath), true);
            }

        }
    }
}
