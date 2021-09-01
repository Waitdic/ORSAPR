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
            ParametersValidation.ValidateMinMaxValue(min, max);
            ParametersValidation.ValidateValue(min, name);
            ParametersValidation.ValidateValue(max, name);

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
            ParametersValidation.ValidateMinMaxValue(min, max);
            ParametersValidation.ValidateValue(min, _name);
            ParametersValidation.ValidateValue(max, _name);

            _min = min;
            _max = max;
        }
    }
}
