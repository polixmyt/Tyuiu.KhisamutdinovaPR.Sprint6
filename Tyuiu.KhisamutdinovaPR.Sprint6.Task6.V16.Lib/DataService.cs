using System;
using System.IO;
using System.Linq;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task6.V16.Lib
{
    public class DataService : ISprint6Task6V16
    {
        public string CollectTextFromFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Путь к файлу не указан", nameof(path));

            if (!File.Exists(path))
                throw new FileNotFoundException("Файл не найден", path);

            string text = File.ReadAllText(path);

            char[] separators = new char[]
            {
                ' ', '\t', '\r', '\n',
                ',', '.', '!', '?', ';', ':', '-', '(', ')', '[', ']', '\"', '\''
            };

            string[] words = text
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // ВАЖНО: берём только слова, где есть ИМЕННО строчная 'b'
            var filtered = words
                .Where(w => w.Contains('b'))   // без ignore-case
                .ToArray();

            string result = string.Join(" ", filtered);

            return result;
        }
    }
}