using System;

namespace Model
{
    /// <summary>
    /// Класс описывающий паралелепипед
    /// </summary>
    [Serializable]
    public class Parallelepiped : FigureBase
    {
        /// <summary>
        /// Ширина
        /// </summary>
        private double _width;
        /// <summary>
        /// Длина
        /// </summary>
        private double _length;
        /// <summary>
        /// Высота
        /// </summary>
        private double _height;
        /// <summary>
        /// Свойство Ширины
        /// </summary>
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = Validation.MeasurementValidation(value);
            }
        }
        /// <summary>
        /// Свтойство Длины
        /// </summary>
        public double Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = Validation.MeasurementValidation(value);
            }
        }
        /// <summary>
        /// Свтойство Длины
        /// </summary>
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = Validation.MeasurementValidation(value);
            }
        }
        /// <summary>
        /// Свтойство объема и его расчет
        /// </summary>
        public double Volume
        {
            get
            {
                return Math.Round((_width*_length*_height), 3);
            }
        }
        /// <summary>
        /// Конструктор паралелепипеда
        /// </summary>
        /// <param name="width">Ширина</param>
        /// <param name="length">Длина</param>
        /// <param name="height">Высота</param>
        public Parallelepiped(double width, double length, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        /// <summary>
        ///  Информация о объеме
        /// </summary>
        public override string GetInfo()
        {
            return String.Format("{0};{1};{2};{3}",
                Length, Width, Height, Volume);
        }
    }
}
