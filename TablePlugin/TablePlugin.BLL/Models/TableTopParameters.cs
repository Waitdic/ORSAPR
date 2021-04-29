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
                ValidateToDoubleValue(value, "Длина столешницы");
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
                ValidateToDoubleValue(value, "Ширина столешницы");
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
                ValidateToDoubleValue(value, "Высота столешницы");
                _height = value;
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
                throw new ArgumentException("Значение не является числом типа double!");
            }
           
            if (value <= 0)
            {
                throw new ArgumentException($"{name} не может быть меньше или равна нулю!");
            }
        }
    } 
}
