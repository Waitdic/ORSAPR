using Kompas6API5;
using Kompas6Constants3D;
using TablePlugin.BLL.Models;

namespace TablePlugin.BLL
{
    public class TableBuilder
    {
        private KompasConnector _connector;
        private TableParameters _parameters;

        public void Build(TableParameters parameters)
        {
            _connector = new KompasConnector();
            _parameters = parameters;

            this.CreateTopTable();
            this.CreateTableLegs();
            this.CreateHole();
        }

        private void CreateTopTable()
        {
            // Начальная плоскость
            var currentPlane = (ksEntity)_connector.Part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);
            
            // Массив эскизов
            var sketchList = new ksEntity[2];
            // sketchList[0].

        }

        private void CreateTableLegs()
        {

        }

        private void CreateHole()
        {

        }
    }
}
