namespace Maze_solver
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelMaze = new Panel();
            buttonGenerateMaze = new Button();
            panel1 = new Panel();
            trackBar = new TrackBar();
            label2 = new Label();
            labelSteps = new Label();
            label1 = new Label();
            buttonSolve = new Button();
            timer = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar).BeginInit();
            SuspendLayout();
            // 
            // panelMaze
            // 
            panelMaze.BackColor = Color.White;
            panelMaze.Location = new System.Drawing.Point(12, 12);
            panelMaze.Name = "panelMaze";
            panelMaze.Size = new Size(600, 600);
            panelMaze.TabIndex = 0;
            // 
            // buttonGenerateMaze
            // 
            buttonGenerateMaze.Location = new System.Drawing.Point(13, 16);
            buttonGenerateMaze.Name = "buttonGenerateMaze";
            buttonGenerateMaze.Size = new Size(83, 48);
            buttonGenerateMaze.TabIndex = 1;
            buttonGenerateMaze.Text = "Generate Maze";
            buttonGenerateMaze.UseVisualStyleBackColor = true;
            buttonGenerateMaze.Click += buttonGenerateMaze_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(trackBar);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(labelSteps);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(buttonSolve);
            panel1.Controls.Add(buttonGenerateMaze);
            panel1.Location = new System.Drawing.Point(618, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(198, 600);
            panel1.TabIndex = 2;
            // 
            // trackBar
            // 
            trackBar.Location = new System.Drawing.Point(58, 105);
            trackBar.Maximum = 20;
            trackBar.Minimum = 1;
            trackBar.Name = "trackBar";
            trackBar.Size = new Size(127, 45);
            trackBar.TabIndex = 6;
            trackBar.Value = 10;
            trackBar.Scroll += trackBar_Scroll;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(13, 115);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 5;
            label2.Text = "Speed";
            // 
            // labelSteps
            // 
            labelSteps.AutoEllipsis = true;
            labelSteps.AutoSize = true;
            labelSteps.Location = new System.Drawing.Point(142, 77);
            labelSteps.Name = "labelSteps";
            labelSteps.Size = new Size(13, 15);
            labelSteps.TabIndex = 4;
            labelSteps.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 77);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 3;
            label1.Text = "Number of steps: ";
            // 
            // buttonSolve
            // 
            buttonSolve.Location = new System.Drawing.Point(102, 16);
            buttonSolve.Name = "buttonSolve";
            buttonSolve.Size = new Size(83, 48);
            buttonSolve.TabIndex = 2;
            buttonSolve.Text = "Solve";
            buttonSolve.UseVisualStyleBackColor = true;
            buttonSolve.Click += buttonSolve_Click;
            // 
            // timer
            // 
            timer.Interval = 500;
            timer.Tick += timer_Tick;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 621);
            Controls.Add(panel1);
            Controls.Add(panelMaze);
            Name = "Form";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar).EndInit();
            ResumeLayout(false);
        }

        #endregion
        public Panel panelMaze;
        private Button buttonGenerateMaze;
        private Panel panel1;
        private Button buttonSolve;
        public System.Windows.Forms.Timer timer;
        private Label labelSteps;
        private Label label1;
        private TrackBar trackBar;
        private Label label2;
    }
}