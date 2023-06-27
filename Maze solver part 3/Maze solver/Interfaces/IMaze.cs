using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_solver.Interfaces
{
    public interface IMaze
    {
        public void Reset();

        public bool Start();

        public void GenRndStart();

    }
}
