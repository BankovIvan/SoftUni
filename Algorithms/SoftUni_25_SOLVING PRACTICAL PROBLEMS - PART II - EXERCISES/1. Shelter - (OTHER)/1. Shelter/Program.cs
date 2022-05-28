using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    private static List<Edge> edges;
    private static int numberOfSoldiers, numberOfShelters, soldierCapacity, shelterCapacity;

    static void Main(string[] args)
    {
        int i, j;
        int[] soldiersCount, sheltesrCount;
        double currCost, minCost, totalSoldiers;

        ReadGraph();

        minCost = double.MaxValue;
        edges.Sort();

        for (i = 0; i < edges.Count; i++)
        {
            totalSoldiers = 0;
            currCost = 0;
            soldiersCount = new int[numberOfSoldiers];
            sheltesrCount = new int[numberOfShelters];

            for (j = i; j < edges.Count; j++)
            {
                if(soldiersCount[edges[j].soldier] < soldierCapacity && sheltesrCount[edges[j].shelter] < shelterCapacity)
                {
                    if(currCost < edges[j].cost)
                    {
                        currCost = edges[j].cost;
                    }
                    soldiersCount[edges[j].soldier]++;
                    sheltesrCount[edges[j].shelter]++;
                    totalSoldiers++;
                }
            }

            if(totalSoldiers == numberOfSoldiers * soldierCapacity)
            {
                if(minCost > currCost)
                {
                    minCost = currCost;
                }
            }
        }

        Console.WriteLine("{0:F6}", minCost);

        return;
    }

    private static void ReadGraph()
    {
        int i, j, k;
        int[][] soldierPositions, shelterPositions;
        string[] s;
        Edge newEdge;

        Console.Write("    ");
        s = Console.ReadLine().Split(' ');

        numberOfSoldiers = int.Parse(s[0]);
        numberOfShelters = int.Parse(s[1]);
        shelterCapacity = int.Parse(s[2]);
        soldierCapacity = 1;

        soldierPositions = new int[numberOfSoldiers][];
        for (i = 0; i < numberOfSoldiers; i++)
        {
            s = Console.ReadLine().Split(' ');
            soldierPositions[i] = new int[] { int.Parse(s[0]), int.Parse(s[1]) };
        }

        shelterPositions = new int[numberOfShelters][];
        for (i = 0; i < numberOfShelters; i++)
        {
            s = Console.ReadLine().Split(' ');
            shelterPositions[i] = new int[] { int.Parse(s[0]), int.Parse(s[1]) };
        }

        edges = new List<Edge>();
        for (i = 0; i < numberOfShelters; i++)
        {
            for(j = 0; j < numberOfSoldiers; j++)
            {
                newEdge = new Edge(i, j);
                newEdge.CalculateCost(shelterPositions[i][0], shelterPositions[i][1], soldierPositions[j][0], soldierPositions[j][1]);
                edges.Add(newEdge);

            }
        }
        return;
    } 

}

public class Edge : IComparable<Edge>
{
    public int soldier;
    public int shelter;
    public double cost;

    public Edge(int shelter, int soldier)
    {
        this.soldier = soldier;
        this.shelter = shelter;
        this.cost = 0.0;
    }

    public void CalculateCost(int shelterX, int shelterY, int soldierX, int soldierY)
    {
        double dx, dy;
        dx = (double)(shelterX - soldierX);
        dx = dx * dx;
        dy = (double)(shelterY - soldierY);
        dy = dy * dy;
        this.cost = Math.Sqrt(dx + dy);
    }

    public int CompareTo(Edge other)
    {
        return this.cost.CompareTo(other.cost);
    }
    public override string ToString()
    {
        return "<(" + soldier.ToString().PadLeft(4) + "," + shelter.ToString().PadLeft(4) + string.Format("):{0:F2}>", cost);
    }
}