using System;

namespace TablePlugin.BLL.Models
{
    /// <summary>
    /// Параметры столешницы.
    /// </summary>
    public struct TableTopParameters
    {
        private double _length;
        private double _width;
        private double _height;

        /// <summary>
        /// Длина столешницы.
        /// </summary>
        public double Length
        {
            get => _length;
            set
            {
                ValidateToDoubleValue(value);
                _length = value;
            }
        }

        /// <summary>
        /// Ширина столешницы.
        /// </summary>
        public double Width
        {
            get => _width;
            set
            {
                ValidateToDoubleValue(value);
                _width = value;
            }
        }

        /// <summary>
        /// Высота столешницы.
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
        /// Проверка присваиваемого значения на double.
        /// </summary>
        /// <param name="value">Присваиваемая переменная.</param>
        private static void ValidateToDoubleValue(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException("Значение double не является числом");
            }
            else if (value <= 0)
            {
                throw new ArgumentException("Значение double меньше или равно нулю");
            }
        }
    } 
}
