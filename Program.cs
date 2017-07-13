using System;
using System.Collections.Generic;

namespace Mazes
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = Sidewinder.Load(new Grid(10, 10));

            Console.Write(grid.ToString());
            //Console.Read();
        }
    }
}
