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
                ValidateValue(value, "Высота ножек");
                _height = Math.Truncate(value);
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
                ValidateValue(value, "Количество ножек");
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
                ValidateValue(value, "Размер основания");
                _value = Math.Truncate(value);
            } 
        }

        /// <summary>
        /// Проверка присваиваемого значения на double.
        /// </summary>
        /// <param name="value">Присваиваемая переменная.</param>
        /// <param name="name">Имя параметра.</param>
        private static void ValidateValue(double value, string name)
        {
            //if (double.IsNaN(value) || double.IsInfinity(value))
            //{
            //    throw new ArgumentException("Значение не является числом типа double");
            //}

            if (Math.Abs(value - Math.Truncate(value)) > 0.001d)
            {
                throw new ArgumentException($"Значение поля '{name}' не может быть дробным");
            }
            
            if (value <= 0)
            {
                throw new ArgumentException($"{name} не может быть меньше или равна нулю!");
            }
        }
    }
}
