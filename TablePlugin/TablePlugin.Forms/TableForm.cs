using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TablePlugin.BLL;
using TablePlugin.BLL.Enums;
using TablePlugin.BLL.Models;

namespace TablePlugin.Forms
{
    public partial class TableForm : Form
    {
        private TableBuilder _builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableForm"/> class.
        /// </summary
        public TableForm()
        {
            InitializeComponent();
            ChangeFormLocation(true);
            legsType.SelectedIndex = 0;
        }

        /// <summary>
        /// Обработчик кнопки "Построить 3D модель".
        /// </summary>
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
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            _builder = _builder ?? new TableBuilder();
            _builder.Build(parameters);
        }

        /// <summary>
        /// Обработчик чекбокса "Скозное отверстие".
        /// </summary>
        private void CheckHole_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFormLocation(!checkHole.Checked);   
            groupBox3.Visible = checkHole.Checked;
        }

        /// <summary>
        /// Обработчик комбобокса "Тип ножек"
        /// </summary>
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

        /// <summary>
        /// Обработчик кнопки "Минимумы".
        /// </summary>
        private void SetMinButton_Click(object sender, EventArgs e)
        {
            SetMinMaxParameters(x => x.Min);
        }

        /// <summary>
        /// Обработчик кнопки "Максимумы".
        /// </summary>
        private void SetMaxButton_Click(object sender, EventArgs e)
        {
            SetMinMaxParameters(x => x.Max);
        }

        /// <summary>
        /// Обработчик кнопки "По умолчанию".
        /// </summary>
        private void DefaultButton_Click(object sender, EventArgs e)
        {
            tableTopLength.Value = 1500m;
            tableTopWidth.Value = 700m;
            tableTopHeight.Value = 35m;

            holeRadius.Value = 25m;
            holeParamX.Value = 900m;
            holeParamY.Value = 400m;

            tableLegsHeight.Value = 650m;
            tableLegsNumber.Value = 4m;
            SizeValue.Value = 50m;
        }

        /// <summary>
        /// Метод для установки значений минимума и максимума для полей формы.
        /// </summary>
        /// <param name="predicate">Предикат.</param>
        private void SetMinMaxParameters(Func<AdditionalParameters, double> predicate)
        {
            var parameters = new TableParameters();
            var limits = parameters.AdditionalParameters;

            tableTopLength.Value = (decimal)limits.Where(x => x.LogicalName == ParametersType.TableTopLength).Select(predicate).FirstOrDefault();
            tableTopWidth.Value = (decimal)limits.Where(x => x.LogicalName == ParametersType.TableTopWidth).Select(predicate).FirstOrDefault();
            tableTopHeight.Value = (decimal)limits.Where(x => x.LogicalName == ParametersType.TableTopHeight).Select(predicate).FirstOrDefault();

            holeRadius.Value = (decimal)limits.Where(x => x.LogicalName == ParametersType.HoleRadius).Select(predicate).FirstOrDefault();
            holeParamX.Value = (decimal)limits.Where(x => x.LogicalName == ParametersType.HoleParamX).Select(predicate).FirstOrDefault();
            holeParamY.Value = (decimal)limits.Where(x => x.LogicalName == ParametersType.HoleParamY).Select(predicate).FirstOrDefault();

            tableLegsHeight.Value = (decimal)limits.Where(x => x.LogicalName == ParametersType.TableLegsHeight).Select(predicate).FirstOrDefault();
            tableLegsNumber.Value = (decimal)limits.Where(x => x.LogicalName == ParametersType.TableLegsNumber).Select(predicate).FirstOrDefault();
            SizeValue.Value = legsType.SelectedIndex == 0
                ? (decimal)limits.Where(x => x.LogicalName == ParametersType.TableLegsDiameter).Select(predicate).FirstOrDefault()
                : (decimal)limits.Where(x => x.LogicalName == ParametersType.TableLegsSideLength).Select(predicate).FirstOrDefault();
        }
    }
}
