using System;
using TablePlugin.BLL.Common;
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
                ParametersValidation.ValidateValue(value, "Высота ножек");
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
                ParametersValidation.ValidateValue(value, "Количество ножек");
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
                ParametersValidation.ValidateValue(value, "Размер основания");
                _value = Math.Truncate(value);
            } 
        }
    }
}
