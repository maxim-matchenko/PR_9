using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PR_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "Практическая работа № 9.";
            Console.OutputEncoding = Encoding.UTF8; // важно 
            Console.Clear(); // очистка экрана
            Console.WriteLine("Здравствуйте!");
            try
            {
                string Select;// Переменная для контроля повторного запуска
                do
                {
                    Console.WriteLine("\n--- Новый расчет ---");
                    // 1. Объявление и инициализация
                    const int m = 10; // задание размерности массива 
                    double[] array = new double[m]; // объявление одномерного массива 
                    double sum = 0; // инициализация суммы 
                    bool err = false; // флаг обнаружения ошибки при вводе элементов массива
                    int i = 0;
                    // 2. Заполнение массива с клавиатуры
                    while (i < m)
                    {
                        err = false; // ошибки нет
                        Console.Write($"Введите {i} элемент: ");
                        try

                        {
                            array[i] = Convert.ToDouble(Console.ReadLine()); // запись числа в текущий элемент массива 
                        }
                        catch (FormatException e)// обработка исключений
                        {
                            err = true;// ошибка ввода
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Возникла ошибка. {e.Message}");
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        if (!err) // если ошибки нет, переходим к следующему элементу массива
                            i++;
                    }
                    // 3. Подсчет суммы элементов массива 
                    for (i = 0; i < m; i++)
                    {
                        sum += array[i];
                    }
                    // 4. Расчет среднего арифметического
                    double SRA = sum / m;
                    // 5. Расчет дисперсии
                    double SK = 0;
                    for (i = 0; i < m; i++)
                    {
                        SK += Math.Pow(array[i] - SRA, 2);
                    }
                    double D = SK / m; // дисперсия
                    // 6. Расчет среднего квадратичного отклонения
                    double SKO = Math.Sqrt(D);
                    // 7. Вывод результатов на экран
                    Console.Write("\nИсходный массив: ");
                    for (i = 0; i < m; i++)
                    {
                        Console.Write(array[i] + " ");// вывод элементов в одну строку
                    }
                    Console.WriteLine($"\n\nСреднее арифметическое: {SRA:F3}");
                    Console.WriteLine($"Дисперсия: {D:F3}");
                    Console.WriteLine($"Среднее квадратичное отклонение: {SKO:F3}");
                    Console.Write("\nХотите выполнить программу еще раз? (да - 1/нет - любая клавиша): ");
                    Select = Console.ReadLine();
                }
                while (Select == "1");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Возникла ошибка. {ex.Message}");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.ReadKey(); // задержка экрана
            }
        }
    }
}