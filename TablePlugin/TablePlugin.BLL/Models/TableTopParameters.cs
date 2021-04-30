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
                ValidateValue(value, "Длина столешницы");
                _length = Math.Truncate(value);
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
                ValidateValue(value, "Ширина столешницы");
                _width = Math.Truncate(value);
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
                ValidateValue(value, "Высота столешницы");
                _height = Math.Truncate(value);
            }
        }

        /// <summary>
        /// Проверка присваиваемого значения.
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
