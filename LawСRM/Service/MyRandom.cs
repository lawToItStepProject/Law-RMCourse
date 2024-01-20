using System;

namespace LawСRM
{
    internal static class RandomExtensions
    {
        //Метод расширения, который будет дописываться к классу Random, в качестве параметра передается массив вариантов
        //Метод будет случайным образом выбирать индекс из этого массива и возвращать обратно элемент массива
        public static T NextItem<T>(this Random rnd, params T[] array) => array[rnd.Next(array.Length)];
    }
}
