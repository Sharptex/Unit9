using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit9_2
{
    class Program
    {
        static string[] lastNames = new string[] { "Иванов", "Петров", "Сидоров", "Федоров", "Антонов" };

        static void Main(string[] args)
        {
            var read = new Reader();
            read.ReadEvent += Sort;
            read.Read();

            Console.ReadKey();
        }

        private static void Sort(int number)
        {
            string[] arr = new string[] { };

            switch (number)
            {
                case 1:
                    arr = SortAlphabetically(lastNames, false);
                    break;
                case 2:
                    arr = SortAlphabetically(lastNames, true);
                    break;
            }

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        private static string[] SortAlphabetically(string[] arr, bool isAscending)
        {
            int sortDirection;
            if (isAscending) { sortDirection = -1; } else { sortDirection = 1; }

            string[] sortedArr = new string[arr.Length];
            sortedArr[0] = arr[0];
            int currentLength = 0;
            string temp;

            for (int i = 1; i < lastNames.Length; i++)
            {
                currentLength++;
                sortedArr[currentLength] = lastNames[i];
                for (int j = currentLength; j > 0; j--)
                {
                    if (sortedArr[j - 1].CompareTo(sortedArr[j]) == sortDirection)
                    {
                        temp = sortedArr[j];
                        sortedArr[j] = sortedArr[j - 1];
                        sortedArr[j - 1] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return sortedArr;
        }
    }
}
