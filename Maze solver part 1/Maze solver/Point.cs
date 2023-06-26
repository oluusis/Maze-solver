using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Maze_solver
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public Point()
        {

        }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
