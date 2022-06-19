using System;
using System.Collections.Generic;

namespace _10_SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lstLessons; // = new List<int>();
            string[] sCommand;
            int i;

            //lstLessons = new List<string>(Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries));

            lstLessons = new List<string>(Array.ConvertAll(
                        Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries),
                        new Converter<string, string>(s => s.Trim())
                        ));


            sCommand = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
            i = 0;

            while(sCommand[0] != "course start")
            {

                switch (sCommand[0])
                {
                    case "Add":
                        AddLesson(lstLessons, sCommand[1]);
                        break;

                    case "Insert":
                        InsertLesson(lstLessons, sCommand[1], int.Parse(sCommand[2]));
                        break;

                    case "Remove":
                        RemoveLesson(lstLessons, sCommand[1]);
                        break;

                    case "Swap":
                        SwapLesson(lstLessons, sCommand[1], sCommand[2]);
                        break;

                    case "Exercise":
                        ExerciseLesson(lstLessons, sCommand[1]);
                        break;

                    default:

                        break;
                }

                sCommand = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
            }

            for(i = 0; i < lstLessons.Count; i++)
            {
                Console.WriteLine("{0}.{1}", i+1, lstLessons[i]);
            }
        }

        private static void ExerciseLesson(List<string> lstLessons, string sLessonTitle)
        {
            int nIndex;

            if (!lstLessons.Contains(sLessonTitle))
            {
                lstLessons.Add(sLessonTitle);
                lstLessons.Add(sLessonTitle + "-Exercise");
            }
            else
            {
                nIndex = lstLessons.IndexOf(sLessonTitle);
                sLessonTitle = sLessonTitle + "-Exercise";
                if (!lstLessons.Contains(sLessonTitle))
                {
                    lstLessons.Insert(nIndex+1, sLessonTitle);
                }
            }
        }

        private static void SwapLesson(List<string> lstLessons, string sLessonTitle1, string sLessonTitle2)
        {
            int index1, index2;
            string sSwap, sLessonTitle1Ex, sLessonTitle2Ex;

            if (lstLessons.Contains(sLessonTitle1) && lstLessons.Contains(sLessonTitle2))
            {
                index1 = lstLessons.IndexOf(sLessonTitle1);
                index2 = lstLessons.IndexOf(sLessonTitle2);
                sSwap = lstLessons[index1];
                lstLessons[index1] = lstLessons[index2];
                lstLessons[index2] = sSwap;

                sLessonTitle1Ex = sLessonTitle1 + "-Exercise";
                sLessonTitle2Ex = sLessonTitle2 + "-Exercise";
                /* if (lstLessons.Contains(sLessonTitle1Ex) && lstLessons.Contains(sLessonTitle2Ex))
                {
                    index1 = lstLessons.IndexOf(sLessonTitle1Ex);
                    index2 = lstLessons.IndexOf(sLessonTitle2Ex);
                    sSwap = lstLessons[index1];
                    lstLessons[index1] = lstLessons[index2];
                    lstLessons[index2] = sSwap;
                }
                else */ if (lstLessons.Contains(sLessonTitle1Ex))
                {
                    lstLessons.Remove(sLessonTitle1Ex);
                    index2 = lstLessons.IndexOf(sLessonTitle1);
                    lstLessons.Insert(index2 + 1, sLessonTitle1Ex);
                }
                /* else */ if (lstLessons.Contains(sLessonTitle2Ex))
                {
                    lstLessons.Remove(sLessonTitle2Ex);
                    index1 = lstLessons.IndexOf(sLessonTitle2);
                    lstLessons.Insert(index1 + 1, sLessonTitle2Ex);
                }
            }
        }

        private static void RemoveLesson(List<string> lstLessons, string sLessonTitle)
        {
            if (lstLessons.Contains(sLessonTitle))
            {
                lstLessons.Remove(sLessonTitle);

                sLessonTitle = sLessonTitle + "-Exercise";
                if (lstLessons.Contains(sLessonTitle))
                {
                    lstLessons.Remove(sLessonTitle);
                }
            }
        }

        private static void InsertLesson(List<string> lstLessons, string sLessonTitle, int nIndex)
        {
            if (!lstLessons.Contains(sLessonTitle))
            {
                lstLessons.Insert(nIndex, sLessonTitle);
            }
        }

        private static void AddLesson(List<string> lstLessons, string sLessonTitle)
        {
            if (!lstLessons.Contains(sLessonTitle))
            {
                lstLessons.Add(sLessonTitle);
            }
        }
    }
}
