using TablePlugin.BLL.Enums;

namespace TablePlugin.BLL.Models
{
    /// <summary>
    /// Класс дополнительных параметров для стола.
    /// </summary>
    public class AdditionalParameters
    {
        private double _min;
        private double _max;
        private ParametersType _name;

        /// <summary>
        /// Минимальное значение.
        /// </summary>
        public double Min { get => _min; internal set => _min = value; }

        /// <summary>
        /// Максимальное значение.
        /// </summary>
        public double Max { get => _max; internal set => _max = value; }

        /// <summary>s6
        /// Имя параметра.
        /// </summary>
        public ParametersType Name { get => _name; internal set => _name = value; }
    }
}
