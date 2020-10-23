using System;

namespace Model
{
    /// <summary>
    /// Класс для проверки измерений
    /// </summary>
    public static class Validation
    {
        /// <summary>
        /// Проверка корректности введенного измерения
        /// </summary>
        /// <param name="value">Значение</param>
        /// <returns>Корректное значение</returns>
        public static double MeasurementValidation(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException
                    ("Значение не может быть неопределенным или бесконечным!");
            }
            if (value <= 0)
            {
                throw new ArgumentException("Значение должно быть больше нуля!");
            }
            return value;
        }
    }
}
