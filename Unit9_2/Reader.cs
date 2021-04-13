using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit9_2
{
    public class Reader
    {
        public delegate void ReadHandler(int number);
        public event ReadHandler ReadEvent;

        public void Read()
        {
            int number;
            bool res = true;

            while (res)
            {
                try
                {
                    number = GetNumberFromConsole("Выберите направление сортировки: 1 - А-Я, 2 - Я-А ");
                    res = false;
                    ReadEvent?.Invoke(number);
                }
                catch (MyException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (res)
                    {
                        Console.WriteLine("Попробуйте еще раз!");
                    }
                }
            }
        }

        private int GetNumberFromConsole(string title)
        {
            Console.WriteLine(title);
            string inputString = Console.ReadLine();
            return CheckNum(inputString);
        }

        private int CheckNum(string num)
        {
            if (int.TryParse(num, out int numToCheck))
            {
                if (numToCheck == 1 || numToCheck == 2)
                {
                    return numToCheck;
                }
                else
                {
                    throw new MyException("Число должно быть 1 или 2!");
                }
            }
            else
            {
                throw new MyException("Значение должно быть числом!");
            }
        }
    }
}
