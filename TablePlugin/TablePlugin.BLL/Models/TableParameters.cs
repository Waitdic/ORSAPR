using System;
using System.Collections.Generic;
using System.Linq;
using TablePlugin.BLL.Enums;

namespace TablePlugin.BLL.Models
{
    /// <summary>
    /// Класс параметров стола.
    /// </summary>
    public class TableParameters
    {
        /// <summary>
        /// Параметры столешницы.
        /// </summary>
        private TableTopParameters _tableTop;
        
        /// <summary>
        /// Параметры отверстия в столешнице.
        /// </summary>
        private TableHoleParameters _tableHole;
       
        /// <summary>
        /// Параметры отверстия в столешнице.
        /// </summary>
        private TableLegsParameters _tableLegs;

        /// <summary>
        /// Допольнительные параметры стола.
        /// </summary>
        private readonly Dictionary<ParametersType, AdditionalParameters> _additionalParameters = new Dictionary<ParametersType, AdditionalParameters>()
        {
            { ParametersType.TableTopLength, new AdditionalParameters { Min = 1000, Max = 2000, Name = "Длина столешницы" } },
            { ParametersType.TableTopWidth, new AdditionalParameters { Min = 600, Max = 800, Name = "Ширина столешницы" } },
            { ParametersType.TableTopHeight, new AdditionalParameters { Min = 30, Max = 40, Name = "Высота столешницы" } },
            { ParametersType.HoleParamX, new AdditionalParameters { Min = 120, Max = 1870, Name = "Расстояние по длине" } },
            { ParametersType.HoleParamY, new AdditionalParameters { Min = 90, Max = 700, Name = "Расстояние по ширине" } },
            { ParametersType.HoleRadius, new AdditionalParameters { Min = 20, Max = 30, Name = "Радиус отверстия" } },
            { ParametersType.TableLegsHeight, new AdditionalParameters { Min = 600, Max = 700, Name = "Высота ножек" } },
            { ParametersType.TableLegsNumber, new AdditionalParameters { Min = 4, Max = 5, Name = "Количество ножек" } },
            { ParametersType.TableLegsDiameter, new AdditionalParameters { Min = 40, Max = 60, Name = "Диаметр основания ножек" } },
            { ParametersType.TableLegsSideLength, new AdditionalParameters { Min = 40, Max = 60, Name = "Длина основания ножек" } },
        };

        /// <summary>
        /// Параметры столешницы.
        /// </summary>
        public TableTopParameters TableTop
        {
            get => _tableTop;
            set
            {
                CheckRangeOfValues(new Dictionary<ParametersType, double>
                {
                    { ParametersType.TableTopLength, value.Length },
                    { ParametersType.TableTopHeight, value.Height },
                    { ParametersType.TableTopWidth, value.Width },
                });

                _tableTop = value;
            }
        }

        /// <summary>
        /// Параметры отверстия в столешнице.
        /// </summary>
        public TableHoleParameters TableHole
        {
            get => _tableHole;
            set
            {
                var additionalParamX = _additionalParameters.FirstOrDefault(x => x.Key == ParametersType.HoleParamX).Value;
                var additionalParamY = _additionalParameters.FirstOrDefault(x => x.Key == ParametersType.HoleParamY).Value;

                additionalParamX.Max = _tableTop.Length - value.Radius - 100;
                additionalParamX.Min = value.Radius + 100;

                additionalParamY.Max = _tableTop.Width - value.Radius - 70;
                additionalParamY.Min = value.Radius + 70;

                CheckRangeOfValues(new Dictionary<ParametersType, double>
                {
                    { ParametersType.HoleRadius, value.Radius },
                    { ParametersType.HoleParamX, value.ParamX },
                    { ParametersType.HoleParamY, value.ParamY },
                });

                if (_tableLegs.Number == 5 || Math.Abs(_tableTop.Length - 2000d) < 0.001)
                { 
                    var leftX = (_tableTop.Length / 2) - (_tableLegs.Value / 2) - value.Radius - 20;
                    var rightX = (_tableTop.Length / 2) + (_tableLegs.Value / 2) + value.Radius + 20;
                    var leftY = (_tableTop.Width / 2) - (_tableLegs.Value / 2) - value.Radius - 20;
                    var rightY = (_tableTop.Width / 2) + (_tableLegs.Value / 2) + value.Radius + 20;

                    CheckCrossingOfRange(leftX, rightX, value.ParamX, "Расстояние по длине");
                    CheckCrossingOfRange(leftY, rightY, value.ParamY, "Расстояние по ширине");
                }

                _tableHole = value;
            }
        }

        /// <summary>
        /// Параметры ножек.
        /// </summary>
        public TableLegsParameters TabLegs
        {
            get => _tableLegs;
            set
            {
                if (Math.Abs(_tableTop.Length - 2000d) < 0.001)
                {
                    var number = _additionalParameters
                        .FirstOrDefault(x => x.Key == ParametersType.TableLegsNumber)
                        .Value;
                    number.Min = 5;
                }
               
                var container = new Dictionary<ParametersType, double>
                {
                    {ParametersType.TableLegsHeight, value.Height},
                    {ParametersType.TableLegsNumber, value.Number},
                    {
                        value.Type == LegsType.RoundLegs
                            ? ParametersType.TableLegsDiameter
                            : ParametersType.TableLegsSideLength,
                        value.Value
                    }
                };

                CheckRangeOfValues(container);
                _tableLegs = value;
            }
        }

        /// <summary>
        /// Дополнительные параметры стола.
        /// </summary>
        public Dictionary<ParametersType, AdditionalParameters> AdditionalParameters { get => _additionalParameters; }

        /// <summary>
        /// Проверка на допустимый диапозон.
        /// </summary>
        /// <param name="container"></param>
        private void CheckRangeOfValues(Dictionary<ParametersType, double> container)
        {
            foreach (var keyValue in container)
            {
                var param = _additionalParameters.FirstOrDefault(x => x.Key == keyValue.Key).Value;
                if (keyValue.Value < param.Min || keyValue.Value > param.Max)
                {
                    throw new ArgumentException($"Значение '{param.Name}' должно быть в диапозоне от {param.Min} до {param.Max}.");
                }
            } 
        }

        /// <summary>
        /// Проверка на пересечение диапозона.
        /// </summary>
        /// <param name="left">Левое ограничение координат.</param>
        /// <param name="right">Правое ограничение координат.</param>
        /// <param name="param">Значение координат.</param>
        /// <param name="name">Имя првоверяемого поля.</param>
        private void CheckCrossingOfRange(double left, double right, double param, string name)
        {
            if (left < param && param < right)
            {
                throw new ArgumentException($"Значение '{name}' не должно пересекать диапозоне от {left} до {right}.");
            }
        }
    }
}
