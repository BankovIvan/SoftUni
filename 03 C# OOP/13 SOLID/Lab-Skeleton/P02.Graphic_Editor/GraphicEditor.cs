﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            shape.Draw();

            /*
            if (shape is Circle)
            {
                Console.WriteLine("I'm Circle");
            }
            else if (shape is Rectangle)
            {
                Console.WriteLine("I'm Recangle");
            }
            else if (shape is Square)
            {
                Console.WriteLine("I'm Square");
            }
            */
        }
    }
}
