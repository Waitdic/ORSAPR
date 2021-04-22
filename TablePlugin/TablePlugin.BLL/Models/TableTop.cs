namespace TablePlugin.BLL.Models
{
    public struct TableTopParameters
    {
        private double _length;
        private double _width;
        private double _height;

        public double Length { get => _length; set => _length = value; }
        public double Width { get => _width; set => _width = value; }
        public double Height { get => _height; set => _height = value; }

        public TableTopParameters(double length, double width, double height)
        {
            _length = length;
            _width = width;
            _height = height;
        }
    } 
}
