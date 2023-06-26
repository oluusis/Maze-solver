using Maze_solver.MazeGen;
using System.Diagnostics;
using System.Windows.Forms;

namespace Maze_solver
{
    public partial class Form : System.Windows.Forms.Form
    {
        private MazeGeneration mG;
        private MazeCreation mC;

        public Form()
        {
            InitializeComponent();

        }

        private void buttonGenerateMaze_Click(object sender, EventArgs e)
        {
            this.counter = 0;

            if (this.panelMaze.Controls != null)
            {
                for (int i = 0; i < 100; i++) //?? panelMaze.Controls.Count
                {
                    foreach (Control ctrl in this.panelMaze.Controls)
                    {
                        this.panelMaze.Controls.Remove(ctrl);

                    }
                }
            }

            this.mC = new MazeCreation(30, 30);
            this.mG = new MazeGeneration(this, mC);
            mC.GenStart();
            mG.GenerateView();

          

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
            counter++;
            this.labelSteps.Text = counter.ToString();

            if (counter == 10000 || mC.Generation())
            {
                timer.Stop();
                MessageBox.Show("Done!");
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
    }
}