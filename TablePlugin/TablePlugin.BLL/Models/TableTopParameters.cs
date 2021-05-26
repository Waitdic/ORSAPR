using System;
using TablePlugin.BLL.Common;

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
                ParametersValidation.ValidateValue(value, "Длина столешницы");
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
                ParametersValidation.ValidateValue(value, "Ширина столешницы");
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
                ParametersValidation.ValidateValue(value, "Высота столешницы");
                _height = Math.Truncate(value);
            }
        }
    } 
}
