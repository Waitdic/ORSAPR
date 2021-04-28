using System;
using System.Drawing;
using System.Windows.Forms;
using TablePlugin.BLL;
using TablePlugin.BLL.Enums;
using TablePlugin.BLL.Models;

namespace TablePlugin.Forms
{
    public partial class TableForm : Form
    {
        private TableBuilder _builder;

        public TableForm()
        {
            InitializeComponent();
            ChangeFormLocation(true);
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            var parameters = new TableParameters();
            try
            {
                parameters.TableTop = new TableTopParameters
                {
                    Length = (double) tableTopLength.Value,
                    Width = (double) tableTopWidth.Value,
                    Height = (double) tableTopHeight.Value
                };

                parameters.TabLegs = new TableLegsParameters
                {
                    Height = (double) tableLegsHeight.Value,
                    Number = (int) tableLegsNumber.Value,
                    Type = legsType.SelectedIndex == 0 ? LegsType.RoundLegs : LegsType.SquareLegs,
                    Value = (double) SizeValue.Value
                };

                if (checkHole.Checked)
                {
                    parameters.TableHole = new TableHoleParameters
                    {
                        Radius = (double)holeRadius.Value,
                        ParamX = (double)holeParamX.Value,
                        ParamY = (double)holeParamY.Value
                    };
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            
            _builder = _builder ?? new TableBuilder();
            _builder.Build(parameters);
        }

        private void CheckHole_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFormLocation(!checkHole.Checked);   
            groupBox3.Visible = checkHole.Checked;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NameOfSize.Text = legsType.SelectedIndex == 0 
                ? "Диаметр основания"
                : "Длина стороны основания";

            switch (legsType.SelectedIndex)
            {
                case 0:
                    NameOfSize.Text = "Диаметр основания";
                    break;
                case 1:
                    NameOfSize.Text = "Длина стороны основания";
                    break;
            }
        }

        /// <summary>
        /// Метод для изменении верстки при скрытии groupBox.
        /// </summary>
        /// <param name="turnOff">Скрыть элемент.</param>
        private void ChangeFormLocation(bool turnOff)
        {
            var changedSize = (groupBox3.Size.Height + 15);
            if (turnOff)
            {
                groupBox2.Location = new Point(groupBox2.Location.X, groupBox2.Location.Y - changedSize);
                groupBox4.Location = new Point(groupBox4.Location.X, groupBox4.Location.Y - changedSize);
                BuildButton.Location = new Point(BuildButton.Location.X, BuildButton.Location.Y - changedSize);
                this.Size = new Size(this.Size.Width, this.Size.Height - changedSize);
            }
            else
            {
                groupBox2.Location = new Point(groupBox2.Location.X, groupBox2.Location.Y + changedSize);
                groupBox4.Location = new Point(groupBox4.Location.X, groupBox4.Location.Y + changedSize);
                BuildButton.Location = new Point(BuildButton.Location.X, BuildButton.Location.Y + changedSize);
                this.Size = new Size(this.Size.Width, this.Size.Height + changedSize);
            }
        }
    }
}
