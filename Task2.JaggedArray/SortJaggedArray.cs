using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray
{
    public static class SortJaggedArray
    {
        /// <summary>
        /// Перечисление задает порядок сортировки
        /// </summary>
        public enum OrderSort
        {
            SortUpBySum,
            SortDownBySum,
            SortUpByMaxElement,
            SortDownByMaxElement,
            SortUpByMinElement,
            SortDownByMinElement,
        }

        /// <summary>
        /// метод сортирует ссылки jagged массива пузырьковой сортировкой
        /// </summary>
        /// <param name="array">jagged массива для сортировки</param>
        /// <param name="orderSort">параметр сортировки</param>
        public static void Sort(int[][] array, OrderSort orderSort)
        {
            for (int i = 0; i < array.GetLength(0) - 1; i++)
            {
                if (!RefIsNull(array, i))
                    break;

                for (int j = i + 1; j < array.GetLength(0); j++)
                {
                    if (!RefIsNull(array, j))
                        break;

                    ChooseSort(array, i, j, orderSort);
                }
            }
        }

        /// <summary>
        /// выбирает способ сортировки в зависимости от выбора пользователя
        /// </summary>
        /// <param name="array">массив для сортировки</param>
        /// <param name="i">указатель на первую ссылку</param>
        /// <param name="j">указатель на вторую ссылку</param>
        /// <param name="orderSort">выбранный тип сортировки</param>
        private static void ChooseSort(int[][] array, int i, int j, OrderSort orderSort)
        {
            switch (orderSort)
            {
                case OrderSort.SortUpBySum:
                    if (SumArray(array[i]) < SumArray(array[j]))
                        Swap(ref array[i], ref array[j]);
                    break;

                case OrderSort.SortDownBySum:
                    if (SumArray(array[i]) > SumArray(array[j]))
                        Swap(ref array[i], ref array[j]);
                    break;

                case OrderSort.SortUpByMaxElement:
                    if (MaxElementArray(array[i]) < MaxElementArray(array[j]))
                        Swap(ref array[i], ref array[j]);
                    break;

                case OrderSort.SortDownByMaxElement:
                    if (MaxElementArray(array[i]) > MaxElementArray(array[j]))
                        Swap(ref array[i], ref array[j]);
                    break;

                case OrderSort.SortUpByMinElement:
                    if (MinElementArray(array[i]) < MinElementArray(array[j]))
                        Swap(ref array[i], ref array[j]);
                    break;

                case OrderSort.SortDownByMinElement:
                    if (MinElementArray(array[i]) > MinElementArray(array[j]))
                        Swap(ref array[i], ref array[j]);
                    break;
            }
        }

        /// <summary>
        /// Метод проверяет ссылку на null
        /// </summary>
        /// <param name="array">jagged array для проверки</param>
        /// <param name="index">индекс указывающий на проверяемую ссылку</param>
        /// <returns></returns>
        private static bool RefIsNull(int[][] array, int index)
        {
            if (array[index] == null)
            {
                int endArray = array.GetLength(0) - 1;

                do
                {
                    if (array[endArray] != null)
                    {
                        Swap(ref array[index], ref array[endArray]);
                        return true;
                    }
                    --endArray;
                }
                while (endArray > index);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Данный метод высчитывает сумму элементов массива
        /// </summary>
        /// <param name="array">входной массив с элементами</param>
        /// <returns>сумма элементов массива</returns>
        private static int SumArray(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i];
            return sum;
        }

        /// <summary>
        /// Находит максимальный элемент в массиве
        /// </summary>
        /// <param name="array">массив для поиска</param>
        /// <returns>максимальный элемент в массиве</returns>
        private static int MaxElementArray(int[] array)
        {
            int maxElement = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (maxElement < array[i])
                    maxElement = array[i];
            }
            return maxElement;
        }

        /// <summary>
        /// Находит минимальный элемент в массиве
        /// </summary>
        /// <param name="array">массив для поиска</param>
        /// <returns>минимальный элемент в массиве</returns>
        private static int MinElementArray(int[] array)
        {
            int maxElement = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (maxElement > array[i])
                    maxElement = array[i];
            }
            return maxElement;
        }

        /// <summary>
        /// Метод меняет местами ссылки на массив
        /// </summary>
        /// <param name="array1">ссылка на первый массив int</param>
        /// <param name="array2">ссылка на второй массив int</param>
        private static void Swap(ref int[] array1, ref int[] array2)
        {
            int[] temp = array1;
            array1 = array2;
            array2 = temp;
        }
    }
}
