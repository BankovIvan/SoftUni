namespace _01._Food_Finder
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<char>[] arrWords = new HashSet<char>[] {
                                            new HashSet<char>("pear".ToCharArray()),
                                            new HashSet<char>("flour".ToCharArray()),
                                            new HashSet<char>("pork".ToCharArray()),
                                            new HashSet<char>("olive".ToCharArray())
                                                            };

            int nCount = 0;

            Queue<char> queueVowels = new Queue<char>(Console.ReadLine().ToCharArray());
            Stack<char> stackConsonants = new Stack<char>(Console.ReadLine().ToCharArray());

            while (stackConsonants.Count > 0)
            {
                char cVowel = queueVowels.Dequeue();
                queueVowels.Enqueue(cVowel);
                char cConsonant = stackConsonants.Pop();

                foreach(var v in arrWords)
                {
                    if (v.Contains(cVowel))
                    {
                        v.Remove(cVowel);
                    }

                    if (v.Contains(cConsonant))
                    {
                        v.Remove(cConsonant);
                    }

                }

            }

            foreach (var v in arrWords)
            {
                if(v.Count == 0)
                {
                    nCount++;
                }
            }

            Console.WriteLine("Words found: {0}", nCount);
            if (arrWords[0].Count == 0) Console.WriteLine("pear");
            if (arrWords[1].Count == 0) Console.WriteLine("flour");
            if (arrWords[2].Count == 0) Console.WriteLine("pork");
            if (arrWords[3].Count == 0) Console.WriteLine("olive");

        }

    }
}
