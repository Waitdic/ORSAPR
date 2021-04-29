using System;

namespace TablePlugin.BLL.Models
{   
    /// <summary>
    /// Параметры отверстия стола.
    /// </summary>
    public struct TableHoleParameters
    {
        private double _radius;
        private double _paramY;
        private double _paramX;

        /// <summary>
        /// Радиус отверстия.
        /// </summary>
        public double Radius
        {
            get => _radius;
            set
            {
                ValidateToDoubleValue(value, "Радиус отверстия");
                _radius = value;
            }
        }

        /// <summary>
        /// Значение до центра отверстия по ширине стола с левого верхнего угла.
        /// </summary>
        public double ParamY
        {
            get => _paramY;
            set
            {
                ValidateToDoubleValue(value, "Расстояние по ширине до центра отверстия");
                _paramY = value;
            }
        }

        /// <summary>
        /// Значение до центра отверстия по длине стола с левого верхнего угла.
        /// </summary>
        public double ParamX
        {
            get => _paramX;
            set
            {
                ValidateToDoubleValue(value, "Расстояние по длине до центра отверстия");
                _paramX = value;
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
                throw new ArgumentException("Значение double не является числом");
            }

            if (value <= 0)
            {
                throw new ArgumentException($"{name} не может быть меньше или равна нулю!");
            }
        }
    }
}
