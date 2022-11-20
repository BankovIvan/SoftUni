using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            File fileStream = new File("FILE NAME", 100, 25);
            Music musicStream = new Music("MUSIC ARTIST", "MUSIC ALBUM", 200, 100);
            NorthStream northStream = new NorthStream("Kremlin", 100, 100);

            StreamProgressInfo progressFile = new StreamProgressInfo(fileStream);
            StreamProgressInfo progressMusic = new StreamProgressInfo(musicStream);
            StreamProgressInfo progressGas = new StreamProgressInfo(northStream);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("File Progress:{0}", progressFile.CalculateCurrentPercent());
            Console.WriteLine("Music Progress:{0}", progressMusic.CalculateCurrentPercent());
            Console.WriteLine("Gas sent:{0}", progressGas.CalculateCurrentPercent());
            Console.ResetColor();

        }
    }
}
