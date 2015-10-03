using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMaze
{
    class Path
    {
        public int XPoint { get; set; }
        public int YPoint {get;set;}

        internal string ShowIt()
        {
            return String.Format("Step{0},{1} ,", XPoint, YPoint);
        }
        
        internal void Process()
        {
            Console.WriteLine("\n\nStarting step is {0},{1}", XPoint, YPoint);
        }
    }
}
