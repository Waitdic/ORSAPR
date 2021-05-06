using System;
using System.Linq;
using NUnit.Framework;
using TablePlugin.BLL.Enums;
using TablePlugin.BLL.Models;

namespace TablePlugin.UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        [Test, Description("Тест на присваиваение параметров в объект класса TableParameters. Позитивный тест.")]
        public void TableParameters_CorrectValue_CorrectResult()
        {
            // SetUp
            var parameters = new TableParameters();

            // Act
            SetCorrectParameters(parameters);
        }
        
        [Test, Description("Тест на параметров параметров класса TableParameters. Позитивный тест.")]
        public void TableParameters_GetParameters_CorrectResult()
        {
            // SetUp
            var parameters = new TableParameters();

            // Act
            SetCorrectParameters(parameters);
            var top = parameters.TableTop;
            var legs = parameters.TabLegs;
            var hole = parameters.TableHole;

            // Assert
            Assert.NotNull(top);
            Assert.NotNull(legs);
            Assert.NotNull(hole);
        }

        [Test, Description("Тест на получение списка с дополнительными параметрами. Позитивный тест.")]
        public void ListAdditionalParameters_CorrectResult()
        {
            // SetUp
            var parameters = new TableParameters();

            // Act
            var additionalParam = parameters.AdditionalParameters;

            // Assert
            Assert.NotNull(additionalParam);
            Assert.AreEqual(10, additionalParam.Count);
            foreach(var p in additionalParam)
            {
                Assert.NotNull(p.Value);
            }
        }

        [TestCase(25.05d, "Radius", "Значение поля 'Радиус отверстия' не может быть дробным")]
        [TestCase(900.05d, "ParamX", "Значение поля 'Расстояние по длине до центра отверстия' не может быть дробным")]
        [TestCase(400.05d, "ParamY", "Значение поля 'Расстояние по ширине до центра отверстия' не может быть дробным")]
        [TestCase(-1, "Radius", "Радиус отверстия не может быть меньше или равна нулю!")]
        [TestCase(-1, "ParamX", "Расстояние по длине до центра отверстия не может быть меньше или равна нулю!")]
        [TestCase(-1, "ParamY", "Расстояние по ширине до центра отверстия не может быть меньше или равна нулю!")]
        public void TableHoleParameters_WrongArgument_ThrowsExceptionResult(double value, string parameter, string exception)
        {
            // SetUp
            var parameters = new TableHoleParameters();

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                parameters.Radius = parameter == "Radius" ? value : 25;
                parameters.ParamX = parameter == "ParamX" ? value : 900;
                parameters.ParamY = parameter == "ParamY" ? value : 400;
            }, exception);
        }
        
        [TestCase(1800.05d, "Length", "Значение поля 'Длина столешницы' не может быть дробным")]
        [TestCase(700.05d, "Width", "Значение поля 'Ширина столешницы' не может быть дробным")]
        [TestCase(40.05d, "Height", "Значение поля 'Высота столешницы' не может быть дробным")]
        [TestCase(-1, "Length", "Длина столешницы не может быть меньше или равна нулю!")]
        [TestCase(-1, "Width", "Ширина столешницы не может быть меньше или равна нулю!")]
        [TestCase(-1, "Height", "Высота столешницы не может быть меньше или равна нулю!")]
        public void TableTopParameters_WrongArgument_ThrowsExceptionResult(double value, string parameter, string exception)
        {
            // SetUp
            var parameters = new TableTopParameters();

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                parameters.Length = parameter == "Length" ? value : 1800;
                parameters.Width = parameter == "Width" ? value : 700;
                parameters.Height = parameter == "Height" ? value : 40;
            }, exception);
        }
        
        [TestCase(650.05d, "Height", "Значение поля 'Высота ножек' не может быть дробным")]
        [TestCase(50.05d, "Value", "Значение поля 'Размер основания' не может быть дробным")]
        [TestCase(-1, "Height", "Высота ножек не может быть меньше или равна нулю!")]
        [TestCase(-1, "Number", "Количество ножек не может быть меньше или равна нулю!")]
        [TestCase(-1, "Value", "Размер основания не может быть меньше или равна нулю!")]
        public void TableLegsParameters_WrongArgument_ThrowsExceptionResult(double value, string parameter, string exception)
        {
            // SetUp
            var parameters = new TableLegsParameters();

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                parameters.Height = parameter == "Height" ? value : 650;
                parameters.Number = parameter == "Number" ? (int)value : 4;
                parameters.Value = parameter == "Value" ? value : 50;
            }, exception);
        }
        
        [TestCase(900, ParametersType.TableTopLength)]
        [TestCase(500, ParametersType.TableTopWidth)]
        [TestCase(20, ParametersType.TableTopHeight)]
        [TestCase(500, ParametersType.TableLegsHeight)]
        [TestCase(3, ParametersType.TableLegsNumber)]
        [TestCase(30, ParametersType.TableLegsDiameter)]
        [TestCase(10, ParametersType.HoleRadius)]
        [TestCase(110, ParametersType.HoleParamX)]
        [TestCase(80, ParametersType.HoleParamY)]
        public void TableParameters_WrongArgument_ThrowsExceptionResult(double value,  ParametersType parameter)
        {
            // SetUp
            var parameters = new TableParameters();
            var addInfo = parameters.AdditionalParameters.FirstOrDefault(x => x.Key == parameter).Value;
            
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                parameters.TableTop = new TableTopParameters
                {
                    Length =  parameter == ParametersType.TableTopLength ? value : 1500,
                    Width = parameter == ParametersType.TableTopWidth ? value : 700,
                    Height = parameter == ParametersType.TableTopHeight ? value : 40,
                };

                parameters.TabLegs = new TableLegsParameters
                {
                    Height = parameter == ParametersType.TableLegsHeight ? value : 650,
                    Number = parameter == ParametersType.TableLegsNumber ?  (int) value : 4,
                    Value = parameter == ParametersType.TableLegsDiameter ? value : 50,
                };

                parameters.TableHole = new TableHoleParameters
                {
                    Radius = parameter == ParametersType.HoleRadius ? value : 25,
                    ParamX = parameter == ParametersType.HoleParamX ? value : 900,
                    ParamY = parameter == ParametersType.HoleParamY ? value : 400,
                };
            }, $"Значение '{addInfo.Name}' должно быть в диапозоне от {addInfo.Min} до {addInfo.Max}." );
        }
        
        [Test]
        public void TableParameters_WrongNumberOfLegs_ThrowsExceptionResult()
        {
            // SetUp
            var parameters = new TableParameters();
            
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                parameters.TableTop = new TableTopParameters
                {
                    Length = 2000,
                    Width = 700,
                    Height = 40,
                };

                parameters.TabLegs = new TableLegsParameters
                {
                    Height = 650,
                    Number = 4,
                    Value = 50,
                };
                
            }, "Значение 'Количество ножек' должно быть в диапозоне от 5 до 5." );
        }

        private static void SetCorrectParameters(TableParameters parameters)
        {
            parameters.TableTop = new TableTopParameters
            {
                Length = 1500,
                Width = 700,
                Height = 35,
            };

            parameters.TabLegs = new TableLegsParameters
            {
                Height = 650,
                Number = 4,
                Type = LegsType.RoundLegs,
                Value = 50
            };

            parameters.TableHole = new TableHoleParameters
            {
                Radius = 25,
                ParamX = 900,
                ParamY = 400
            };
        }
    }
}
