using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_solver
{
    public class Decider
    {

        // stačí mi všude nastavovat jenom TypesOfSquers labely mi vygeneruje mazegeneration

        public List<Directions> PossibleDirections { get; set; }
        private List<Directions> directions { get; set; }
        public Point Pozicion { get; set; }
        public Point LastPozicion { get; set; }


        private Random rnd;

        private Squere[,] field { get; set; }



        public Decider(Point pozicion, Point lastPozicion)
        {
            this.rnd = new Random();
            this.PossibleDirections = new List<Directions>();
            this.directions = new List<Directions>() { Directions.Up, Directions.Down, Directions.Right, Directions.Left };
            this.Pozicion = pozicion;
            this.LastPozicion= lastPozicion;
        }

        /// <summary>
        /// It will delete the possible path where i came to here
        /// </summary>
        public void DeleteLast()
        {

            int moveX = Pozicion.X - LastPozicion.X;
            int moveY = Pozicion.Y - LastPozicion.Y;

            if (moveX > 0)
            {
                PossibleDirections.Remove(Directions.Up);
            }
            else if (moveX < 0)
            {
                PossibleDirections.Remove(Directions.Down);
            }

            if (moveY > 0)
            {
                PossibleDirections.Remove(Directions.Left);
            }
            else if (moveY < 0)
            {
                PossibleDirections.Remove(Directions.Right);
            }
        }

        // tady chci jenom mazat z listu nevalidní směry
        public void FindPosibleDirections(Squere[,] field)
        {
            this.field = field;
           

            // can by just for 3 direction bcs i came from one
            while(directions.Count != 0)
            {
                int rndN = rnd.Next(0, directions.Count );
                Directions rndDirection = this.directions[rndN];
                directions.RemoveAt(rndN); 


                switch (rndDirection)
                {
                    case Directions.Up:

                        if (Pozicion.X - 1 >= 0 && (field[Pozicion.X - 1, Pozicion.Y].TypesOfSquere != TypesOfSqueres.Wall))
                        {
                            PossibleDirections.Add(Directions.Up);
                        }

                        break;

                    case Directions.Down:

                        if (Pozicion.X + 1 < 29 && (field[Pozicion.X + 1, Pozicion.Y].TypesOfSquere != TypesOfSqueres.Wall))
                        {
                            PossibleDirections.Add(Directions.Down);
                        }
                        break;

                    case Directions.Left:

                        if (Pozicion.Y - 1 >= 0 && (field[Pozicion.X, Pozicion.Y-1].TypesOfSquere != TypesOfSqueres.Wall))
                        {
                            PossibleDirections.Add(Directions.Left);
                        }
                        break;

                    case Directions.Right:

                        if (Pozicion.Y < 29 && (field[Pozicion.X, Pozicion.Y + 1].TypesOfSquere != TypesOfSqueres.Wall))
                        {
                            PossibleDirections.Add(Directions.Right);
                        }
                        break;
                    default:
                        break;
                }
            }

            DeleteLast();

            //string messege = "";
            //PossibleDirections.ForEach(x => messege = messege + " " + x.ToString());
            //MessageBox.Show(messege);
        }

        //public bool Controll()
        //{

        //}

        public bool FinishControll(Point finishPoint)
        {
            if (finishPoint.X == Pozicion.X && finishPoint.Y == Pozicion.Y)
            {
                return true;
            }
            return false;
        }

        public Point? Move()
        {
            if(PossibleDirections.Count > 0)
            {
                Directions direction = PossibleDirections[0];
                Point moveTo = null;

                switch (direction)
                {
                    case Directions.Up:
                        moveTo = new Point(Pozicion.X - 1, Pozicion.Y);
                        break;

                    case Directions.Down:
                        moveTo = new Point(Pozicion.X + 1, Pozicion.Y);
                        break;

                    case Directions.Left:
                        moveTo = new Point(Pozicion.X, Pozicion.Y - 1);
                        break;

                    case Directions.Right:
                        moveTo = new Point(Pozicion.X, Pozicion.Y + 1);
                        break;
                    default:
                        break;
                }
                EditSquere(moveTo);
                return moveTo;
            }
            return null;
        }


        public void EditSquere(Point point)
        {
            foreach( Squere squere in field)
            {
                if(squere.pozicion.X == point.X && squere.pozicion.Y == point.Y)
                {
                    squere.Change(TypesOfSqueres.Exceeded, Color.Blue);
                }
            }
        }

    }
}
