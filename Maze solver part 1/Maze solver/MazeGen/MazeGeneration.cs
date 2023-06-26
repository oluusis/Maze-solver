using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Maze_solver.MazeGen
{
    public class MazeGeneration
    {
        private int _countX;
        private int _countY;
        private Form _form;
        private Squere[,] _field;

        public MazeGeneration(Form form, MazeCreation mC)
        {
            _countX = 0;
            _countY = 0;
            _form = form;
            _field = mC.Field;
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
