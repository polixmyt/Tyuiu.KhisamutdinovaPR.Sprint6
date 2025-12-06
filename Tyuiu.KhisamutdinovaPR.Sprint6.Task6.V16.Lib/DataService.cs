using System;
using System.IO;
using System.Linq;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task6.V16.Lib
{
    public class DataService : ISprint6Task6V16
    {
        // Читаем файл и возвращаем слова, в которых есть латинская буква b/B
        public string CollectTextFromFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Путь к файлу не указан", nameof(path));

            if (!File.Exists(path))
                throw new FileNotFoundException("Файл не найден", path);

            string text = File.ReadAllText(path);

            // Разделители слов
            char[] separators = new char[]
            {
                ' ', '\t', '\r', '\n',
                ',', '.', '!', '?', ';', ':', '-', '(', ')', '[', ']', '\"', '\''
            };

            string[] words = text
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // Берём только слова, в которых встречается латинская b/B
            var filtered = words
                .Where(w => w.IndexOf('b', StringComparison.OrdinalIgnoreCase) >= 0)
                .ToArray();

            // Склеиваем через пробел
            string result = string.Join(" ", filtered);

            return result;
        }
    }
}