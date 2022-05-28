using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static int n;
    static HashSet<String> visited = new HashSet<String>();
    static HashSet<String> snakes = new HashSet<String>();
    static char[] CurrentSnake;
    static char[] tmp;
    static int counter = 0;

    static void Main(string[] args)
    {

        n = int.Parse(Console.ReadLine());
        CurrentSnake = new char[n];
        tmp = new char[n];

        //Console.WriteLine(Reverse("SABCDE").ToString());
        //MarkResult("SRRD");
        //Console.WriteLine();

        Gen(0, 0, 0, 'S');

        Console.WriteLine("Snakes count = {0}", counter);

        return;

    }

    private static void Gen(int index, int row, int col, char direction)
    {
        string result;

        if(index >= n)
        {
            result = string.Concat(CurrentSnake);

            if (!snakes.Contains(result))
            {
                //Console.WriteLine(result);
                //snakes.Add(result);
                MarkResult(result);
                
            }

            return;

        }
        else
        {
            string CurrentCell = row + " " + col;

            if (!visited.Contains(CurrentCell))
            {
                CurrentSnake[index] = direction;
                visited.Add(CurrentCell);
                Gen(index + 1, row, col + 1, 'R');
                Gen(index + 1, row + 1, col, 'D');
                Gen(index + 1, row, col - 1, 'L');
                Gen(index + 1, row - 1, col, 'U');
                visited.Remove(CurrentCell);
            }

        }
    }

    private static void MarkResult(string snake)
    {
        int i;


        Console.WriteLine(snake);
        counter++;


        string flipped = Flip(snake);
        string reversed = Reverse(snake);
        string flippedReversed = Reverse(flipped);

        //if (!snakes.Contains(snake))
        //{
            for(i = 0; i < 4; i++)
            {
                snake = Rotate(snake);
                snakes.Add(snake);
            }


            for (i = 0; i < 4; i++)
            {
                flipped = Rotate(flipped);
                snakes.Add(flipped);
            }


            for (i = 0; i < 4; i++)
            {
                reversed = Rotate(reversed);
                snakes.Add(reversed);
            }

            for (i = 0; i < 4; i++)
            {
                flippedReversed = Rotate(flippedReversed);
                snakes.Add(flippedReversed);
            }

        //}

    }

    private static string Rotate(string snake)
    {
        //char[] tmp = snake.ToCharArray();
        int i;

        for (i = 0; i < tmp.Length; i++)
        {
            switch (snake[i])
            {
                case 'R': tmp[i] = 'D'; break;
                case 'D': tmp[i] = 'L'; break;
                case 'L': tmp[i] = 'U'; break;
                case 'U': tmp[i] = 'R'; break;
                case 'S': break;
                default: tmp[i] = snake[i];  break;

            }
        }

        return new string(tmp);
    }

    private static string Flip(string snake)
    {
        //char[] tmp = snake.ToCharArray();
        int i;

        for (i = 0; i < tmp.Length; i++)
            if (snake[i] == 'U') tmp[i] = 'D';
            else if (snake[i] == 'D') tmp[i] = 'U';
            else tmp[i] = snake[i];


        return new string(tmp);

    }

    private static string Reverse(string snake)
    {
        //char[] tmp = snake.ToCharArray();
        //char c;
        int i;
        //int len = (tmp.Length + 1) / 2;

        tmp[0] = 'S';
        for (i = 1; i < tmp.Length; i++) tmp[tmp.Length - i] = snake[i];


        return new string(tmp);
    }


    /*
    
    private static string Rotate(string snake)
    {
        char[] tmp = snake.ToCharArray();
        int i;

        for(i = 1; i < tmp.Length; i++)
        {
            switch (tmp[i])
            {
                case 'R': tmp[i] = 'D'; break;
                case 'D': tmp[i] = 'L'; break;
                case 'L': tmp[i] = 'U'; break;
                case 'U': tmp[i] = 'R'; break;
                default: break;

            }
        }

        return new string(tmp);
    }

    private static string Flip(string snake)
    {
        char[] tmp = snake.ToCharArray();
        int i;

        for (i = 0; i < tmp.Length; i++)
            if (tmp[i] == 'U') tmp[i] = 'D';
            else if (tmp[i] == 'D') tmp[i] = 'U';


        return new string(tmp);

    }

    private static string Reverse(string snake)
    {
        char[] tmp = snake.ToCharArray();
        char c;
        int i;
        int len = (tmp.Length + 1) / 2;

        tmp[0] = 'S';
        for (i = 1; i < len; i++)
        {
            c = tmp[tmp.Length - i];
            tmp[tmp.Length - i] = tmp[i];
            tmp[i] = c;
        }

        return new string(tmp);
    }

    */
}
