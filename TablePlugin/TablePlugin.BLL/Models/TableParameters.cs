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
        private TableTopParameters _tableTop;
        private TableHoleParameters _tableHole;
        private TableLegsParameters _tableLegs;

        /// <summary>
        /// Допольнительные параметры стола.
        /// </summary>
        private readonly List<AdditionalParameters> _additionalParameters = new List<AdditionalParameters>
        {
            new AdditionalParameters { Min = 1000, Max = 2000, LogicalName = ParametersType.TableTopLength, Name = "Длина столешницы" },
            new AdditionalParameters { Min = 600, Max = 800, LogicalName = ParametersType.TableTopWidth, Name = "Ширина столешницы" },
            new AdditionalParameters { Min = 30, Max = 40, LogicalName = ParametersType.TableTopHeight, Name = "Высота столешницы" },
            new AdditionalParameters { Min = 120, Max = 1870, LogicalName = ParametersType.HoleParamX, Name = "Расстояние по длине" },
            new AdditionalParameters { Min = 90, Max = 700, LogicalName = ParametersType.HoleParamY, Name = "Расстояние по ширине" },
            new AdditionalParameters { Min = 20, Max = 30, LogicalName = ParametersType.HoleRadius, Name = "Радиус отверстия" },
            new AdditionalParameters { Min = 600, Max = 700, LogicalName = ParametersType.TableLegsHeight, Name = "Высота ножек" },
            new AdditionalParameters { Min = 4, Max = 5, LogicalName = ParametersType.TableLegsNumber, Name = "Количество ножек" },
            new AdditionalParameters { Min = 40, Max = 60, LogicalName = ParametersType.TableLegsDiameter, Name = "Диаметр основания ножек" },
            new AdditionalParameters { Min = 40, Max = 60, LogicalName = ParametersType.TableLegsSideLength, Name = "Длина основания ножек" },
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
                var additionalParamX = _additionalParameters.FirstOrDefault(x => x.LogicalName == ParametersType.HoleParamX);
                var additionalParamY = _additionalParameters.FirstOrDefault(x => x.LogicalName == ParametersType.HoleParamY);

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
                if (Math.Abs(_tableTop.Length - 2000) < 1d)
                {
                    var number = _additionalParameters.FirstOrDefault(x => x.LogicalName == ParametersType.TableLegsNumber);
                    number.Min = number.Max;
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
        public List<AdditionalParameters> AdditionalParameters{ get => _additionalParameters; }

        /// <summary>
        /// Проверка на допустимый диапозон.
        /// </summary>
        /// <param name="container"></param>
        private void CheckRangeOfValues(Dictionary<ParametersType, double> container)
        {
            foreach (var keyValue in container)
            {
                var param = _additionalParameters.FirstOrDefault(x => x.LogicalName == keyValue.Key);
                if (keyValue.Value < param.Min || keyValue.Value > param.Max)
                {
                    throw new ArgumentException($"Значение '{param.Name}' должно быть в диапозоне от {param.Min} до {param.Max}.");
                }
            } 
        }
    }
}
