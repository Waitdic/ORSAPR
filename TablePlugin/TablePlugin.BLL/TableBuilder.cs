using Kompas6API5;
using Kompas6Constants3D;
using Kompas6Constants;
using TablePlugin.BLL.Enums;
using TablePlugin.BLL.Models;

namespace TablePlugin.BLL
{
    /// <summary>
    /// Класс для построение 3D модели.
    /// </summary>
    public class TableBuilder
    {
        /// <summary>
        /// Коннектор для работы с Компас3D.
        /// </summary>
        private KompasConnector _connector;

        /// <summary>
        /// Параметры стола.
        /// </summary>
        private TableParameters _parameters;

        /// <summary>
        /// Метод для построение 3D модели.
        /// </summary>
        /// <param name="parameters">Параметры стола.</param>
        public void Build(TableParameters parameters)
        {
            _parameters = parameters;
            if (_connector == null)
            {
                _connector = new KompasConnector();
            }
            else
            {
                _connector.GetNewPart();
            }

            CreateTopTable();
            CreateTableLegs();
            CreateHole();
        }

        /// <summary>
        /// Метод для построения столешницы.
        /// </summary>
        private void CreateTopTable()
        {
            // Создаем эскиз.
            var sketchDef = CreateSketch(Obj3dType.o3d_planeXOY);
            var doc2D = (ksDocument2D)sketchDef.BeginEdit();

            // Создание прямоугольника.
            var rectangleParam = (ksRectangleParam)_connector.KsObject.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            // Присваиваем параметры прямоугольнику.
            rectangleParam.x = 0;
            rectangleParam.y = 0;
            rectangleParam.ang = 0;
            rectangleParam.height = _parameters.TableTop.Width;
            rectangleParam.width = _parameters.TableTop.Length;
            rectangleParam.style = 1;
            doc2D.ksRectangle(rectangleParam);

            // Конец редактирования эскиза
            sketchDef.EndEdit();
            
            // Выдавить
            PressOutSketch(sketchDef, _parameters.TableTop.Height);
        }

        /// <summary>
        /// Метод для построения ножек стола.
        /// </summary>
        private void CreateTableLegs()
        {
            // Создаем эскиз.
            var sketchDef = CreateSketch(Obj3dType.o3d_planeXOY);
            var doc2D = (ksDocument2D)sketchDef.BeginEdit();

            // Координаты цетров ножек.
            var x = _parameters.TabLegs.Number != 5 ? new double[4] : new double[5];
            var y = _parameters.TabLegs.Number != 5 ? new double[4] : new double[5];

            // Создание примитив основания ножки по параметрам.
            if (_parameters.TabLegs.Type == LegsType.RoundLegs)
            {
                x[0] = 20 + (_parameters.TabLegs.Value / 2);
                y[0] = 20 + (_parameters.TabLegs.Value / 2);

                x[1] = 20 + _parameters.TabLegs.Value / 2;
                y[1] = _parameters.TableTop.Width - 20 - (_parameters.TabLegs.Value / 2);

                x[2] = _parameters.TableTop.Length - 20 - (_parameters.TabLegs.Value / 2);
                y[2] = _parameters.TableTop.Width - 20 - (_parameters.TabLegs.Value / 2);

                x[3] = _parameters.TableTop.Length - 20 - (_parameters.TabLegs.Value / 2);
                y[3] = 20 + (_parameters.TabLegs.Value / 2);

                if (x.Length == 5)
                {
                    x[4] = (_parameters.TableTop.Length / 2);
                    y[4] = (_parameters.TableTop.Width / 2);
                }

                for (var i = 0; i < x.Length; i++)
                {
                    doc2D.ksCircle(x[i], y[i], _parameters.TabLegs.Value / 2, 1);
                }
            }
            else
            {
                x[0] = 20;
                y[0] = 20;

                x[1] = 20;
                y[1] = _parameters.TableTop.Width - 20 - _parameters.TabLegs.Value;

                x[2] = _parameters.TableTop.Length - 20 - _parameters.TabLegs.Value;
                y[2] = _parameters.TableTop.Width - 20 - _parameters.TabLegs.Value;

                x[3] = _parameters.TableTop.Length - 20 - _parameters.TabLegs.Value ;
                y[3] = 20;

                if (x.Length == 5)
                {
                    x[4] = (_parameters.TableTop.Length / 2) - (_parameters.TabLegs.Value / 2);
                    y[4] = (_parameters.TableTop.Width / 2) - (_parameters.TabLegs.Value / 2);
                }

                for (var i = 0; i < x.Length; i++)
                {
                    var rectangleParam = (ksRectangleParam)_connector.KsObject.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
                    rectangleParam.x = x[i];
                    rectangleParam.y = y[i];
                    rectangleParam.ang = 0;
                    rectangleParam.height = _parameters.TabLegs.Value;
                    rectangleParam.width = _parameters.TabLegs.Value;
                    rectangleParam.style = 1;
                    doc2D.ksRectangle(rectangleParam);
                }
            }

            // Конец редактирования эскиза
            sketchDef.EndEdit();

            // Выдавить
            PressOutSketch(sketchDef, _parameters.TabLegs.Height, side: false);
        }

