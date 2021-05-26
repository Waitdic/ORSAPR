using System;
using System.Linq;
using NUnit.Framework;
using TablePlugin.BLL.Enums;
using TablePlugin.BLL.Models;

namespace TablePlugin.UnitTests
{
    [TestFixture]
    public class ParametersTests
    {
        [TestCase(TestName = "Тест присваиваения параметров " +
                             "в TableParameters. Позитивный тест.")]
        public void TableParameters_CorrectValue_CorrectResult()
        {
            // SetUp
            var parameters = new TableParameters();

            // Act
            SetCorrectParameters(parameters);
        }
        
        [TestCase(TestName = "Тест получения параметров " +
                             "в класс TableParameters. Позитивный тест.")]
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
        
        [TestCase(TestName = "Тест на получение списка " + 
                             "с дополнительными параметрами. Позитивный тест.")]
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
        
        [TestCase(TestName = "Тест на установку минимальных " +
                             "и максимальных значений параметров. Позитивный тест.")]
        public void TableParameters_SetMinMaxParameters_CorrectResult()
        {
            // SetUp
            var parameters = new TableParameters();
            
            // Act
            var lenght = parameters.SetMinMaxParameters(
                x => x.Value.Min,
                ParametersType.TableTopLength);
            
            var height = parameters.SetMinMaxParameters(
                x => x.Value.Max,
                ParametersType.TableTopHeight);
            // Assert
            Assert.NotNull(lenght);
            Assert.NotNull(height);
            Assert.AreEqual(1000, lenght);
            Assert.AreEqual(40, height);
        }
        
