using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

class Program
{
    public static List<Rectangle> edges;
    public static Dictionary<string, string> parents = new Dictionary<string, string>();
    public static Dictionary<string, int> heights = new Dictionary<string, int>();
    public static SortedSet<string> result = new SortedSet<string>();

    static void Main(string[] args)
    {
        int maxHeight;
        string maxElement = "";

        ReadGraph();

        //Calculate nesting heights
        maxHeight = EvaluateGraph();

        //Retreive result
        foreach (var item in heights)
        {
            if(item.Value == maxHeight)
            {
                if(maxElement == "")
                {
                    maxElement = item.Key;
                }
                else
                {
                    if(ComparePaths(maxElement, item.Key) > 0)
                    {
                        maxElement = item.Key;
                    }
                }

            }
        }

        //Print result;
        PrintPath(maxElement);
        Console.WriteLine();

        return;
    }

    private static int ComparePaths(string current, string next)
    {
        int ret = 0;
        string rootCurrent = parents[current];

        if (current == next)
        {
            //No need to check deeper;
            ret = 0;
        }
        else if (rootCurrent == current)
        {
            //root found
            ret = current.CompareTo(next);
        }
        else
        {
            ret = ComparePaths(rootCurrent, parents[next]);

            if(ret == 0)
            {
                ret = current.CompareTo(next);
            }
        }

        return ret;
    }

    private static void PrintPath(string parent)
    {
        string root = parents[parent];

        if(root == parent)
        {
            Console.Write(root);
            return;
        }
        else
        {
            PrintPath(root);
            Console.Write(" < " + parent);
        }
        return;
    }

    private static int EvaluateGraph()
    {
        int i, j;
        int maxHeight = 0, currentHeight = 0;

        edges.Sort();

        for (i = 0; i < edges.Count; i++)
        {
            parents.Add(edges[i].name, edges[i].name);
            heights.Add(edges[i].name, 0);
            currentHeight = 0;

            for (j = i - 1; j >= 0; j--)
            {
                if (edges[i].IsThisNested(edges[j]))
                {
                    currentHeight = heights[edges[j].name] + 1;
                    if(heights[edges[i].name] < currentHeight)
                    {
                        heights[edges[i].name] = currentHeight;
                        parents[edges[i].name] = edges[j].name;
                    }
                    else if(heights[edges[i].name] == currentHeight)
                    {
                        if(parents[edges[i].name].CompareTo(edges[j].name) > 0)
                        {
                            parents[edges[i].name] = edges[j].name;
                        }
                    }

                    if (maxHeight < currentHeight)
                    {
                        maxHeight = currentHeight;
                    }
                }
            }
        }

        return maxHeight;
    }

    private static void ReadGraph()
    {
        string[] s;
        Rectangle newRect;

        edges = new List<Rectangle>();

        s = Console.ReadLine().Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

        while(s[0] != "End")
        {
            newRect = new Rectangle(s[0], int.Parse(s[1]), int.Parse(s[2]), int.Parse(s[3]), int.Parse(s[4]));
            edges.Add(newRect);

            s = Console.ReadLine().Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

public class Rectangle : IComparable<Rectangle>
{
    public int left;
    public int top;
    public int right;
    public int bottom;
    public string name;
    public long size;

    public Rectangle(string name, int left, int top, int right, int bottom)
    {
        this.name = name;
        this.left = left;
        this.top = top;
        this.right = right;
        this.bottom = bottom;
        this.size = (long)(top - bottom) * (long)(right - left);
    }

    public int CompareTo(Rectangle other)
    {
        return other.size.CompareTo(this.size);
    }

    public bool IsOtherNested(Rectangle other)
    {
        bool ret;

        ret = (this.left <= other.left) && (this.top >= other.top) && (this.right >= other.right) && (this.bottom <= other.bottom);
        ret = ret && ((this.left != other.left) || (this.top != other.top) || (this.right != other.right) || (this.bottom != other.bottom));
        return ret;
    }

    public bool IsThisNested(Rectangle other)
    {
        bool ret;

        ret = (this.left >= other.left) && (this.top <= other.top) && (this.right <= other.right) && (this.bottom >= other.bottom);
        ret = ret && ((this.left != other.left) || (this.top != other.top) || (this.right != other.right) || (this.bottom != other.bottom));
        return ret;
    }

    public override string ToString()
    {
        //return "<" + this.name + ":" + string.Format("{0:F0}", this.size) + ">";
        return "<" + this.name + ":" + this.size.ToString() + ">";
    }

}