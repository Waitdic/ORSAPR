using TablePlugin.BLL.Enums;

namespace TablePlugin.BLL.Models
{
    public class AdditionalParameters
    {
        private double min;
        private double max;
        private ParametersType name;

        public double Min
        {
            get => min;
            set => min = value;
        }

        public double Max
        {
            get => max;
            set => max = value;
        }

        public ParametersType Name
        {
            get => name;
            set => name = value;
        }
    }
}
