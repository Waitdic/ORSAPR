using System.Collections.Generic;
using TablePlugin.BLL.Enums;

namespace TablePlugin.BLL.Models
{
    public class TableParameters
    {
        private TableTopParameters _tableTop;
        private TableHoleParameters _tableHole;
        private TableLegsParameters _tableLegs;

        private List<AdditionalParameters> additionalParameterses = new List<AdditionalParameters>
        {
            new AdditionalParameters {Min = 1000, Max = 2000, Name = ParametersType.TableTopLength}
        };

        public TableTopParameters TableTop
        {
            get => _tableTop;
            set => _tableTop = value;
        }

        public TableHoleParameters TableHole
        {
            get => _tableHole;
            set { }
        }

        public TableLegsParameters TabLegs
        {
            get => _tableLegs;
            set => _tableLegs = value;
        }

        public List<AdditionalParameters> AdditionalParameters
        {
            get => additionalParameterses;
            set => additionalParameterses = value;
        }

        private bool CheckRangeOfVaues(string name)
        {
           
            return true;
        }
    }
}
