using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit9_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Exception[] exceptions = new Exception[]{ new MyException("Мое исключение"),
                                                      new FormatException("Неверный формат"),
                                                      new OverflowException("Переполнение"),
                                                      new TimeoutException("Интервал времени, выделенный для операции, истек"),
                                                      new DivideByZeroException("Деление на ноль")};

            foreach (var item in exceptions)
            {
                try
                {
                    throw item; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadKey();
        }
    }
}
