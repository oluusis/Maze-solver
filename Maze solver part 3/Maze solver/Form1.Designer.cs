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
            buttonPlaceWall = new Button();
            buttonSave = new Button();
            labelName = new Label();
            buttonChangeEnd = new Button();
            buttonRndStart = new Button();
            buttonEndPick = new Button();
            buttonStartPick = new Button();
            buttonGenFromFile = new Button();
            textBoxPath = new TextBox();
            label3 = new Label();
            buttonChooseMap = new Button();
            trackBar = new TrackBar();
            label2 = new Label();
            labelSteps = new Label();
            label1 = new Label();
            buttonSolve = new Button();
            timer = new System.Windows.Forms.Timer(components);
            openFileDialog = new OpenFileDialog();
            timerGen = new System.Windows.Forms.Timer(components);
            buttonDeleteSquere = new Button();
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
            panelMaze.Click += panelMaze_Click;
            // 
            // buttonGenerateMaze
            // 
            buttonGenerateMaze.Location = new System.Drawing.Point(13, 60);
            buttonGenerateMaze.Name = "buttonGenerateMaze";
            buttonGenerateMaze.Size = new Size(83, 48);
            buttonGenerateMaze.TabIndex = 1;
            buttonGenerateMaze.Text = "Generate random";
            buttonGenerateMaze.UseVisualStyleBackColor = true;
            buttonGenerateMaze.Click += buttonGenerateMaze_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonDeleteSquere);
            panel1.Controls.Add(buttonPlaceWall);
            panel1.Controls.Add(buttonSave);
            panel1.Controls.Add(labelName);
            panel1.Controls.Add(buttonChangeEnd);
            panel1.Controls.Add(buttonRndStart);
            panel1.Controls.Add(buttonEndPick);
            panel1.Controls.Add(buttonStartPick);
            panel1.Controls.Add(buttonGenFromFile);
            panel1.Controls.Add(textBoxPath);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(buttonChooseMap);
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
            // buttonPlaceWall
            // 
            buttonPlaceWall.Location = new System.Drawing.Point(15, 364);
            buttonPlaceWall.Name = "buttonPlaceWall";
            buttonPlaceWall.Size = new Size(83, 48);
            buttonPlaceWall.TabIndex = 15;
            buttonPlaceWall.Text = "Place wall";
            buttonPlaceWall.UseVisualStyleBackColor = true;
            buttonPlaceWall.Click += buttonPlaceWall_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new System.Drawing.Point(13, 296);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(168, 36);
            buttonSave.TabIndex = 14;
            buttonSave.Text = "Save map to file";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Showcard Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelName.Location = new System.Drawing.Point(5, 14);
            labelName.Name = "labelName";
            labelName.Size = new Size(190, 33);
            labelName.TabIndex = 13;
            labelName.Text = "Maze Solver";
            // 
            // buttonChangeEnd
            // 
            buttonChangeEnd.Location = new System.Drawing.Point(102, 472);
            buttonChangeEnd.Name = "buttonChangeEnd";
            buttonChangeEnd.Size = new Size(83, 48);
            buttonChangeEnd.TabIndex = 12;
            buttonChangeEnd.Text = "Change end";
            buttonChangeEnd.UseVisualStyleBackColor = true;
            buttonChangeEnd.Click += buttonChangeEnd_Click;
            // 
            // buttonRndStart
            // 
            buttonRndStart.Location = new System.Drawing.Point(13, 472);
            buttonRndStart.Name = "buttonRndStart";
            buttonRndStart.Size = new Size(83, 48);
            buttonRndStart.TabIndex = 12;
            buttonRndStart.Text = "Change start";
            buttonRndStart.UseVisualStyleBackColor = true;
            buttonRndStart.Click += buttonRndStart_Click;
            // 
            // buttonEndPick
            // 
            buttonEndPick.Location = new System.Drawing.Point(15, 418);
            buttonEndPick.Name = "buttonEndPick";
            buttonEndPick.Size = new Size(83, 48);
            buttonEndPick.TabIndex = 11;
            buttonEndPick.Text = "Pick end";
            buttonEndPick.UseVisualStyleBackColor = true;
            buttonEndPick.Click += buttonEndPick_Click;
            // 
            // buttonStartPick
            // 
            buttonStartPick.Location = new System.Drawing.Point(102, 418);
            buttonStartPick.Name = "buttonStartPick";
            buttonStartPick.Size = new Size(83, 48);
            buttonStartPick.TabIndex = 11;
            buttonStartPick.Text = "Pick start";
            buttonStartPick.UseVisualStyleBackColor = true;
            buttonStartPick.Click += buttonStartPick_Click;
            // 
            // buttonGenFromFile
            // 
            buttonGenFromFile.Location = new System.Drawing.Point(102, 60);
            buttonGenFromFile.Name = "buttonGenFromFile";
            buttonGenFromFile.Size = new Size(83, 48);
            buttonGenFromFile.TabIndex = 10;
            buttonGenFromFile.Text = "Generate from file";
            buttonGenFromFile.UseVisualStyleBackColor = true;
            buttonGenFromFile.Click += buttonGenFromFile_Click;
            // 
            // textBoxPath
            // 
            textBoxPath.Location = new System.Drawing.Point(13, 223);
            textBoxPath.Name = "textBoxPath";
            textBoxPath.Size = new Size(168, 23);
            textBoxPath.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(13, 205);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 8;
            label3.Text = "Path: ";
            // 
            // buttonChooseMap
            // 
            buttonChooseMap.Location = new System.Drawing.Point(100, 252);
            buttonChooseMap.Name = "buttonChooseMap";
            buttonChooseMap.Size = new Size(81, 26);
            buttonChooseMap.TabIndex = 7;
            buttonChooseMap.Text = "Choose map";
            buttonChooseMap.UseVisualStyleBackColor = true;
            buttonChooseMap.Click += buttonChooseMap_Click;
            // 
            // trackBar
            // 
            trackBar.Location = new System.Drawing.Point(58, 149);
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
            label2.Location = new System.Drawing.Point(13, 159);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 5;
            label2.Text = "Speed";
            // 
            // labelSteps
            // 
            labelSteps.AutoEllipsis = true;
            labelSteps.AutoSize = true;
            labelSteps.Location = new System.Drawing.Point(142, 121);
            labelSteps.Name = "labelSteps";
            labelSteps.Size = new Size(13, 15);
            labelSteps.TabIndex = 4;
            labelSteps.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 121);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 3;
            label1.Text = "Number of steps: ";
            // 
            // buttonSolve
            // 
            buttonSolve.BackColor = Color.DarkGreen;
            buttonSolve.BackgroundImageLayout = ImageLayout.Center;
            buttonSolve.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSolve.Location = new System.Drawing.Point(13, 549);
            buttonSolve.Name = "buttonSolve";
            buttonSolve.Size = new Size(172, 48);
            buttonSolve.TabIndex = 2;
            buttonSolve.Text = "Solve";
            buttonSolve.UseVisualStyleBackColor = false;
            buttonSolve.Click += buttonSolve_Click;
            // 
            // timer
            // 
            timer.Interval = 500;
            timer.Tick += timer_Tick;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // timerGen
            // 
            timerGen.Interval = 500;
            timerGen.Tick += timerGen_Tick;
            // 
            // buttonDeleteSquere
            // 
            buttonDeleteSquere.Location = new System.Drawing.Point(102, 364);
            buttonDeleteSquere.Name = "buttonDeleteSquere";
            buttonDeleteSquere.Size = new Size(83, 48);
            buttonDeleteSquere.TabIndex = 16;
            buttonDeleteSquere.Text = "Delete item";
            buttonDeleteSquere.UseVisualStyleBackColor = true;
            buttonDeleteSquere.Click += buttonDeleteSquere_Click;
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
        private TextBox textBoxPath;
        private Label label3;
        private Button buttonChooseMap;
        private OpenFileDialog openFileDialog;
        private Button buttonGenFromFile;
        public System.Windows.Forms.Timer timerGen;
        private Button buttonStartPick;
        private Button buttonEndPick;
        private Button buttonChangeEnd;
        private Button buttonRndStart;
        private Label labelName;
        private Button buttonSave;
        private Button buttonPlaceWall;
        private Button buttonDeleteSquere;
    }
}