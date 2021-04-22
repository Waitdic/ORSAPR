namespace TablePlugin.BLL.Models
{
    public struct TableHoleParameters
    {
        private double _radius;
        private double _paramY;
        private double _paramX;

        public TableHoleParameters(double radius, double paramY, double paramX)
        {
            _radius = radius;
            _paramY = paramY;
            _paramX = paramX;
        }

        public double Radius
        {
            get => _radius;
            set => _radius = value;
        }

        public double ParamY
        {
            get => _paramY;
            set => _paramY = value;
        }

        public double ParamX
        {
            get => _paramX;
            set => _paramX = value;
        }
    }
}
