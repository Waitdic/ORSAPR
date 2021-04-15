using Kompas6API5;
using Kompas6Constants3D;
using TablePlugin.BLL.Models;

namespace TablePlugin.BLL
{
    public class TableBuilder
    {
        private KompasConnector connector;
        private TableParameters parameters;

        public TableBuilder(KompasConnector connector, TableParameters parameters)
        {
            this.connector = connector;
            this.parameters = parameters;
        }

        public void Build()
        {
            this.CreateTopTable();
            this.CreateTableLegs();
            this.CreateHole();
        }

        private void CreateTopTable()
        {
            // Начальная плоскость
            var currentPlane = (ksEntity)connector.Part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);
            
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
