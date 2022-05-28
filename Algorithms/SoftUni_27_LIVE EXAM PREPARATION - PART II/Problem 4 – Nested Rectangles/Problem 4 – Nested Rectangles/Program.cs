using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Numerics;

class Program
{

    public static List<Rectangle> rectangles = new List<Rectangle>();

    static void Main(string[] args)
    {
        ReadGraph();

        Rectangle maxRectangle = rectangles[0];

        foreach (var currentRectangle in rectangles)
        {
            CalculateDepth(currentRectangle);

            if(maxRectangle.CompareTo(currentRectangle) > 0)
            {
                maxRectangle = currentRectangle;
            }
        }

        Console.Write(maxRectangle.name);
        maxRectangle = maxRectangle.parent;
        while(!(maxRectangle is null))
        {
            Console.Write(" < " + maxRectangle.name);
            maxRectangle = maxRectangle.parent;
        }

        Console.WriteLine();

        return;
    }

    private static void CalculateDepth(Rectangle currentRectangle)
    {
        Rectangle maxRectangle = null;

        if(currentRectangle.depth == 0)
        {
            foreach (var nextRectangle in rectangles)
            {
                if(currentRectangle.name != nextRectangle.name && currentRectangle.IsOtherNested(nextRectangle))
                {
                    if(nextRectangle.depth == 0)
                    {
                        CalculateDepth(nextRectangle);
                    }

                    if(maxRectangle == null)
                    {
                        maxRectangle = nextRectangle;
                    }
                    else
                    {
                        if(maxRectangle.CompareTo(nextRectangle) > 0)
                        {
                            maxRectangle = nextRectangle;
                        }
                    }
                }
            }

            if (maxRectangle == null)
            {
                currentRectangle.depth = 1;
                //currentRectangle.parent = currentRectangle;
            }
            else
            {
                currentRectangle.depth = maxRectangle.depth + 1;
                currentRectangle.parent = maxRectangle;
            }
        }
    }

    private static void ReadGraph()
    {
        string[] s;
        Rectangle newRect;

        //edges = new List<Rectangle>();

        s = Console.ReadLine().Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

        while (s[0] != "End")
        {
            newRect = new Rectangle(s[0], int.Parse(s[1]), int.Parse(s[2]), int.Parse(s[3]), int.Parse(s[4]));
            rectangles.Add(newRect);

            s = Console.ReadLine().Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }

}

public class Rectangle/* : IComparable<Rectangle>*/
{
    public int left;
    public int top;
    public int right;
    public int bottom;
    public int depth;
    public string name;
    public Rectangle parent;

    public Rectangle(string name, int left, int top, int right, int bottom)
    {
        this.name = name;
        this.parent = null;
        this.depth = 0;
        this.left = left;
        this.top = top;
        this.right = right;
        this.bottom = bottom;
    }

    public int CompareTo(Rectangle other)
    {
        int ret;

        ret = other.depth.CompareTo(this.depth);

        if(ret == 0)
        {
            ret = string.Compare(this.name, other.name, StringComparison.Ordinal);
        }

        return ret;
    }

    public bool IsOtherNested(Rectangle other)
    {
        return (this.left <= other.left) && (this.top >= other.top) && (this.right >= other.right) && (this.bottom <= other.bottom);
    }

    public override string ToString()
    {
        //return "<" + this.name + ":" + string.Format("{0:F0}", this.size) + ">";
        return "<" + this.name + "," + this.depth.ToString() + ":" + (this.parent == null ? "<None>" : this.parent.name) + ">";
    }

}