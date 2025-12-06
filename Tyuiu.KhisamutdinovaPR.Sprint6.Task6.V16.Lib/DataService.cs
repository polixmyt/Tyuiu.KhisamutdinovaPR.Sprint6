using System;
using System.IO;
using System.Linq;
using System.Text;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task6.V16.Lib
{
    public class DataService : ISprint6Task6V16
    {
        // Читает файл и возвращает строку из слов, содержащих букву 'в' или 'В'
        public string CollectTextFromFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Путь к файлу не указан", nameof(path));

            if (!File.Exists(path))
                throw new FileNotFoundException("Файл не найден", path);

            string text = File.ReadAllText(path);

            // Разделяем по пробелам и знакам препинания
            char[] separators = new char[]
            {
                ' ', '\t', '\r', '\n',
                ',', '.', '!', '?', ';', ':', '-', '(', ')', '[', ']', '\"', '\''
            };

            string[] words = text
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // Берём только те слова, где есть 'в' или 'В'
            var filtered = words
                .Where(w => w.IndexOf('в', StringComparison.OrdinalIgnoreCase) >= 0)
                .ToArray();

            // Собираем в результирующую строку через пробел
            string result = string.Join(" ", filtered);

            return result;
        }
    }
}