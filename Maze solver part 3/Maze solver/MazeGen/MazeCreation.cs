using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Maze_solver.Interfaces;
using Maze_solver.Emums;

namespace Maze_solver.MazeGen
{
    public class MazeCreation : IMaze
    {
        public Squere[,] Field { get; private set; }
        private Random rnd { get; set; }

        public Point startPoint { get; set; }
        public Point endPoint { get; set; }

        public List<Decider> deciders { get; set; }

        public MazeCreation(int x, int y)
        {
            Field = new Squere[x, y];
            Reset();
        }

        public void Reset()
        {
            rnd = new Random();
            deciders = new List<Decider>();
            startPoint = new Point();
            endPoint = new Point();
        }


        public void GenRndStart()
        {
            Reset();

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
                        Field[i, j].TypesOfSquere = TypesOfSqueres.Nothing;
                    }
                }
            }

            GenEndStart();
        }

        public void GenEndStart()
        {
            do
            {
                startPoint.X = rnd.Next(1, 28);
                startPoint.Y = rnd.Next(1, 28);
            }
            while (Field[startPoint.X, startPoint.Y].TypesOfSquere == TypesOfSqueres.Wall);            

            do
            {
                endPoint.X = rnd.Next(1, 28);
                endPoint.Y = rnd.Next(1, 28);
            }
            while (Field[endPoint.X, endPoint.Y].TypesOfSquere == TypesOfSqueres.Wall);


            Field[startPoint.X, startPoint.Y].Label.BackColor = Color.Red;
            Field[startPoint.X, startPoint.Y].TypesOfSquere = TypesOfSqueres.Start;

            Field[endPoint.X, endPoint.Y].Label.BackColor = Color.Green;
            Field[endPoint.X, endPoint.Y].TypesOfSquere = TypesOfSqueres.Finish;


            deciders.Add(new Decider(startPoint, startPoint));
        }


        public void GeneretStaticMap(StreamReader sr)
        {
            Reset();
            sr.BaseStream.Position = 0;
            string read = "";

            for (int i = 0; i < this.Field.GetLength(0); i++)
            {
                read = sr.ReadLine();
                for (int j = 0; j < this.Field.GetLength(1); j++)
                {
                    Field[i, j] = new Squere(new Point(i, j), TypesOfSqueres.Space, new Label());


                    switch ((char)read[j])
                    {
                        case '-':
                            Field[i, j].TypesOfSquere = TypesOfSqueres.Wall;
                            break;

                        case '*':
                            Field[i, j].TypesOfSquere = TypesOfSqueres.Space;
                            break;

                        case 's':
                            Field[i, j].TypesOfSquere = TypesOfSqueres.Start;
                            startPoint.X = i;
                            startPoint.Y = j;
                            break;

                        case 'e':
                            Field[i, j].TypesOfSquere = TypesOfSqueres.Finish;
                            endPoint.X = i;
                            endPoint.Y = j;
                            break;
                        default:
                            break;
                    }
                }
            }
            deciders.Add(new Decider(startPoint, startPoint));
        }




        public bool Start()
        {

            if (deciders.Count == 0)
            {
                return true;
            }
            deciders[deciders.Count - 1].FindPosibleDirections(Field);



            Point moveTo = deciders[deciders.Count - 1].Move(false);

            if (!deciders[deciders.Count - 1].FinishControll(endPoint))
            {
                if (moveTo == null)
                {
                    deciders[deciders.Count - 1].EditSquere(deciders[deciders.Count - 1].Pozicion);
                    deciders.RemoveAt(deciders.Count - 1);
                    /// set color to white
                    /// moveback() pint direction deciders.Count - 1 
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
            else
            {
                return true;
            }

        }
    }
}
