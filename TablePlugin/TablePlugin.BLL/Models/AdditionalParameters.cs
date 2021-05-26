using System;
using TablePlugin.BLL.Common;

namespace TablePlugin.BLL.Models
{
    /// <summary>
    /// Дополнительных параметров для стола.
    /// </summary>
    public class AdditionalParameters
    {
        /// <summary>
        /// Минимальное значение.
        /// </summary>
        private double _min;
        
        /// <summary>
        /// Максимальное значение.
        /// </summary>
        private double _max;
        
        /// <summary>
        /// Имя имя параметра.
        /// </summary>
        private string _name;

        //TODO:
        /// <summary>
        /// Минимальное значение.
        /// </summary>
        public double Min => _min;

        /// <summary>
        /// Максимальное значение.
        /// </summary>
        public double Max => _max;

        /// <summary>
        /// Имя имя параметра.
        /// </summary>
        public string Name => _name;
        
        /// <summary>
        /// Конструктор, который присваивает изначальные ограничения.
        /// </summary>
        /// <param name="min">Min.</param>
        /// <param name="max">Max.</param>
        /// <param name="name">Имя параметра.</param>
        internal AdditionalParameters(double min, double max, string name)
        {
            ValidateMinMaxValue(min, max, name);
            _min = min;
            _max = max;
            _name = name;
        }

        /// <summary>
        /// Метод для изменения ограничений.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        internal void ChangeRange(double min, double max)
        {
            ValidateMinMaxValue(min, max, _name);
            _min = min;
            _max = max;
        }

        /// <summary>
        /// Проверка min/max значений.
        /// </summary>
        /// <param name="min">Минимальное значение.</param>
        /// <param name="max">Максимальное значение.</param>
        /// <param name="name">Имя параметра.</param>
        /// <exception cref="ArgumentException">Неправильное значение.</exception>
        private static void ValidateMinMaxValue(double min, double max, string name)
        {
            if (min > max)
            {
                throw new ArgumentException("Min не может быть больше Max");
            }
            
            ParametersValidation.ValidateValue(min, name);
            ParametersValidation.ValidateValue(max, name);
        }
    }
}
