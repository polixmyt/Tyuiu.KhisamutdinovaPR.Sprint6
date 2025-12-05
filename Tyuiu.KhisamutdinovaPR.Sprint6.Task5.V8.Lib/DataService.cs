// Author: Хисамутдинова Полина
// Project: Tyuiu.KhisamutdinovaPR.Sprint6.Task5.V8.Lib

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task5.V8.Lib
{
    public class DataService : ISprint6Task5V8
    {
        // Читает ВСЕ числа из файла и возвращает их в виде массива double,
        // округлённых до 3 знаков после запятой.
        public double[] LoadFromDataFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Путь к файлу не указан", nameof(path));

            if (!File.Exists(path))
                throw new FileNotFoundException("Файл не найден", path);

            string text = File.ReadAllText(path);

            string[] parts = text.Split(
                new[] { ' ', '\t', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            List<double> values = new List<double>();

            foreach (string part in parts)
            {
                // Меняем запятую на точку, чтобы работали оба варианта записи
                string normalized = part.Replace(',', '.');

                if (double.TryParse(normalized,
                                    NumberStyles.Float,
                                    CultureInfo.InvariantCulture,
                                    out double value))
                {
                    value = Math.Round(value, 3); // по условию – до трёх знаков
                    values.Add(value);
                }
            }

            return values.ToArray();
        }
    }
}