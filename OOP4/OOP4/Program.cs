using System;
using Model;

namespace SadokhinaOOP4
{
    /// <summary>
    /// Основной класс программы
    /// </summary>
    class Program
    {
        /// <summary>
        /// Тестирование программы
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Программа запущена");
            Console.WriteLine("\nВыберите действие:\n");

            while (true)
            {
                try
                {
                    Console.WriteLine("1 - Расчет объема пирамиды;");
                    Console.WriteLine("2 - Расчет объема паралелепипеда;");
                    Console.WriteLine("3 - Расчет объема шара;");
                    Console.WriteLine("4 - Выход из приложения.");
                    var keyMenu = Console.ReadLine();
                    switch (keyMenu)
                    {
                        case "1":
                            {
                                GetInfo(new Pyramid
                                    (GetCorrectDouble("Основание пирамиды:"),
                                    GetCorrectDouble("Высота пирамиды:")));
                                break;
                            }
                        case "2":
                            {
                                GetInfo(new Parallelepiped
                                    (GetCorrectDouble("Высота паралелепипеда:"),
                                    GetCorrectDouble("Ширина паралелепипеда:"),
                                    GetCorrectDouble("Длина паралелепипеда:")));
                                break;
                            }
                        case "3":
                            {
                                GetInfo(new Ball
                                    (GetCorrectDouble("Радиус шара:")));
                                break;
                            }
                        case "4":
                            {
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            Console.WriteLine("Ошибка! Такого действия нет.");
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        /// <summary>
        /// Проверка на наличие букв
        /// </summary>
        /// /// <returns>Проверенное введенное измерение</returns>
        static double GetCorrectDouble(string message)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(message);
                    return Validation.MeasurementValidation(Convert.ToDouble(Console.ReadLine()));
                }
                catch
                {
                    Console.WriteLine("Ошибка! Введите неотрицательное число.");
                }
            }
        }
        /// <summary>
        /// Вывод рассчитанной площади в консоль
        /// </summary>
        static void GetInfo(FigureBase figureBase)
        {
            //Console.WriteLine($"Площадь фигуры = {figureBase.GetInfo}\n");
        }
    }
}
