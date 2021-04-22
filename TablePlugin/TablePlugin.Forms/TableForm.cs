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
        public TableForm()
        {
            InitializeComponent();
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            if (tableTopLength.Value < 1000)
            {
                tableTopLength.BackColor = Color.LightCoral;
                MessageBox.Show("Неверное значение поля! Допустимый диапазон от 1000 до 2000");
            }

            var parameters = new TableParameters
            {
                TableTop = new TableTopParameters(
                    (double)tableTopLength.Value, 
                    (double) tableTopWidth.Value,
                    (double) tableTopHeight.Value)
            };

            if (this.CheckHole.Checked)
            {
                //parameters.TableHole = new TableHoleParameters(
                //    (double)holeRadius.Value, 
                //    (double)holeRadius.Value, 
                //    (double)holeParamY.Value);
            }

            parameters.TabLegs = new TableLegsParameters(
                (int)tableLegsNumber.Value,
                (double)tableLegsHeight.Value,
                // RoundLegsRadioButton.Checked ? LegsType.RoundLegs : LegsType.SquareLegs,
                LegsType.SquareLegs,
                (double)SizeValue.Value);

            var builder = new TableBuilder();
            builder.Build(parameters);
        }

        private void CheckHole_CheckedChanged(object sender, EventArgs e)
        {
            //if (this.CheckHole.Checked)
            //{
            //    groupBox3.Visible = true;
            //    this.holeParamX.ReadOnly = false;
            //    this.holeParamY.ReadOnly = false;
            //    this.holeRadius.ReadOnly = false;
            //}
            //else
            //{
            //    groupBox3.Visible = false;
            //    groupBox3.
            //    this.holeParamX.ReadOnly = true;
            //    this.holeParamY.ReadOnly = true;
            //    this.holeRadius.ReadOnly = true;
            //}
        }

        private void RoundLegsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //if (!this.RoundLegsRadioButton.Checked)
            //{
            //    return;
            //}

            //this.NameOfSize.Text = "Диаметр основания";
        }

        private void SquareLegsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
        //    if (!this.SquareLegsRadioButton.Checked)
        //    {
        //        return;
        //    }
     
        //    this.NameOfSize.Text = "Длина стороны основания";
        }

        private void SetMinButton_Click(object sender, EventArgs e)
        {

        }

        private void SetMaxButton_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBox1.SelectedIndex)
            {
                case 0: // параметры для демонстрации (по умолчанию)
                    this.NameOfSize.Text = "Диаметр основания";
                    break;
                case 1: // выбор минимальных параметров
                    this.NameOfSize.Text = "Длина стороны основания";
                    break;
            }
        }
    }
}
