using Maze_solver.MazeGen;
using System.Diagnostics;
using System.Windows.Forms;

namespace Maze_solver
{
    public partial class Form : System.Windows.Forms.Form
    {
        private MazeStartView mS;
        private MazeCreation mC;

        private StreamReader sr;

        public Form()
        {
            InitializeComponent();
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

            mC.GenRndStart();

            mS.GenerateView();
        }

        private void buttonGenFromFile_Click(object sender, EventArgs e)
        {
            if(this.sr != null)
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
            if(this.panelMaze.Controls.Count > 0)
            {
                counter++;
                this.labelSteps.Text = counter.ToString();

                if (counter == 10000 || mC.Start())
                {
                    timer.Stop();
                    MessageBox.Show("Destination reached!");
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
        }

        private void buttonChooseMap_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            if(this.sr != null)
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


    }
}