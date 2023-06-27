using Maze_solver.Emums;
using Maze_solver.MazeGen;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace Maze_solver
{
    public partial class Form : System.Windows.Forms.Form
    {
        private MazeStartView mS;
        private MazeCreation mC;
        private RandomGeneration mRG;

        private StreamReader sr;
        private Random rnd;

        public Form()
        {
            InitializeComponent();
            rnd = new Random();
            Reset();
        }

        private void Reset()
        {
            this.counter = 0;

            if (this.panelMaze.Controls != null)
            {
                for (int i = 0; i < 100; i++)
                {
                    foreach (Control ctrl in this.panelMaze.Controls)
                    {
                        this.panelMaze.Controls.Remove(ctrl);

                    }
                }
            }

            this.mC = new MazeCreation(30, 30);
            this.mS = new MazeStartView(this, mC);

        }

        private void buttonGenerateMaze_Click(object sender, EventArgs e)
        {
            Reset();

            this.mRG = new RandomGeneration(mC.Field);
            mRG.PickedStart(null);
            mRG.GenRndStart();

            mS.GenerateView();
            timerGen.Start();

        }



        private void buttonGenFromFile_Click(object sender, EventArgs e)
        {
            if (this.sr != null)
            {
                Reset();
                mC.GeneretStaticMap(this.sr);
                mS.GenerateView();
            }
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            //starts operation
            this.timer.Start();

        }

        public void RemoveLabel(Squere squere)
        {
            this.panelMaze.Controls.Remove(squere.Label);

        }

        public void AddLabel(Squere squere)
        {
            this.panelMaze.Controls.Add(squere.Label);
        }

        private int counter = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.panelMaze.Controls.Count > 0)
            {
                counter++;
                this.labelSteps.Text = counter.ToString();

                if (counter == 10000 || mC.Start())
                {

                    timer.Stop();
                    if (mC.deciders.Count > 1)
                    {
                        MessageBox.Show("Destination reached!");
                    }
                    else
                    {
                        MessageBox.Show("Destination unreachable!");
                    }

                }
            }

        }

        private void timerGen_Tick(object sender, EventArgs e)
        {
            if (this.panelMaze.Controls.Count > 0)
            {
                counter++;

                if (counter == 10000 || mRG.Start())
                {

                    timerGen.Stop();

                    MessageBox.Show("Done!");

                    mC.GenEndStart();
                    //mS.StartEndView(mC.Field[mC.startPoint.X,mC.startPoint.Y], mC.Field[mC.endPoint.X, mC.endPoint.Y]);
                    counter = 0;

                    for (int i = 0; i < mC.Field.GetLength(0); i++)
                    {
                        for (int j = 0; j < mC.Field.GetLength(1); j++)
                        {

                            if (mC.Field[i, j].TypesOfSquere == TypesOfSqueres.Exceeded)
                            {
                                mC.Field[i, j].TypesOfSquere = TypesOfSqueres.Nothing;
                            }
                        }
                    }
                    //mC.startPoint = mRG.PickedStart(null); --> posíla na [0,0]

                }
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            int power = 0;
            if (this.trackBar.Value < 3)
            {
                power = 10;
            }
            else if (this.trackBar.Value > 18)
            {
                power = 100;
            }
            else
            {
                power = 50;
            }
            this.timer.Interval = Convert.ToInt32(this.trackBar.Value) * power;
            this.timerGen.Interval = Convert.ToInt32(this.trackBar.Value) * power;
        }

        private void buttonChooseMap_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            if (this.sr != null)
            {
                sr.Close();
            }
            try
            {
                string path = openFileDialog.FileName;
                this.sr = new StreamReader(path);
                this.textBoxPath.Text = path;
            }
            catch
            {
                this.sr = null;
            }

        }

        private void buttonStartPick_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
            mS.ClickChange = TypesOfSqueres.Start;
        }

        private void buttonEndPick_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
            mS.ClickChange = TypesOfSqueres.Finish;
        }

        private void buttonPlaceWall_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
            mS.ClickChange = TypesOfSqueres.Wall;
        }


        private void buttonDeleteSquere_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
            mS.ClickChange = TypesOfSqueres.Space;
        }


        private void panelMaze_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

        }

        private void buttonRndStart_Click(object sender, EventArgs e)
        {
            ChangeSquere(TypesOfSqueres.Start, true);
        }

        private void buttonChangeEnd_Click(object sender, EventArgs e)
        {
            ChangeSquere(TypesOfSqueres.Finish, true);
        }

        public void ChangeSquere(TypesOfSqueres typesOfSqueres, bool isRandom)
        {
            for (int i = 0; i < mC.Field.GetLength(0); i++)
            {
                for (int j = 0; j < mC.Field.GetLength(1); j++)
                {
                    if (mC.Field[i, j].TypesOfSquere == typesOfSqueres)
                    {
                        mC.Field[i, j].Label.BackColor = Color.White;
                        mC.Field[i, j].TypesOfSquere = TypesOfSqueres.Space;
                    }

                }
            }
            if (isRandom)
            {
                ChangeToRandom(typesOfSqueres);
            }

        }

        private void ChangeToRandom(TypesOfSqueres typesOfSqueres)
        {
            Point point = new Point();
            do
            {
                point.X = rnd.Next(1, 28);
                point.Y = rnd.Next(1, 28);
            }
            while (mC.Field[point.X, point.Y].TypesOfSquere == TypesOfSqueres.Wall);

            if (typesOfSqueres == TypesOfSqueres.Start)
            {
                mC.Field[point.X, point.Y].Label.BackColor = Color.Red;
                mC.Field[point.X, point.Y].TypesOfSquere = TypesOfSqueres.Start;
                mC.startPoint = point;
                mC.deciders.RemoveAt(0);
                mC.deciders.Add(new Decider(point, point));
            }
            else if (typesOfSqueres == TypesOfSqueres.Finish)
            {
                mC.Field[point.X, point.Y].Label.BackColor = Color.Green;
                mC.Field[point.X, point.Y].TypesOfSquere = TypesOfSqueres.Finish;
                mC.endPoint = point;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (mC != null)
            {
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory);
                    dir = dir.Parent.Parent.Parent;


                    dir = dir.GetDirectories("Maps")[0];

                    FileInfo lastMap = dir.GetFiles()[dir.GetFiles().Length - 1];
                    int mapNumber = Convert.ToInt32(lastMap.Name[3].ToString());
                    mapNumber++;
                    string path = dir + "\\map" + (mapNumber++) + ".txt";

                    File.Create(path).Close();
                    StreamWriter sw = new StreamWriter(path);
                    MessageBox.Show(dir.Parent + "\\map" + (mapNumber++));


                    for (int i = 0; i < mC.Field.GetLength(0); i++)
                    {
                        for (int j = 0; j < mC.Field.GetLength(1); j++)
                        {
                            switch (mC.Field[i, j].TypesOfSquere)
                            {
                                case TypesOfSqueres.Wall:
                                    sw.Write("-");
                                    break;
                                case TypesOfSqueres.Start:
                                    sw.Write("s");
                                    break;
                                case TypesOfSqueres.Finish:
                                    sw.Write("e");
                                    break;
                                default:
                                    sw.Write("*");
                                    break;
                            }
                        }
                        sw.WriteLine();
                    }
                    sw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }


        }
    }
}