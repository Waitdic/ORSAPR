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
        public double Min { get => _min; internal set => _min = value; }

        /// <summary>
        /// Максимальное значение.
        /// </summary>
        public double Max { get => _max; internal set => _max = value; }

        /// <summary>
        /// Имя имя параметра.
        /// </summary>
        public string Name { get => _name; internal set => _name = value; }
    }
}
