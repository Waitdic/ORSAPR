using System;

namespace TablePlugin.BLL.Common
{
    /// <summary>
    /// Класс с методавми для валидации присваиваемых параметров стола.
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
    }
}