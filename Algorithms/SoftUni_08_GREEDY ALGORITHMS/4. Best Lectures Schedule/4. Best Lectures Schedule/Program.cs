using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string[] s;
        int i;
        int n = 0;
        List<Lecture> lecturesGiven = new List<Lecture>();

        n = int.Parse(Console.ReadLine().Split().Last());

        for (i = 0; i < n; i++)
        {
            s = Console.ReadLine().Split(new Char[] { ' ', ':', '-' }).Where(x => x != "").ToArray();
            lecturesGiven.Add(new Lecture(int.Parse(s[1]), int.Parse(s[2]), s[0]));
        }

        if (n > 0 && lecturesGiven.Count == n) LecturesSchedule(lecturesGiven);
        else return;

        Console.WriteLine("Lectures ({0}):", lecturesGiven.Count);
        foreach (var item in lecturesGiven)
        {
            Console.WriteLine(item.ToString());
        }

        return;
    }

    private static void LecturesSchedule(List<Lecture> lecturesGiven)
    {
        int i = 1;

        lecturesGiven.Sort();

        while(i < lecturesGiven.Count)
        {
            if(lecturesGiven[i].start < lecturesGiven[i-1].end) lecturesGiven.RemoveAt(i);
            else i++;

        }
    }
}

class Lecture : IComparable<Lecture>
{
    public int start;
    public int end;
    public string desc;

    
    public Lecture(int start, int end, string desc)
    {
        this.start = start;
        this.end = end;
        this.desc = desc;
    }

    public int CompareTo(Lecture other)
    {
        return this.end.CompareTo(other.end);
    }

    public override string ToString()
    {
        string s = "";

        s = this.start + "-" + this.end + " -> " + this.desc;

        return s;
    }
}