using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task5.V8.Lib
{
    public class DataService
    {
        // Чтение данных из файла
        public List<double> LoadFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Файл не найден", path);

            string text = File.ReadAllText(path).Trim();
            var numbers = text.Split(' ')
                              .Select(x => double.Parse(x.Replace(',', '.'),
                              System.Globalization.CultureInfo.InvariantCulture))
                              .ToList();

            return numbers;
        }

        // Отбор отрицательных чисел
        public List<double> GetNegative(List<double> data)
        {
            return data.Where(x => x < 0).ToList();
        }
    }
}