        /// <summary>
        /// Метод для вырезания отверстия в столешнице.
        /// </summary>
        private void CreateHole()
        {
            // Создаем эскиз.
            var sketchDef = CreateSketch(Obj3dType.o3d_planeXOY);
            var doc2D = (ksDocument2D)sketchDef.BeginEdit();

            // Создаем окружность.
            var param = _parameters.TableHole;
            doc2D.ksCircle(param.ParamX, param.ParamY, param.Radius, 1);

            // Конец редактирования эскиза.
            sketchDef.EndEdit();

            // Вырезать выдавливанием.
            PressOutSketch(sketchDef, _parameters.TableTop.Height, ksObj3dTypeEnum.o3d_cutExtrusion, false);
        }

        /// <summary>
        /// Действие выдавливания по эскизу.
        /// </summary>
        /// <param name="sketchDef">Эскиз.</param>f
        /// <param name="height">Высота выдавливание.</param>
        /// <param name="type">Тип выдавливания.</param>
        /// <param name="side">Направление выдаливания.</param>
        private void PressOutSketch(ksSketchDefinition sketchDef, double height, ksObj3dTypeEnum type = ksObj3dTypeEnum.o3d_bossExtrusion, bool side = true)
        {
            // Выдавливание по типу
            var iBaseExtrusionEntity = (ksEntity)_connector.Part.NewEntity((short)type);

            // интерфейс свойств базовой операции выдавливания
            if (type == ksObj3dTypeEnum.o3d_bossExtrusion)
            {
                var iBaseExtrusionDef = (ksBossExtrusionDefinition)iBaseExtrusionEntity.GetDefinition();
                iBaseExtrusionDef.SetSideParam(side, (short)End_Type.etBlind, height);
                iBaseExtrusionDef.directionType = side ? (short)Direction_Type.dtNormal : (short)Direction_Type.dtReverse;

                // эскиз операции выдавливания
                iBaseExtrusionDef.SetSketch(sketchDef);
            }
            else if (type == ksObj3dTypeEnum.o3d_cutExtrusion)
            { 
                var iBaseExtrusionDef = (ksCutExtrusionDefinition)iBaseExtrusionEntity.GetDefinition();
                iBaseExtrusionDef.SetSideParam(side, (short)End_Type.etBlind, height);
                iBaseExtrusionDef.directionType = side ? (short)Direction_Type.dtNormal : (short)Direction_Type.dtReverse;

                // эскиз операции вырезания по выдавливанию
                iBaseExtrusionDef.SetSketch(sketchDef);
            }
            
            // создать операцию
            iBaseExtrusionEntity.Create();
        }

        /// <summary>
        /// Создание эскиза.
        /// </summary>
        /// <param name="planeType">В какой плоскости будет эскиз.</param>
        /// <returns>ksSketchDefinition.</returns>
        private ksSketchDefinition CreateSketch(Obj3dType planeType)
        {
            // Выбор плоскости
            var plane = (ksEntity)_connector.Part.GetDefaultEntity((short)planeType);
            var sketch = (ksEntity)_connector.Part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDef = sketch.GetDefinition();
            sketchDef.SetPlane(plane);
            sketch.Create();

            return sketchDef;
        }
    }
}
