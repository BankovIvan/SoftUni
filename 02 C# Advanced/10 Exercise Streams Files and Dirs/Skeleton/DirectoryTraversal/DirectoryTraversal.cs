namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string ret = "";
            DirectoryInfo dirInfo = new DirectoryInfo(inputFolderPath);
            FileInfo[] fInfo = dirInfo.GetFiles("*", SearchOption.TopDirectoryOnly);

            Dictionary<string, List<FileInfo>> dicData = new Dictionary<string, List<FileInfo>>();

            foreach(var v in fInfo)
            {
                if (!dicData.ContainsKey(v.Extension))
                {
                    dicData.Add(v.Extension, new List<FileInfo>());
                }
                dicData[v.Extension].Add(v);
            }

            foreach(var v1 in dicData.OrderByDescending(x => x.Value.Count).ThenBy(y => y.Key))
            {
                ret = ret + v1.Key + "\n";
                foreach(var v2 in v1.Value.OrderBy(z => z.Length))
                {
                    ret = ret + v2.Name + " - " + v2.Length / 1024.0 + "kb\n";
                }
            }

            return ret;
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            const string DESKTOP_PATH = "C:/Users/Public/Desktop/";
            File.WriteAllText(DESKTOP_PATH + reportFileName, textContent);
        }
    }
}
