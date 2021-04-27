using System;
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
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            var parameters = new TableParameters
            {
                TableTop = new TableTopParameters
                {
                    Length = (double) tableTopLength.Value,
                    Width = (double) tableTopWidth.Value,
                    Height = (double) tableTopHeight.Value
                },

                TabLegs = new TableLegsParameters
                {
                    Height = (double) tableLegsHeight.Value,
                    Number = (int) tableLegsNumber.Value,
                    Type = legsType.SelectedIndex == 0 ? LegsType.RoundLegs : LegsType.SquareLegs,
                    Value = (double) SizeValue.Value
                },
            };

            if (checkHole.Checked)
            {
                parameters.TableHole = new TableHoleParameters
                {
                    Radius = (double) holeRadius.Value,
                    ParamX = (double) holeParamX.Value,
                    ParamY = (double) holeParamY.Value
                };
            }

            if (_builder == null)
            {
                _builder = new TableBuilder();
            }

            _builder.Build(parameters);
        }

        private void CheckHole_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Visible = checkHole.Checked;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
    }
}
