using System;
using System.Windows.Forms;
using TablePlugin.BLL;
using TablePlugin.BLL.Enums;
using TablePlugin.BLL.Models;

namespace TablePlugin.Forms
{
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            var parameters = new TableParameters
            {
                TableTopLength = (double) this.tableTopLength.Value,
                TableTopWidth = (double) this.tableTopWidth.Value,
                TableTopHeight = (double) this.tableTopHeight.Value,
                TableLegsHeight = (double) this.tableLegsHeight.Value,
                TableLegsNumber = (int) this.tableLegsNumber.Value,
                TableLegsType = this.RoundLegsRadioButton.Checked ? LegsType.RoundLegs : LegsType.SquareLegs
            };

            if (this.CheckHole.Checked)
            {
                parameters.HoleRadius = (double)this.holeRadius.Value;
                parameters.HoleParamX = (double)this.holeParamX.Value;
                parameters.HoleParamY = (double)this.holeParamY.Value;
            }

            if (this.RoundLegsRadioButton.Checked)
            {
                parameters.TableLegsDiameter = (double)this.tableLegsDiameter.Value;
            }

            if (this.SquareLegsRadioButton.Checked)
            {
                parameters.TableLegsSideLength = (double)this.tableLegsSideLength.Value;
            }

            var builder = new TableBuilder(new KompasConnector(), parameters);
            builder.Build();
        }

        private void CheckHole_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckHole.Checked)
            {
                this.holeParamX.ReadOnly = true;
                this.holeParamY.ReadOnly = true;
                this.holeRadius.ReadOnly = true;
            }
            else
            {
                this.holeParamX.ReadOnly = false;
                this.holeParamY.ReadOnly = false;
                this.holeRadius.ReadOnly = false;
            }
        }

        private void RoundLegsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RoundLegsRadioButton.Checked)
            {
                this.tableLegsDiameter.ReadOnly = false;
                this.tableLegsSideLength.ReadOnly = true;
            }
        }

        private void SquareLegsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SquareLegsRadioButton.Checked)
            {
                this.tableLegsSideLength.ReadOnly = false;
                this.tableLegsDiameter.ReadOnly = true;
            }
        }

        private void SetMinButton_Click(object sender, EventArgs e)
        {

        }

        private void SetMaxButton_Click(object sender, EventArgs e)
        {

        }
    }
}
