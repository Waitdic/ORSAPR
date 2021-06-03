using System.Collections.Generic;
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
            if (parameters.TableBoxNumber != 0)
            {
                CreateBox();
            }
            
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

            var x = new Dictionary<int, double>();
            var y = new Dictionary<int, double>();
            var legsValue = _parameters.TabLegs.Value;

            if (_parameters.TabLegs.Type == LegsType.RoundLegs)
            {
                x.Add(0, 20 + (legsValue / 2));
                y.Add(0, 20 + (legsValue / 2));
               
                x.Add(1, 20 + (legsValue / 2));
                y.Add(1, _parameters.TableTop.Width - 20 - (legsValue / 2));

                if (_parameters.TableBoxNumber < 3)
                {
                    x.Add(2, _parameters.TableTop.Length - 20 - (legsValue / 2));
                    y.Add(2, _parameters.TableTop.Width - 20 - (legsValue / 2));
                    
                    x.Add(3, _parameters.TableTop.Length - 20 - (legsValue / 2));
                    y.Add(3, 20 + (legsValue / 2));
                    
                    if (_parameters.TabLegs.Number == 5)
                    {
                        x.Add(4, (_parameters.TableTop.Length / 2));
                        y.Add(4, (_parameters.TableTop.Width / 2));
                    }
                }

                // Создание окружностей основания ножек.
                for (var i = 0; i < x.Count; i++)
                {
                    doc2D.ksCircle(
                        x[i], 
                        y[i], 
                        legsValue/ 2, 1);
                }
            }
            else
            {
                x.Add(0, 20);
                y.Add(0, 20);
                
                x.Add(1, 20);
                y.Add(1, _parameters.TableTop.Width - 20 - legsValue);
                
                if (_parameters.TableBoxNumber < 3)
                {
                    x.Add(2, _parameters.TableTop.Length - 20 - legsValue);
                    y.Add(2, _parameters.TableTop.Width - 20 - legsValue);
                    
                    x.Add(3, _parameters.TableTop.Length - 20 - legsValue);
                    y.Add(3, 20);
                    
                    if (x.Count == 5)
                    {
                        x.Add(4, (_parameters.TableTop.Length / 2) - (legsValue / 2));
                        y.Add(4, (_parameters.TableTop.Width / 2) - (legsValue / 2));
                    }
                }

                // Создание квадратов основания ножек.
                for (var i = 0; i < x.Count; i++)
                {
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

             PressOutSketch(
                sketchDef, 
                _parameters.TableTop.Height, 
                ksObj3dTypeEnum.o3d_cutExtrusion, 
                false);
        }

        /// <summary>
        /// Метод для создания выдвижных ящиков.
        /// </summary>
        private void CreateBox()
        {
            if (_parameters.TableBoxNumber <= 2)
            {
                for (var i = 0; i < _parameters.TableBoxNumber; i++)
                {
                    BuildBox(140d, i);
                }
            }
            else
            {
                var height = _parameters.TabLegs.Height / _parameters.TableBoxNumber;
                for (var i = 0; i < _parameters.TableBoxNumber; i++)
                {
                    BuildBox(height, i);
                }
            }
        }

        /// <summary>
        /// Действие выдавливания по эскизу.
        /// </summary>
        /// <param name="sketchDef">Эскиз.</param>f
        /// <param name="height">Высота выдавливание.</param>
        /// <param name="type">Тип выдавливания.</param>
        /// <param name="side">Направление выдаливания.</param>
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
                extrusionDef.directionType = side 
                    ? (short)Direction_Type.dtNormal 
                    : (short)Direction_Type.dtReverse;
                
                extrusionDef.SetSketch(sketchDef);
            }
            else if (type == ksObj3dTypeEnum.o3d_cutExtrusion)
            { 
                var extrusionDef = (ksCutExtrusionDefinition)extrusionEntity.GetDefinition();
                extrusionDef.SetSideParam(side, (short)End_Type.etBlind, height);

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

        /// <summary>
        /// Метод для построение выдвижных ящиков в зависимости от параметров.
        /// </summary>
        /// <param name="height">Высота ящика</param>
        /// <param name="index">Какой по счету ящик.</param>
        /// <remarks>Подсчет ящиков начинается с 0.</remarks>
        private void BuildBox(double height, int index)
        {
            var koef = 0.1d;
            var y = height * index;
            
            // Делаем ящик
            var sketchDef = CreateSketch(Obj3dType.o3d_planeXOZ);
            var doc2D = (ksDocument2D)sketchDef.BeginEdit();
            
            var rectangleParam = (ksRectangleParam)_connector
                .KsObject
                .GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
                
            rectangleParam.x = _parameters.TableTop.Length - 350;
            rectangleParam.y = y;
            rectangleParam.height = height;
            rectangleParam.width = 350;
            rectangleParam.style = 1;
            rectangleParam.ang = 0;
            doc2D.ksRectangle(rectangleParam);
            sketchDef.EndEdit();
           
            PressOutSketch(sketchDef, _parameters.TableTop.Width);

            // Вырезаем отверстие
            sketchDef = CreateSketch(Obj3dType.o3d_planeXOZ);
            doc2D = (ksDocument2D)sketchDef.BeginEdit();
            
            rectangleParam.x = _parameters.TableTop.Length - 330;
            rectangleParam.y = y; 
            rectangleParam.height = height - 20;
            rectangleParam.width = 310;
            doc2D.ksRectangle(rectangleParam);
            sketchDef.EndEdit();
            
            PressOutSketch(
                sketchDef, 
                _parameters.TableTop.Width - 20,
                ksObj3dTypeEnum.o3d_cutExtrusion,
                false);

            // Делаем дверцу.
            sketchDef = CreateSketch(Obj3dType.o3d_planeXOZ);
            doc2D = (ksDocument2D)sketchDef.BeginEdit();
            
            rectangleParam.x = _parameters.TableTop.Length - (330 - koef);
            rectangleParam.y = y + koef;
            rectangleParam.height = (height - 20) - (2 * koef);
            rectangleParam.width = 309.98 - (2 * koef);
            doc2D.ksRectangle(rectangleParam);
            sketchDef.EndEdit();
            
            PressOutSketch(sketchDef, 20);

            // Делаем ручку
            sketchDef = CreateSketch(Obj3dType.o3d_planeXOZ);
            doc2D = (ksDocument2D)sketchDef.BeginEdit();
            
            rectangleParam.x = (_parameters.TableTop.Length - 330) + (310 / 2) - 60;;
            rectangleParam.y = ((height - 20) / 2) + y - 10 ;
            rectangleParam.height = 20;
            rectangleParam.width = 120;
            doc2D.ksRectangle(rectangleParam);
            sketchDef.EndEdit();
            
            PressOutSketch(sketchDef, 40, side: false);
            
            sketchDef = CreateSketch(Obj3dType.o3d_planeXOZ);
            doc2D = (ksDocument2D)sketchDef.BeginEdit();
            
            rectangleParam.x = (_parameters.TableTop.Length - 330) + (310 / 2) - 50;
            rectangleParam.width = 100;
            doc2D.ksRectangle(rectangleParam);
            sketchDef.EndEdit();
            
            PressOutSketch(sketchDef, 30, ksObj3dTypeEnum.o3d_cutExtrusion);
        }
    }
}
