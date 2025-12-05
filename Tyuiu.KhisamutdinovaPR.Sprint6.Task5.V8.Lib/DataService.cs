// Author: Хисамутдинова Полина
// Project: Tyuiu.KhisamutdinovaPR.Sprint6.Task5.V8.Lib
// Description: Чтение чисел из файла и выбор всех отрицательных значений

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task5.V8.Lib
{
    public class DataService : ISprint6Task5V8
    {
        /// <summary>
        /// Читает числа из файла и возвращает массив отрицательных значений.
        /// Вещественные числа в файле записаны через пробел (как в твоём InPutDataFileTask5V8.txt).
        /// </summary>
        /// <param name="path">Полный путь к входному файлу</param>
        /// <returns>Массив отрицательных чисел</returns>
        public double[] LoadFromDataFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Путь к файлу не указан", nameof(path));
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Файл не найден", path);
            }

            string text = File.ReadAllText(path);

            // Разбиваем по пробелам, табам и переводам строки
            string[] parts = text.Split(
                new[] { ' ', '\t', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            List<double> negatives = new List<double>();

            foreach (string part in parts)
            {
                // Читаем число в invariant-формате (точка как разделитель)
                double value = double.Parse(part, CultureInfo.InvariantCulture);

                if (value < 0)
                {
                    // Округляем до 3 знаков, как требует задание по Sprint6 Task5
                    value = Math.Round(value, 3);
                    negatives.Add(value);
                }
            }

            return negatives.ToArray();
        }
    }
}