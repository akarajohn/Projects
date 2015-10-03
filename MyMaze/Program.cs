using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMaze
{

    class Program
    {
        static void Main(string[] args)
        {
            Maze m = new Maze();
            Console.WriteLine("Welcome to the Maze Game!!! \n \n \n");
            m.Initialize();
            m.Solve();
            m.Print();
           
            Console.ReadKey();
        }
    }
}
