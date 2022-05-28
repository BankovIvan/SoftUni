﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MyConsolePrintHelper
{
    public static void PrintMatrix(int[,] matrix, int padding = 5, bool addNewLine = false)
    {
        string s;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            s = matrix[i, 0].ToString().PadLeft(padding);
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                s = s + "," + matrix[i, j].ToString().PadLeft(padding);
            }
            Console.WriteLine(s);
        }

        if (addNewLine) Console.WriteLine();

    }

    public static void PrintMatrix(bool[,] matrix, int padding = 5, bool addNewLine = false)
    {
        string s;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            s = matrix[i, 0].ToString().PadLeft(padding);
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                s = s + "," + matrix[i, j].ToString().PadLeft(padding);
            }
            Console.WriteLine(s);
        }

        if (addNewLine) Console.WriteLine();

    }
}