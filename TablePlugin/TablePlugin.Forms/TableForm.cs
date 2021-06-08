using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TablePlugin.BLL;
using TablePlugin.BLL.Enums;
using TablePlugin.BLL.Models;

namespace TablePlugin.Forms
{
    /// <summary>
    /// Класс для работы с формой (главным окном) плагина.
    /// </summary>
    public partial class TableForm : Form
    {
        /// <summary>
        /// Объект для построения 3D Модели.
        /// </summary>
        private Builder _builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableForm"/> class.
        /// </summary
        public TableForm()
        {
            InitializeComponent();
            ChangeFormLocation(true);
            ChangeBoxVisible(true);
            LegsTypeComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Обработчик кнопки "Построить 3D модель".
        /// </summary>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            var parameters = new TableParameters();
            try
            {
                if (checkBox.Checked)
                {
                    parameters.TableBoxNumber = (int) BoxNumber.Value;
                }
                
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
                    Type = LegsTypeComboBox.SelectedIndex == 0 
                        ? LegsType.RoundLegs 
                        : LegsType.SquareLegs,
                    Value = (double) SizeValue.Value
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

                _builder = _builder ?? new Builder();
                _builder.Build(parameters);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Обработчик чекбокса "Скозное отверстие".
        /// </summary>
        private void CheckHole_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFormLocation(!checkHole.Checked);   
            holeGroupBox.Visible = checkHole.Checked;
        }

        /// <summary>
        /// Обработчик комбобокса "Тип ножек"
        /// </summary>
        private void LegsTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (LegsTypeComboBox.SelectedIndex)
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
            var changedSize = (holeGroupBox.Size.Height + 15);
            if (turnOff)
            {
                ledsGroupBox.Location = new Point(
                    ledsGroupBox.Location.X, 
                    ledsGroupBox.Location.Y - changedSize);
                
                buttonGroupBox.Location = new Point(
                    buttonGroupBox.Location.X, 
                    buttonGroupBox.Location.Y - changedSize);
                
                BuildButton.Location = new Point(
                    BuildButton.Location.X, 
                    BuildButton.Location.Y - changedSize);
                
                Size = new Size(
                    Size.Width, 
                    Size.Height - changedSize);
            }
            else
            {
                ledsGroupBox.Location = new Point(
                    ledsGroupBox.Location.X, 
                    ledsGroupBox.Location.Y + changedSize);
                
                buttonGroupBox.Location = new Point(
                    buttonGroupBox.Location.X, 
                    buttonGroupBox.Location.Y + changedSize);
                
                BuildButton.Location = new Point(
                    BuildButton.Location.X, 
                    BuildButton.Location.Y + changedSize);
                
                Size = new Size(
                    Size.Width, 
                    Size.Height + changedSize);
            }
        }

        /// <summary>
        /// Обработчик кнопки "Минимумы".
        /// </summary>
        private void SetMinButton_Click(object sender, EventArgs e)
        {
            SetMinMaxParameters(x => x.Value.Min);
        }

        /// <summary>
        /// Обработчик кнопки "Максимумы".
        /// </summary>
        private void SetMaxButton_Click(object sender, EventArgs e)
        {
            SetMinMaxParameters(x => x.Value.Max);
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
        /// Метод для добавления выдвижных ящиков.
        /// </summary>
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            ChangeBoxVisible(!checkBox.Checked);
        }

        /// <summary>
        /// Метод для визуализации полей шкафчика.
        /// </summary>
        /// <param name="turnOff">Выключить видимость.</param>
        private void ChangeBoxVisible(bool turnOff)
        {
            BoxNumber.Visible = !turnOff;
            label20.Visible = !turnOff;
            label19.Visible = !turnOff;
        }

        /// <summary>
        /// Метод для установки значений минимума и максимума для полей формы.
        /// </summary>
        /// <param name="expression">Лямбда-выражение.</param>
        private void SetMinMaxParameters(Func<KeyValuePair<
            ParametersType,
            AdditionalParameters>,
            double> expression)
        {
            var parameters = new TableParameters();

            tableTopLength.Value = parameters.SetMinMaxParameters(
                expression, 
                ParametersType.TableTopLength);
            
            tableTopWidth.Value = parameters.SetMinMaxParameters(
                expression, 
                ParametersType.TableTopWidth);
            
            tableTopHeight.Value = parameters.SetMinMaxParameters(
                expression, 
                ParametersType.TableTopHeight);
            
            holeRadius.Value = parameters.SetMinMaxParameters(
                expression, 
                ParametersType.HoleRadius);
            
            holeParamX.Value = parameters.SetMinMaxParameters(
                expression, 
                ParametersType.HoleParamX);
            
            holeParamY.Value = parameters.SetMinMaxParameters(
                expression, 
                ParametersType.HoleParamY);
            
            tableLegsHeight.Value = parameters.SetMinMaxParameters(
                expression, 
                ParametersType.TableLegsHeight);
            
            tableLegsNumber.Value = checkBox.Checked 
                ? 4
                : parameters.SetMinMaxParameters(
                expression,
                ParametersType.TableLegsNumber);

            BoxNumber.Value = parameters.SetMinMaxParameters(
                expression,
                ParametersType.TableBox);

            SizeValue.Value = LegsTypeComboBox.SelectedIndex == 0
                ? parameters.SetMinMaxParameters(
                    expression,
                    ParametersType.TableLegsDiameter)
                : parameters.SetMinMaxParameters(
                    expression, 
                    ParametersType.TableLegsSideLength);
        }
    }
}
