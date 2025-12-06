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
        /// Читает числа из файла и возвращает массив ТОЛЬКО отрицательных значений,
        /// округлённых до трёх знаков после запятой.
        /// </summary>
        /// <param name="path">Полный путь к входному файлу</param>
        /// <returns>Массив отрицательных чисел</returns>
        public double[] LoadFromDataFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Путь к файлу не указан", nameof(path));

            if (!File.Exists(path))
                throw new FileNotFoundException("Файл не найден", path);

            string text = File.ReadAllText(path);

            // Разделители — пробел, таб, перевод строки и т.п.
            string[] parts = text.Split(
                new[] { ' ', '\t', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            List<double> negatives = new List<double>();

            foreach (string part in parts)
            {
                // Нормализуем разделитель: и точка, и запятая будут работать
                string normalized = part.Replace(',', '.');

                if (double.TryParse(
                        normalized,
                        NumberStyles.Float,
                        CultureInfo.InvariantCulture,
                        out double value))
                {
                    if (value < 0)
                    {
                        // Округление до трёх знаков после запятой по условию задачи
                        value = Math.Round(value, 3);
                        negatives.Add(value);
                    }
                }
            }

            return negatives.ToArray();
        }
    }
}