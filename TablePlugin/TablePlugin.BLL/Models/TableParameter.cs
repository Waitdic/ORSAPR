using System.Collections.Generic;
using System.Security;
using TablePlugin.BLL.Enums;

namespace TablePlugin.BLL.Models
{
    public class TableParameter
    {
        public TableParameter()
        {
            
        }

        private double tableTopLength;
        private double tableTopWidth;
        private double tableTopHeight;

        private double? holeRadius;
        private double? holeParamY;
        private double? holeParamX;

        private int tableLegsNumber;
        private double tableLegsHeight;
        private LegsType tableLegsType;

        private double? tableLegsDiameter;
        private double? tableLegsSideLength;

        private Dictionary<string, Dictionary<string, decimal>> param;

        public double TableTopLength
        {
            get => tableTopLength;
            set => tableTopLength = value;
        }

        public double TableTopWidth
        {
            get => tableTopWidth;
            set => tableTopWidth = value;
        }

        public double TableTopHeight
        {
            get => tableTopHeight;
            set => tableTopHeight = value;
        }

        public double? HoleRadius
        {
            get => holeRadius;
            set => holeRadius = value;
        }

        public double? HoleParamY
        {
            get => holeParamY;
            set => holeParamY = value;
        }

        public double? HoleParamX
        {
            get => holeParamX;
            set => holeParamX = value;
        }

        public double TableLegsHeight
        {
            get => tableLegsHeight;
            set => tableLegsHeight = value;
        }

        public int TableLegsNumber
        {
            get => tableLegsNumber;
            set => tableLegsNumber = value;
        }

        public LegsType TableLegsType
        {
            get => tableLegsType;
            set => tableLegsType = value;
        }

        public double? TableLegsDiameter
        {
            get => tableLegsDiameter;
            set => tableLegsDiameter = value;
        }

        public double? TableLegsSideLength
        {
            get => tableLegsSideLength;
            set => tableLegsSideLength = value;
        }
    }
}
