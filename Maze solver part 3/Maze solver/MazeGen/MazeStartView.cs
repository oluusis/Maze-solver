using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Maze_solver.Emums;

namespace Maze_solver.MazeGen
{
    public class MazeStartView
    {
        private int _countX;
        private int _countY;
        private Form _form;
        private Squere[,] _field;
        private MazeCreation mC;

        public MazeStartView(Form form, MazeCreation mC)
        {
            _countX = 0;
            _countY = 0;
            _form = form;
            _field = mC.Field;
            this.mC = mC;
            ClickChange = TypesOfSqueres.Nothing;
        }


        public TypesOfSqueres ClickChange { get; set; }

        public void Label_Clicked(object sender, EventArgs e)
        {
            if(ClickChange != TypesOfSqueres.Nothing)
            {
                Label label = sender as Label;

                if (label != null && label.BackColor != Color.Green && label.BackColor != Color.Red)
                {
                    switch (ClickChange)
                    {
                        case TypesOfSqueres.Wall:
                            label.BackColor = Color.Black;
                            break;

                        case TypesOfSqueres.Start:
                            label.BackColor = Color.Red;
                            break;

                        case TypesOfSqueres.Finish:
                            label.BackColor = Color.Green;                          
                            break;

                        case TypesOfSqueres.Space:
                            label.BackColor = Color.White;
                            break;
                    }
                    if(ClickChange != TypesOfSqueres.Wall)
                    {
                        _form.ChangeSquere(ClickChange, false);
                    }
                    

                    for (int i = 0; i < _field.GetLength(0); i++)
                    {
                        for (int j = 0; j < _field.GetLength(1); j++)
                        {
                            if(_field[i,j].Label.BackColor == label.BackColor && _field[i, j].TypesOfSquere != ClickChange)
                            {
                                _field[i, j].TypesOfSquere = ClickChange;

                                if(ClickChange == TypesOfSqueres.Start)
                                {
                                    mC.startPoint = _field[i, j].pozicion;
                                    mC.deciders.RemoveAt(0);
                                    mC.deciders.Add(new Decider(_field[i, j].pozicion, _field[i, j].pozicion));
                                }
                                else if (ClickChange == TypesOfSqueres.Finish)
                                {
                                    mC.endPoint = _field[i, j].pozicion;
                                }

                              
                            }
                        }
                    }

                }
           
            }
            ClickChange = TypesOfSqueres.Nothing;
            this._form.Cursor = Cursors.Default;
        }

        public void GenerateView()
        {
            for (int i = 0; i < _field.GetLength(0); i++)
            {
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    _form.panelMaze.Controls.Add(_field[i, j].Label);


                    switch (_field[i, j].TypesOfSquere)
                    {
                        case TypesOfSqueres.Wall:
                            _field[i, j].Label.BackColor = Color.Black;
                            break;
                        case TypesOfSqueres.Start:
                            _field[i, j].Label.BackColor = Color.Red;
                            break;
                        case TypesOfSqueres.Finish:
                            _field[i, j].Label.BackColor = Color.Green;
                            break;
                        case TypesOfSqueres.Space:
                            _field[i, j].Label.BackColor = Color.White;
                            break;
                        case TypesOfSqueres.Exceeded:
                            _field[i, j].Label.BackColor = Color.Blue;
                            break;
                        
                    }


                    _field[i, j].Label.Location = new System.Drawing.Point(_countX, _countY);
                    _field[i, j].Label.Name = "labelP";
                    _field[i, j].Label.Size = new Size(20, 20);
                    _field[i, j].Label.TabIndex = 0;
                    _field[i, j].Label.Click += Label_Clicked;

                    _countX += 20;

                }
                _countX = 0;
                _countY += 20;
            }
            _countX = 0;
            _countY = 0;

        }
    }
}
