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
                ValidateToDoubleValue(value);
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
                ValidateToDoubleValue(value);
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
                ValidateToDoubleValue(value);
                _paramX = value;
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
