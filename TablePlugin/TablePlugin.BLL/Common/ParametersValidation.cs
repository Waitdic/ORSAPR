using System;

namespace TablePlugin.BLL.Common
{
    /// <summary>
    /// Класс с методами для валидации присваиваемых параметров стола.
    /// </summary>
    public static class ParametersValidation
    {
        /// <summary>
        /// Проверка присваиваемого значения.
        /// </summary>
        /// <param name="value">Присваиваемая переменная.</param>
        /// <param name="name">Имя параметра.</param>
        public static void ValidateValue(double value, string name)
        {
            if (Math.Abs(value - Math.Truncate(value)) > 0.001d)
            {
                throw new ArgumentException($"Значение поля '{name}' не может быть дробным");
            }

            if (value <= 0)
            {
                throw new ArgumentException($"{name} не может быть меньше или равна нулю!");
            }
        }

        /// <summary>
        /// Проверка min/max значений.
        /// </summary>
        /// <param name="min">Минимальное значение.</param>
        /// <param name="max">Максимальное значение.</param>
        /// <exception cref="ArgumentException">Неправильное значение.</exception>
        public static void ValidateMinMaxValue(double min, double max)
        {
            if (min > max)
            {
                throw new ArgumentException("Min не может быть больше Max");
            }
        }

        /// <summary>
        /// Проверка на пересечение диапозона.
        /// </summary>
        /// <param name="left">Левое ограничение координат.</param>
        /// <param name="right">Правое ограничение координат.</param>
        /// <param name="param">Значение координат.</param>
        /// <param name="name">Имя првоверяемого поля.</param>
        public static void CheckCrossingOfRange(double left, double right, double param, string name)
        {
            if (left < param && param < right)
            {
                throw new ArgumentException(
                    $"Значение '{name}' не должно пересекать диапозоне от {left} до {right}.");
            }
        }
    }
}