        /// <param name="value">Присваиваемое значение.</param>
        /// <param name="parameter">В какой параметр будет присваиваться значение.</param>
        [TestCase(25.05d, "Radius", 
            TestName = "Тест присваивания {0} в TableHoleParameters.{1}. Негативный тест.")]
        [TestCase(900.05d, "ParamX", 
            TestName = "Тест присваивания {0} в TableHoleParameters.{1}. Негативный тест.")]
        [TestCase(400.05d, "ParamY", 
            TestName = "Тест присваивания {0} в TableHoleParameters.{1}. Негативный тест.")]
        [TestCase(-1, "Radius", 
            TestName = "Тест присваивания {0} в TableHoleParameters.{1}. Негативный тест.")]
        [TestCase(-1, "ParamX", 
            TestName = "Тест присваивания {0} в TableHoleParameters.{1}. Негативный тест.")]
        [TestCase(-1, "ParamY", 
            TestName = "Тест присваивания {0} в TableHoleParameters.{1}. Негативный тест.")]
        public void TableHoleParameters_WrongArgument_ThrowsExceptionResult(
            double value,
            string parameter)
        {
            // SetUp
            var parameters = new TableHoleParameters();

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                parameters.Radius = parameter == "Radius" 
                    ? value 
                    : 25;
                parameters.ParamX = parameter == "ParamX"
                    ? value 
                    : 900;
                parameters.ParamY = parameter == "ParamY" 
                    ? value 
                    : 400;
            }, $"Ошибка присвоения неправильного значения "
               + "в поле TableHoleParameters.{parameter}");
        }
        
        /// <param name="value">Присваиваемое значение.</param>
        /// <param name="parameter">В какой параметр будет присваиваться значение.</param>
        [TestCase(1800.05d, "Length", 
            TestName = "Тест присваивания {0} в TableTopParameters.{1}. Негативный тест.")]
        [TestCase(700.05d, "Width", 
            TestName = "Тест присваивания {0} в TableTopParameters.{1}. Негативный тест.")]
        [TestCase(40.05d, "Height", 
            TestName = "Тест присваивания {0} в TableTopParameters.{1}. Негативный тест.")]
        [TestCase(-1, "Length", 
            TestName = "Тест присваивания {0} в TableTopParameters.{1}. Негативный тест.")]
        [TestCase(-1, "Width",
            TestName = "Тест присваивания {0} в TableTopParameters.{1}. Негативный тест.")]
        [TestCase(-1, "Height",
            TestName = "Тест присваивания {0} в TableTopParameters.{1}. Негативный тест.")]
        public void TableTopParameters_WrongArgument_ThrowsExceptionResult(
            double value,
            string parameter)
        {
            // SetUp
            var parameters = new TableTopParameters();

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                parameters.Length = parameter == "Length" 
                    ? value 
                    : 1800;
                parameters.Width = parameter == "Width" 
                    ? value 
                    : 700;
                parameters.Height = parameter == "Height" 
                    ? value 
                    : 40;
            }, $"Ошибка присвоения неправильного значения "
               + "в TableTopParameters.{parameter}");
        }
        
        /// <param name="value">Присваиваемое значение.</param>
        /// <param name="parameter">В какой параметр будет присваиваться значение.</param>
        [TestCase(650.05d, "Height",
            TestName = "Тест присваивания {0} в TableTopParameters.{1}. Негативный тест.")]
        [TestCase(50.05d, "Value",
            TestName = "Тест присваивания {0} в TableTopParameters.{1}. Негативный тест.")]
        [TestCase(-1, "Height",
            TestName = "Тест присваивания {0} в TableTopParameters.{1}. Негативный тест.")]
        [TestCase(-1, "Number",
            TestName = "Тест присваивания {0} в TableTopParameters.{1}. Негативный тест.")]
        [TestCase(-1, "Value",
            TestName = "Тест присваивания {0} в TableTopParameters.{1}. Негативный тест.")]
        public void TableLegsParameters_WrongArgument_ThrowsExceptionResult(
            double value,
            string parameter)
        {
            // SetUp
            var parameters = new TableLegsParameters();

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                parameters.Height = parameter == "Height"
                    ? value 
                    : 650;
                parameters.Number = parameter == "Number"
                    ? (int)value 
                    : 4;
                parameters.Value = parameter == "Value" 
                    ? value 
                    : 50;
            }, $"Ошибка присвоения неправильного значения "
               + "в TableLegsParameters.{parameter}");
        }
        
        /// <param name="value">Присваиваемое значение.</param>
        /// <param name="parameter">В какой параметр будет присваиваться значение.</param>
        [TestCase(900, ParametersType.TableTopLength,
            TestName = "Тест присваивания {0} в TableParameters.TableTop.{1}. Негативный тест.")]
        [TestCase(500, ParametersType.TableTopWidth,
            TestName = "Тест присваивания {0} в TableParameters.TableTop.{1}. Негативный тест.")]
        [TestCase(20, ParametersType.TableTopHeight,
            TestName = "Тест присваивания {0} в TableParameters.TableTop.{1}. Негативный тест.")]
        [TestCase(500, ParametersType.TableLegsHeight,
            TestName = "Тест присваивания {0} в TableParameters.TableLegs.{1}. Негативный тест.")]
        [TestCase(3, ParametersType.TableLegsNumber,
            TestName = "Тест присваивания {0} в TableParameters.TableLegs.{1}. Негативный тест.")]
        [TestCase(30, ParametersType.TableLegsDiameter,
            TestName = "Тест присваивания {0} в TableParameters.TableLegs.{1}. Негативный тест.")]
        [TestCase(10, ParametersType.HoleRadius,
            TestName = "Тест присваивания {0} в TableParameters.TableHole.{1}. Негативный тест.")]
        [TestCase(110, ParametersType.HoleParamX,
            TestName = "Тест присваивания {0} в TableParameters.TableHole.{1}. Негативный тест.")]
        [TestCase(80, ParametersType.HoleParamY,
            TestName = "Тест присваивания {0} в TableParameters.TableHole.{1}. Негативный тест.")]
        public void TableParameters_WrongArgument_ThrowsExceptionResult(
            double value,  
            ParametersType parameter)
        {
            // SetUp
            var parameters = new TableParameters();
            var addInfo = parameters
                .AdditionalParameters
                .FirstOrDefault(x => x.Key == parameter)
                .Value;
            
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                parameters.TableTop = new TableTopParameters
                {
                    Length =  parameter == ParametersType.TableTopLength
                        ? value 
                        : 1500,
                    
                    Width = parameter == ParametersType.TableTopWidth
                        ? value 
                        : 700,
                    
                    Height = parameter == ParametersType.TableTopHeight
                        ? value 
                        : 40,
                };

                parameters.TabLegs = new TableLegsParameters
                {
                    Height = parameter == ParametersType.TableLegsHeight
                        ? value 
                        : 650,
                    
                    Number = parameter == ParametersType.TableLegsNumber 
                        ?  (int) value 
                        : 4,
                    
                    Value = parameter == ParametersType.TableLegsDiameter 
                        ? value 
                        : 50,
                };

                parameters.TableHole = new TableHoleParameters
                {
                    Radius = parameter == ParametersType.HoleRadius 
                        ? value 
                        : 25,
                    ParamX = parameter == ParametersType.HoleParamX 
                        ? value 
                        : 900,
                    ParamY = parameter == ParametersType.HoleParamY 
                        ? value 
                        : 400,
                };
            }, $"Значение '{addInfo.Name}' должно быть "
               + "в диапозоне от {addInfo.Min} до {addInfo.Max}.");
        }
        
        [TestCase(TestName = "Тест на присваивание неправильного "
                             + "количества ножек. Негативный тест.")]
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
                
            }, "Значение 'Количество ножек' должно быть "
               + "в диапозоне от 5 до 5.");
        }
        
        /// <param name="value">Присваиваемое значение.</param>
        /// <param name="parameter">Параметр.</param>
        /// <param name="name">Имя поля.</param>
        /// <param name="range">Диапозон.</param>
        [TestCase(
            1000, 
            ParametersType.HoleParamX,
            "Расстояние по длине", 
            new[] { 935, 1065 },
            TestName = "Тест на пересечение недопустимого диапозона "
                       + "в поле {3}. Негативный тест.")]
        [TestCase(
                350, 
                ParametersType.HoleParamY, 
                "Расстояние по ширине", 
                new[] { 285, 415 },
            TestName = "Тест на пересечение недопустимого диапозона "
                       + "в поле {3}. Негативный тест.")]
        public void TableParameters_WrongCoordinates_ThrowsExceptionResult(
            double value,
            ParametersType parameter,
            string name,
            int[] range)
        {
            // SetUp
            var parameters = new TableParameters
            {
                TableTop = new TableTopParameters
                {
                    Length = 2000, 
                    Width = 700, 
                    Height = 40,
                },
                
                TabLegs = new TableLegsParameters
                {
                    Height = 650,
                    Number = 5,
                    Value = 50,
                }
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                parameters.TableHole = new TableHoleParameters
                {
                    Radius = 20,
                    ParamX = parameter == ParametersType.HoleParamX 
                        ? value 
                        : 1200,
                    ParamY = parameter == ParametersType.HoleParamY 
                        ? value 
                        : 250,
                };

            }, $"Значение '{name}' не должно пересекать диапозоне "
               + $"от {range[0]} до {range[1]}.");
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
