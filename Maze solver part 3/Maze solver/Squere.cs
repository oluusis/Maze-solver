using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze_solver.Emums;

namespace Maze_solver
{
    public class Squere : EventArgs
    {
        public Point pozicion { get; private set; }
        public TypesOfSqueres TypesOfSquere {get; set;}
        public Label Label { get; set; }


        public Squere() { }

        public Squere(Point pozicion, TypesOfSqueres TypesOfSquer, Label label)
        {
            this.pozicion = pozicion;
            this.TypesOfSquere = TypesOfSquer;
            this.Label = label; 
        }

        public void Change(TypesOfSqueres typesOfSqueres, Color color)
        {
            this.TypesOfSquere = typesOfSqueres;
            this.Label.BackColor = color;
        }
    }
}
