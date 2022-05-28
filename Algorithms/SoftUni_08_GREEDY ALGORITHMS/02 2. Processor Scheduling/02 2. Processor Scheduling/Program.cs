using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static int total = 0;

    static void Main(string[] args)
    {
        int totalTasks;
        int i;
        
        string s;

        List<TaskItem> givenItems = new List<TaskItem>();
        List<TaskItem> AddedItems = new List<TaskItem>();

        totalTasks = int.Parse(Console.ReadLine().Split(' ').Last());

        for (i = 0; i < totalTasks; i++)
        {
            s = Console.ReadLine();
            givenItems.Add(new TaskItem(i + 1, int.Parse(s.Split(' ').First()), int.Parse(s.Split(' ').Last())));
        }

        Schedule(givenItems, AddedItems);


        
        s = "";
        
        for (i = 0; i < AddedItems.Count; i++)
        {
            s = (s == "") ? AddedItems[i].number.ToString() : s + " -> " + AddedItems[i].number.ToString();
            total += AddedItems[i].value;

        }

        

        Console.WriteLine("Optimal schedule: {0}", s);
        Console.WriteLine("Total value: {0}", total);

    
        return;
    }

    private static void Schedule(List<TaskItem> givenItems, List<TaskItem> addedItems)
    {
        int i, j;
        int finalDeadline;

        givenItems.Sort();
        finalDeadline = givenItems.Last().deadline;

        givenItems = givenItems.OrderByDescending(x => x.value).ToList();

        i = 0;
        j = 0;
        while(addedItems.Count < finalDeadline && j < givenItems.Count)
        {
            addedItems.Add(givenItems[j]);
            j++;

            addedItems.Sort();

            for(i = 0; i < addedItems.Count; i++)
            {
                if(!(addedItems[i].deadline > i))
                {
                    addedItems.RemoveAt(1);
                    break;
                }
            }
        }

    }

    /*
    private static bool CanBeAdded(TaskItem givenItem, List<TaskItem> addedItems, int finalDeadline)
    {
        int i, currentDeadline;

        if (addedItems.Count == 0 && givenItem.deadline > 0) return true;
        else if (addedItems.Count >= finalDeadline) return false;

        //currentDeadline = finalDeadline;

        for (i = addedItems.Count - 1; i >= 0; i--)
        {
            if(givenItem.deadline >= addedItems[i].deadline)
            {

                if(addedItems[i].deadline > i)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }

            //currentDeadline = addedItems[i].deadline;

        }


        return true;
    } 
    */

    class TaskItem : IComparable<TaskItem>
    {
        public int number;
        public int value;
        public int deadline;
        //public bool completed;

        public TaskItem(int number, int value, int deadline)
        {
            this.number = number;
            this.value = value;
            this.deadline = deadline;
            //this.completed = false;
        }

        public int CompareTo(TaskItem other)
        {
            if(other.deadline == this.deadline)
                return other.value.CompareTo(this.value);
            else
                return this.deadline.CompareTo(other.deadline);
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

    }
}
