using TablePlugin.BLL.Common;

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
                ParametersValidation.ValidateValue(value, "Радиус отверстия");
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
                ParametersValidation.ValidateValue(value, "Расстояние по ширине до центра отверстия");
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
                ParametersValidation.ValidateValue(value, "Расстояние по длине до центра отверстия");
                _paramX = value;
            } 
        }
    }
}
