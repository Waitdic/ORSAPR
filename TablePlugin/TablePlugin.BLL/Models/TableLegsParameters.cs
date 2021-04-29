using System;
using TablePlugin.BLL.Enums;

namespace TablePlugin.BLL.Models
{
    /// <summary>
    /// Параметры ножек стола.
    /// </summary>
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
                ValidateToDoubleValue(value, "Высота ножек");
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
                ValidateToDoubleValue(value, "Количество ножек");
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
                ValidateToDoubleValue(value, "Размер основания");
                _value = value;
            } 
        }

        /// <summary>
        /// Проверка присваиваемого значения на double.
        /// </summary>
        /// <param name="value">Присваиваемая переменная.</param>
        /// <param name="name">Имя параметра.</param>
        private static void ValidateToDoubleValue(double value, string name)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException("Значение не является числом типа double");
            }
            
            if (value <= 0)
            {
                throw new ArgumentException($"{name} не может быть меньше или равна нулю!");
            }
        }
    }
}
