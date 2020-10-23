using System;

namespace Model
{
    /// <summary>
    /// Класс описывающий пирамиду
    /// </summary>
    [Serializable]
    public class Pyramid : FigureBase
    {
        /// <summary>
        /// Площадь основания пирамиды
        /// </summary>
        private double _pyramidBase;
        /// <summary>
        /// Высота
        /// </summary>
        private double _heigth;
        /// <summary>
        /// Свойство площади основания пирамиды
        /// </summary>
        public double PyramidBase
        {
            get
            {
                return _pyramidBase;
            }
            set
            {
                _pyramidBase = Validation.MeasurementValidation(value);
            }
        }
        /// <summary>
        /// Свойство высоты пирамиды
        /// </summary>
        public double Heigth
        {
            get
            {
                return _heigth;
            }
            set
            {
                _heigth = Validation.MeasurementValidation(value);
            }
        }
       
        
        /// <summary>
        /// Объем
        /// </summary>
        public double Volume
        {
            get
            {
                return Math.Round(((_pyramidBase * _heigth) / 3), 3);
            }
        }
        /// <summary>
        /// Конструктор пирамиды
        /// </summary>
        /// <param name="pyramidBase">Площадь основания пирамиды</param>
        /// <param name="heigth">Высота</param>
        public Pyramid(double pyramidBase, double heigth)
        {
            Heigth = heigth;
            PyramidBase = pyramidBase;
        }
        /// <summary>
        ///  Информация о площади
        /// </summary>
        public override string GetInfo()
        {
            return String.Format("{0};{1};{2}",
                Heigth, PyramidBase, Volume);
        }
    }
}