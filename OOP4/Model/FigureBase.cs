using System;

namespace Model
{
    /// <summary>
    /// Базовый абстрактный класс для  фигур
    /// </summary>
    [Serializable]
    public abstract class FigureBase
    {
        /// <summary>
        /// Информация о объеме
        /// </summary>
        public abstract string GetInfo();
    }
}
