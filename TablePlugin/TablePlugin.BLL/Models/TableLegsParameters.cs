using System;
using TablePlugin.BLL.Enums;

namespace TablePlugin.BLL.Models
{
    public struct TableLegsParameters
    {
        private int _number;
        private double _height;
        private double _value;

        /// <summary>
        /// Высота ножек.
        /// </summary>
        public double Height
        {
            get => _height;
            set
            {
                ValidateToDoubleValue(value);
                _height = value;
            }
        }

        /// <summary>
        /// Количество ножек.
        /// </summary>
        public int Number
        {
            get => _number;
            set
            {
                ValidateToDoubleValue(value);
                _number = value;
            }
        }

        /// <summary>
        /// Тип ножек.
        /// </summary>
        public LegsType Type { get; set; }

        /// <summary>
        /// Значние размера основания ножек.
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                ValidateToDoubleValue(value);
                _value = value;
            } 
        }

        /// <summary>
        /// Проверка присваиваемого значения на double.
        /// </summary>
        /// <param name="value">Присваиваемая переменная.</param>
        private static void ValidateToDoubleValue(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException("Значение double не является числом");
            }
            
            if (value <= 0)
            {
                throw new ArgumentException("Значение double меньше или равно нулю");
            }
        }
    }
}
