using Maze_solver.Emums;
using Maze_solver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Maze_solver
{
    public class RandomGeneration : IMaze
    {
        public Squere[,] Field { get; private set; }
        private Random rnd { get; set; }
        public List<Decider> deciders { get; set; }

        private Point startPoint { get; set; }

        public RandomGeneration(Squere[,] field)
        {
            this.Field = field;
            rnd = new Random();
            startPoint = new Point();
            Reset();

        }

        public void Reset()
        {
            this.deciders = new List<Decider>();
            deciders.Add(new Decider(startPoint, startPoint));
        }

        public bool Start()
        {
            if (deciders.Count == 0)
            {

                return true;
            }

            deciders[deciders.Count - 1].FindPosibleDirections(Field);

            Point moveTo = deciders[deciders.Count - 1].Move(true);


            if (moveTo == null)
            {
                deciders[deciders.Count - 1].EditSquere(deciders[deciders.Count - 1].Pozicion);
                deciders.RemoveAt(deciders.Count - 1);

                if (deciders.Count == 1)
                {
                    deciders[deciders.Count - 1].EditSquere(deciders[deciders.Count - 1].Pozicion);
                    deciders[0].PossibleDirections.Clear();

                }

            }
            else
            {
                if (deciders.Count != 0)
                {

                    deciders.Add(new Decider(moveTo, deciders[deciders.Count - 1].Pozicion));

                }
                else
                {
                    MessageBox.Show("Done!!!!!!!!!!!!!!!!!!!!!!");
                    return false;
                }

            }

            return false;

        }

       


        public Point PickedStart(Point? start)
        {

            if (start != null)
            {
                this.Field[start.Y, start.X] = new Squere(new Point(start.X, start.Y), TypesOfSqueres.Start, new Label());
                startPoint = start;
            }
            else
            {
                startPoint.X = rnd.Next(1, 28);
                startPoint.Y = rnd.Next(1, 28);
                Field[startPoint.X, startPoint.Y] = new Squere(new Point(startPoint.X, startPoint.Y), TypesOfSqueres.Start, new Label());
            }      
            return startPoint;
        }

        public void GenRndStart()
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Field[i, j] = new Squere(new Point(i, j), TypesOfSqueres.Space, new Label());

                    if (i == 0 || i == 29 || j == 0 || j == 29)
                    {
                        Field[i, j].TypesOfSquere = TypesOfSqueres.Wall;

                    }
                    else
                    {
                        Field[i, j].TypesOfSquere = TypesOfSqueres.Space;
                    }
                }
            }
        }
    }
}
