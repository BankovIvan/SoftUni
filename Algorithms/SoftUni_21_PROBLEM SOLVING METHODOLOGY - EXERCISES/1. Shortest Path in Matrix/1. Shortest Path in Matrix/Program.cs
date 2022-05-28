using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        int i, j, rows, cols;
        int[,] matrix, memo;
        int[] input;

        Dictionary<Cell, List<Cell>> graph;
        Dictionary<Cell, Cell> parents;

        rows = int.Parse(Console.ReadLine());
        cols = int.Parse(Console.ReadLine());

        matrix = new int[rows, cols];
        memo = new int[rows, cols];
        input = new int[cols];

        for (i = 0; i < rows; i++)
        {
            Console.Write(" ");
            input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (j = 0; j < cols; j++)
            {
                matrix[i, j] = input[j];
                memo[i, j] = int.MaxValue;
            }

        }

        memo[0, 0] = matrix[0, 0];

        graph = BuildGraph(matrix);

        parents = Dijkstra(graph);

        PrintPath(graph, parents);

        return;
    }

    private static void PrintPath(Dictionary<Cell, List<Cell>> graph, Dictionary<Cell, Cell> parents)
    {
        int i, cost = 0;
        string s = "";

        Cell startCell = graph.Keys.First();
        Cell currentCell = graph.Keys.Last();

        while (! currentCell.Equals(startCell))
        {
            i = graph[parents[currentCell]].IndexOf(currentCell);

            cost = cost + graph[parents[currentCell]][i].value;
            s = graph[parents[currentCell]][i].value.ToString() + " " + s;

            currentCell = parents[currentCell];
        }

        cost = cost + graph[startCell][0].value;
        s = graph[startCell][0].value.ToString() + " " + s;

        Console.WriteLine("Length: {0}", cost);
        Console.WriteLine("Path: " + s);

        return;
    }

    private static Dictionary<Cell, Cell> Dijkstra(Dictionary<Cell, List<Cell>> graph)
    {
        Cell currentCell = graph[graph.Keys.First()][0];
        
        //graph[...][0] - the first Cell object in the List of childs/edges is used to hold the properties of the node itself;
        //Elements 1+ hold path value to the given destination Cell, element 0 holds v[] (or best path) value and visited flag;
        //graph[currentCell][0].value = matrix[0, 0];
        int distance = 0;

        //We will reconstruct the path based on this dictionary;
        Dictionary<Cell, Cell> parents = new Dictionary<Cell, Cell>();
        parents.Add(currentCell, null);

        //SoftUni provided Priority Queye
        PriorityQueue<Cell> queue = new PriorityQueue<Cell>();
        queue.Enqueue(currentCell);

        while(queue.Count > 0)
        {
            currentCell = queue.ExtractMin();
            foreach (var child in graph[currentCell])
            {
                //We skip the first element of the list, as it is used to hold the current node properties;
                if (!child.Equals(currentCell))
                {
                    if (graph[child][0].visited == false)
                    {
                        graph[child][0].visited = true;
                        queue.Enqueue(graph[child][0]);
                    }

                    distance = graph[currentCell][0].value + child.value;
                    if (graph[child][0].value > distance)
                    {
                        graph[child][0].value = distance;

                        parents[child] = currentCell;
                        //parents[child].value = child.value;

                        queue.DecreaseKey(graph[child][0]);
                    }

                }

            }

        }

        return parents;

    }

    private static Dictionary<Cell, List<Cell>> BuildGraph(int[,] matrix)
    {
        int i, j, nextRow, nextCol;
        Cell cell;
        List<Cell> neighbours;
        Dictionary<Cell, List<Cell>> graph = new Dictionary<Cell, List<Cell>>();

        for (i = 0; i < matrix.GetLength(0); i++)
        {
            for(j = 0; j < matrix.GetLength(1); j++)
            {
                cell = new Cell(i, j, matrix[i, j]);
                neighbours = new List<Cell>();
                neighbours.Add(new Cell(i, j, int.MaxValue));

                //Down
                nextRow = i + 1;
                nextCol = j;
                if (nextRow >= 0 && nextRow < matrix.GetLength(0) && nextCol >= 0 && nextCol < matrix.GetLength(1))
                {
                    neighbours.Add(new Cell(nextRow, nextCol, matrix[nextRow, nextCol]));
                }


                //Left
                nextRow = i;
                nextCol = j - 1;
                if (nextRow >= 0 && nextRow < matrix.GetLength(0) && nextCol >= 0 && nextCol < matrix.GetLength(1))
                {
                    neighbours.Add(new Cell(nextRow, nextCol, matrix[nextRow, nextCol]));
                }


                //Up
                nextRow = i - 1;
                nextCol = j;
                if (nextRow >= 0 && nextRow < matrix.GetLength(0) && nextCol >= 0 && nextCol < matrix.GetLength(1))
                {
                    neighbours.Add(new Cell(nextRow, nextCol, matrix[nextRow, nextCol]));
                }

                //Right
                nextRow = i;
                nextCol = j + 1;
                if (nextRow >= 0 && nextRow < matrix.GetLength(0) && nextCol >= 0 && nextCol < matrix.GetLength(1))
                {
                    neighbours.Add(new Cell(nextRow, nextCol, matrix[nextRow, nextCol]));
                }

                graph.Add(cell, neighbours);

            }
        }

        graph[graph.Keys.First()][0].value = matrix[0, 0];

        return graph;
    }

    private class Cell:IComparable<Cell>, IEquatable<Cell>
    {
        public int row;
        public int col;
        public int value;
        public bool visited;

        public Cell(int row, int col, int value)
        {
            this.row = row;
            this.col = col;
            this.value = value;
            this.visited = false;
        }

        public int CompareTo(Cell other)
        {
            return this.value.CompareTo(other.value);
        }

        public bool Equals(Cell other)
        {
            return (this.row == other.row && this.col == other.col);
        }

        public override string ToString()
        {
            return "<" + this.row.ToString() + "," + this.col.ToString() + ":" + this.value.ToString() + ":" + (this.visited ? "Y" : "N") + ">";
        }

        public override int GetHashCode()
        {
            return row * 64 + col;
        }
    }

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private Dictionary<T, int> searchCollection;
        private List<T> heap;

        public PriorityQueue()
        {
            this.heap = new List<T>();
            this.searchCollection = new Dictionary<T, int>();
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public T ExtractMin()
        {
            var min = this.heap[0];
            var last = this.heap[this.heap.Count - 1];
            this.searchCollection[last] = 0;
            this.heap[0] = last;
            this.heap.RemoveAt(this.heap.Count - 1);
            if (this.heap.Count > 0)
            {
                this.HeapifyDown(0);
            }

            this.searchCollection.Remove(min);

            return min;
        }

        public T PeekMin()
        {
            return this.heap[0];
        }

        public void Enqueue(T element)
        {
            this.searchCollection.Add(element, this.heap.Count);
            this.heap.Add(element);
            this.HeapifyUp(this.heap.Count - 1);
        }

        private void HeapifyDown(int i)
        {
            var left = (2 * i) + 1;
            var right = (2 * i) + 2;
            var smallest = i;

            if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = left;
            }

            if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = right;
            }

            if (smallest != i)
            {
                T old = this.heap[i];
                this.searchCollection[old] = smallest;
                this.searchCollection[this.heap[smallest]] = i;
                this.heap[i] = this.heap[smallest];
                this.heap[smallest] = old;
                this.HeapifyDown(smallest);
            }
        }

        private void HeapifyUp(int i)
        {
            var parent = (i - 1) / 2;
            while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) < 0)
            {
                T old = this.heap[i];
                this.searchCollection[old] = parent;
                this.searchCollection[this.heap[parent]] = i;
                this.heap[i] = this.heap[parent];
                this.heap[parent] = old;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        public void DecreaseKey(T element)
        {
            //Modified!!!
            if (this.searchCollection.ContainsKey(element))
            {
                int index = this.searchCollection[element];
                this.HeapifyUp(index);
            }
        }

        public override string ToString()
        {
            return this.Count.ToString();
        }
    }
}

