using System;
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
    }
}
