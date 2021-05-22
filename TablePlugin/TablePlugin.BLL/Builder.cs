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
    public class Builder
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
            _connector = new KompasConnector();
            _connector.GetNewPart();

            CreateTopTable();
            CreateTableLegs();
            if (parameters.TableHole.Radius != 0)
            {
                CreateHole();
            }
        }

        /// <summary>
        /// Метод для построения столешницы.
        /// </summary>
        private void CreateTopTable()
        {
            var sketchDef = CreateSketch(Obj3dType.o3d_planeXOY);
            var doc2D = (ksDocument2D)sketchDef.BeginEdit();

             //TODO: RSDN
             var rectangleParam = (ksRectangleParam)_connector
                .KsObject
                .GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            rectangleParam.x = 0;
            rectangleParam.y = 0;
            rectangleParam.ang = 0;
            rectangleParam.height = _parameters.TableTop.Width;
            rectangleParam.width = _parameters.TableTop.Length;
            rectangleParam.style = 1;
            doc2D.ksRectangle(rectangleParam);
            
            sketchDef.EndEdit();
            PressOutSketch(sketchDef, _parameters.TableTop.Height);
        }

        /// <summary>
        /// Метод для построения ножек стола.
        /// </summary>
        private void CreateTableLegs()
        {
            var sketchDef = CreateSketch(Obj3dType.o3d_planeXOY);
            var doc2D = (ksDocument2D)sketchDef.BeginEdit();
            
            var x = _parameters.TabLegs.Number != 5 
                ? new double[4] 
                : new double[5];
            var y = _parameters.TabLegs.Number != 5 
                ? new double[4] 
                : new double[5];
            
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

                // Создание окружностей основания ножек.
                for (var i = 0; i < x.Length; i++)
                {
                    doc2D.ksCircle(
                        x[i], 
                        y[i], 
                        _parameters.TabLegs.Value / 2, 1);
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

                // Создание квадратов основания ножек.
                for (var i = 0; i < x.Length; i++)
                {
                     //TODO: RSDN
                    var rectangleParam = (ksRectangleParam)_connector
                        .KsObject
                        .GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
                    
                    rectangleParam.x = x[i];
                    rectangleParam.y = y[i];
                    rectangleParam.ang = 0;
                    rectangleParam.height = _parameters.TabLegs.Value;
                    rectangleParam.width = _parameters.TabLegs.Value;
                    rectangleParam.style = 1;
                    doc2D.ksRectangle(rectangleParam);
                }
            }
            
            sketchDef.EndEdit();
            
            PressOutSketch(
                sketchDef, 
                _parameters.TabLegs.Height, 
                side: false);
        }

        /// <summary>
        /// Метод для вырезания отверстия в столешнице.
        /// </summary>
        private void CreateHole()
        {
            var sketchDef = CreateSketch(Obj3dType.o3d_planeXOY);
            var doc2D = (ksDocument2D)sketchDef.BeginEdit();

            // Создаем окружность.
            var param = _parameters.TableHole;
            doc2D.ksCircle(
                param.ParamX, 
                param.ParamY, 
                param.Radius, 
                1);
            
            sketchDef.EndEdit();

             //TODO: RSDN
             PressOutSketch(
                sketchDef, 
                _parameters.TableTop.Height, 
                ksObj3dTypeEnum.o3d_cutExtrusion, 
                false);
        }

        /// <summary>
        /// Действие выдавливания по эскизу.
        /// </summary>
        /// <param name="sketchDef">Эскиз.</param>f
        /// <param name="height">Высота выдавливание.</param>
        /// <param name="type">Тип выдавливания.</param>
        /// <param name="side">Направление выдаливания.</param>
        ///  //TODO: RSDN
        private void PressOutSketch(
            ksSketchDefinition sketchDef, 
            double height, 
            ksObj3dTypeEnum type = ksObj3dTypeEnum.o3d_bossExtrusion, 
            bool side = true)
        {
            var extrusionEntity = (ksEntity)_connector.Part.NewEntity((short)type);
            
            if (type == ksObj3dTypeEnum.o3d_bossExtrusion)
            {
                var extrusionDef = (ksBossExtrusionDefinition)extrusionEntity.GetDefinition();
                extrusionDef.SetSideParam(side, (short)End_Type.etBlind, height);
                 //TODO: RSDN
                extrusionDef.directionType = side 
                    ? (short)Direction_Type.dtNormal 
                    : (short)Direction_Type.dtReverse;
                
                extrusionDef.SetSketch(sketchDef);
            }
            else if (type == ksObj3dTypeEnum.o3d_cutExtrusion)
            { 
                var extrusionDef = (ksCutExtrusionDefinition)extrusionEntity.GetDefinition();
                extrusionDef.SetSideParam(side, (short)End_Type.etBlind, height);
                 //TODO: RSDN
                 extrusionDef.directionType = side 
                    ? (short)Direction_Type.dtNormal 
                    : (short)Direction_Type.dtReverse;
                
                extrusionDef.SetSketch(sketchDef);
            }
            
            extrusionEntity.Create();
        }

        /// <summary>
        /// Создание эскиза.
        /// </summary>
        /// <param name="planeType">В какой плоскости будет эскиз.</param>
        /// <returns>ksSketchDefinition.</returns>
        private ksSketchDefinition CreateSketch(Obj3dType planeType)
        {
            var plane = (ksEntity)_connector
                .Part
                .GetDefaultEntity((short)planeType);
            
            var sketch = (ksEntity)_connector
                .Part
                .NewEntity((short)Obj3dType.o3d_sketch);
            
            var sketchDef = (ksSketchDefinition)sketch.GetDefinition();
            sketchDef.SetPlane(plane);
            sketch.Create();
            return sketchDef;
        }
    }
}
