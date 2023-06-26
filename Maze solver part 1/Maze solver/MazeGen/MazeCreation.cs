using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Maze_solver.MazeGen
{
    public class MazeCreation
    {
        public Squere[,] Field { get; private set; }
        private Random rnd { get; set; }

        private Point startPoint { get; set; }
        private Point endPoint { get; set; }

        private List<Decider> deciders { get; set; }

        public MazeCreation(int x, int y)
        {
            Field = new Squere[x, y];
            rnd = new Random();
            deciders = new List<Decider>();
            startPoint = new Point();
            endPoint = new Point();
        }


        public void GenStart()
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

            startPoint.X = rnd.Next(1,28);
            startPoint.Y = rnd.Next(1, 28);
            Field[startPoint.X, startPoint.Y] = new Squere(new Point(startPoint.X, startPoint.Y), TypesOfSqueres.Start, new Label());

            deciders.Add( new Decider(startPoint, startPoint));

            endPoint.X = rnd.Next(1, 28);
            endPoint.Y = rnd.Next(1, 28);
            Field[endPoint.X, endPoint.Y] = new Squere(new Point(endPoint.X, endPoint.Y), TypesOfSqueres.Finish, new Label());
        }

        public bool Generation()
        {
            deciders[deciders.Count - 1].FindPosibleDirections(Field);

            Point moveTo = deciders[deciders.Count - 1].Move();

            if(!deciders[deciders.Count - 1].FinishControll(endPoint))
            {
                if (moveTo == null)
                {
                    deciders.RemoveAt(deciders.Count - 1);
                }
                else
                {
                    if (deciders.Count != 0)
                    {

                        deciders.Add(new Decider(moveTo, deciders[deciders.Count - 1].Pozicion));

                    }
                    else
                    {
                        MessageBox.Show("Done");
                        return false;
                    }

                }
                return false;
             }
            else
            {

                Debug.Write("End!");
                return true;
            }

}

    }
}
