using System;


class tVertex : IComparable<tVertex>
{
    public tEdge? nodeFrom;
    public tEdge nodeTo;
    public bool isDirected;
    public double cost;

    public tVertex(T nodeFrom, T nodeTo, bool isDirected = false, double cost = null)
    {
        if
    }

    public override CompareTo

    public override string ToString()
    {
        string s = "";

        if(nodeFrom == null)
        {
            s = "[*";
        }
        else
        {
            s = "[" + nodeFrom.ToString();
        }

        if (this.isDirected)
        {
            s = s + "->" + nodeTo.ToString() + "]";
        }
        else
        {
            s = s + ", " + nodeTo.ToString() + "]";
        }

        if(cost != null)
        {
            s = s + "->" +  string.Format("{0:F2}", cost);
        }

        return s;
    }


}



public class tEdge<T> : IComparable<tEdge<T>>
{
    public T name;
    public List<> vertexes

    public double cost;


}
