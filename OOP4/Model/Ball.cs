using System;

namespace Model
{
    /// <summary>
    /// Класс описывающий шар
    /// </summary>
    [Serializable]
    public class Ball : FigureBase
    {
        /// <summary>
        /// Радиус
        /// </summary>
        private double _radius;
        /// <summary>
        /// Свойство Радиуса
        /// </summary>
        public double Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = Validation.MeasurementValidation(value);
            }
        }
        /// <summary>
        /// Объем
        /// </summary>
        public double Volume
        {
            get
            {
                return  Math.Round((Math.Pow(_radius, 3) * Math.PI * 4/3),3);
            }
        }

        /// <summary>
        /// Конструктор шара
        /// </summary>
        /// <param name="radius">радиус</param>
        public Ball(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        ///  Информация о объеме
        /// </summary>
        public override string GetInfo()
        {
            return String.Format("{0};{1};{2}",
                Radius, Radius, Volume);
        }
    }
}
