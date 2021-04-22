using System;
using TablePlugin.BLL.Enums;

namespace TablePlugin.BLL.Models
{
    public struct TableLegsParameters
    {
        private int _number;
        private double _height;
        private LegsType _type;
        private double _value;

        public TableLegsParameters(int number, double height, LegsType type, double value)
        {
            _number = number;
            _height = height;
            _type = type;
           _value = value;

        }

        public double Height
        {
            get => _height;
            set => _height = value;
        }

        public int Number
        {
            get => _number;
            set => _number = value;
        }

        public LegsType Type
        {
            get => _type;
            set => _type = value;
        }

        public double Value
        {
            get => _value;
            set => _value = value;
        }
    }
}
