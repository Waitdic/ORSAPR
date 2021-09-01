using System;
using System.Collections.Generic;
using System.Linq;
using TablePlugin.BLL.Common;
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
        /// Количество выдвижных ящиков.
        /// </summary>
        private int _tableBoxNumber;

        /// <summary>
        /// Допольнительные параметры стола.
        /// </summary>
        private readonly Dictionary<ParametersType, AdditionalParameters> _additionalParameters;

        /// <summary>
        /// Конструктор, который устанавливаниет начальные ограничения для параметров.
        /// </summary>
        public TableParameters()
        {
            _additionalParameters = new Dictionary<ParametersType, AdditionalParameters>
            {
                {
                    ParametersType.TableTopLength, 
                    new AdditionalParameters
                    (
                        min: 1000, 
                        max: 2000, 
                        name: "Длина столешницы"
                    )
                },
                {
                    ParametersType.TableTopWidth, 
                    new AdditionalParameters
                    (
                        min: 600, 
                        max: 800, 
                        name: "Ширина столешницы"
                    )
                },
                {
                    ParametersType.TableTopHeight, 
                    new AdditionalParameters
                    (
                        min: 30, 
                        max: 40, 
                        name: "Высота столешницы"
                    )
                },
                {
                    ParametersType.HoleParamX, 
                    new AdditionalParameters
                    (
                        min: 120, 
                        max: 1870, 
                        name: "Расстояние по длине"
                    )
                },
                {
                    ParametersType.HoleParamY, 
                    new AdditionalParameters
                    (
                        min: 90, 
                        max: 700, 
                        name: "Расстояние по ширине"
                    )
                },
                {
                    ParametersType.HoleRadius, 
                    new AdditionalParameters
                    (
                        min: 20, 
                        max: 30, 
                        name: "Радиус отверстия"
                    )
                },
                {
                    ParametersType.TableLegsHeight, 
                    new AdditionalParameters
                    (
                        min: 600, 
                        max: 700, 
                        name: "Высота ножек"
                    )
                },
                {
                    ParametersType.TableLegsNumber, 
                    new AdditionalParameters
                    (
                        min: 4, 
                        max: 5, 
                        name: "Количество ножек"
                    )
                },
                {
                    ParametersType.TableLegsDiameter, 
                    new AdditionalParameters
                    (
                        min: 40, 
                        max: 60, 
                        name: "Диаметр основания ножек"
                    )
                },
                {
                    ParametersType.TableLegsSideLength,
                    new AdditionalParameters
                    (
                        min: 40, 
                        max: 60, 
                        name: "Длина основания ножек"
                    )
                },
                {
                    ParametersType.TableBox,
                    new AdditionalParameters
                    (
                        min: 1,
                        max: 5,
                        name: "Количество ящиков"
                    )
                }
            };
        }

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
                var additionalParamX = _additionalParameters
                    .FirstOrDefault(x => x.Key == ParametersType.HoleParamX)
                    .Value;
                
                var additionalParamY = _additionalParameters
                    .FirstOrDefault(x => x.Key == ParametersType.HoleParamY)
                    .Value;

                additionalParamX.ChangeRange(
                    max: _tableTop.Length - value.Radius - 100,
                    min: value.Radius + 100);

                additionalParamY.ChangeRange(
                    max: _tableTop.Width - value.Radius - 70,
                    min: value.Radius + 70);
                
                if (_tableBoxNumber > 0)
                {
                    SetMaxParamXWithBox();
                }

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

                    ParametersValidation.CheckCrossingOfRange(
                        leftX, 
                        rightX, 
                        value.ParamX, 
                        "Расстояние по длине");

                    ParametersValidation.CheckCrossingOfRange(
                        leftY, 
                        rightY, 
                        value.ParamY, 
                        "Расстояние по ширине");
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
                if ((Math.Abs(_tableTop.Length - 2000d) < 0.001) && _tableBoxNumber == 0)
                {
                    var number = _additionalParameters
                        .FirstOrDefault(x => x.Key == ParametersType.TableLegsNumber)
                        .Value;
                    
                    number.ChangeRange(max: number.Max, min: 5);
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
        /// Количество выдвижных ящиков.
        /// </summary>
        public int TableBoxNumber
        {
            get => _tableBoxNumber;
            set
            {
                var number = _additionalParameters
                    .FirstOrDefault(x => x.Key == ParametersType.TableLegsNumber)
                    .Value;
                
                number.ChangeRange(max: 4, min: number.Min);

                CheckRangeOfValues(new Dictionary<ParametersType, double>
                {
                    {ParametersType.TableBox, value}
                });
                
                _tableBoxNumber = value;
            }
        }

        /// <summary>
        /// Дополнительные параметры стола.
        /// </summary>
        public Dictionary<ParametersType, AdditionalParameters> AdditionalParameters
        {
            get => _additionalParameters;
        }

        /// <summary>
        /// Метод для уставновки min/max значений параметра.
        /// </summary>
        /// <param name="expression">Лямбда-выражение.</param>
        /// <param name="type">Логическое имя параметра.</param>
        /// <returns>Значение min/max параметра в decimal</returns>
        public decimal SetMinMaxParameters(
            Func<KeyValuePair<ParametersType, AdditionalParameters>, double> expression
            ,ParametersType type)
        {
            return (decimal) _additionalParameters
                .Where(x => x.Key == type)
                .Select(expression)
                .FirstOrDefault();
        }

        /// <summary>
        /// Метод для изменения max значения
        /// ограничения ParamX. 
        /// </summary>
        /// <returns>Частный случай.</returns>
        public void SetMaxParamXWithBox()
        {
            var hole = _additionalParameters
                .FirstOrDefault(x => x.Key == ParametersType.HoleParamX)
                .Value;
                    
            hole.ChangeRange(max: hole.Max - 350, min: hole.Min);
        }

        /// <summary>
        /// Проверка на допустимый диапозон.
        /// </summary>
        /// <param name="container"></param>
        private void CheckRangeOfValues(Dictionary<ParametersType, double> container)
        {
            foreach (var keyValue in container)
            {
                var param = _additionalParameters
                    .FirstOrDefault(x => x.Key == keyValue.Key)
                    .Value;
                
                if (keyValue.Value < param.Min || keyValue.Value > param.Max)
                {
                    throw new ArgumentException(
                        $"Значение '{param.Name}' должно быть " 
                        + $"в диапозоне от {param.Min} до {param.Max}.");
                }
            } 
        }
    }
}
