// Author: Хисамутдинова Полина
// Project: Tyuiu.KhisamutdinovaPR.Sprint6.Task7.V1
// Description: Работа с матрицей из CSV-файла. Замена
//              отрицательных значений во втором столбце на 1.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task7.V1.Lib
{
    public class DataService
    {
        /// <summary>
        /// Чтение матрицы целых чисел из CSV-файла.
        /// Разделители: ; , пробел, таб.
        /// </summary>
        public int[,] LoadFromCsv(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Путь к файлу пуст", nameof(path));

            if (!File.Exists(path))
                throw new FileNotFoundException("Файл не найден", path);

            string[] lines = File.ReadAllLines(path, Encoding.UTF8);

            var rows = new List<int[]>();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(
                    new[] { ';', ',', ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries);

                int[] row = new int[parts.Length];

                for (int i = 0; i < parts.Length; i++)
                {
                    row[i] = int.Parse(parts[i]);
                }

                rows.Add(row);
            }

            if (rows.Count == 0)
                return new int[0, 0];

            int rowCount = rows.Count;
            int colCount = rows[0].Length;

            int[,] matrix = new int[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                if (rows[i].Length != colCount)
                    throw new InvalidOperationException("Строки в файле имеют разную длину.");

                for (int j = 0; j < colCount; j++)
                {
                    matrix[i, j] = rows[i][j];
                }
            }

            return matrix;
        }

        /// <summary>
        /// Заменяет во втором столбце все отрицательные значения на 1.
        /// Возвращает новую матрицу.
        /// </summary>
        public int[,] ReplaceNegativeInSecondColumnWithOne(int[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (j == 1 && matrix[i, j] < 0) // второй столбец (индекс 1)
                    {
                        result[i, j] = 1;
                    }
                    else
                    {
                        result[i, j] = matrix[i, j];
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Сохранение матрицы в CSV-файл (разделитель ;) .
        /// </summary>
        public void SaveToCsv(string path, int[,] matrix)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Путь к файлу пуст", nameof(path));

            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            var sb = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sb.Append(matrix[i, j]);
                    if (j < cols - 1)
                        sb.Append(';');
                }
                sb.AppendLine();
            }

            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }
    }
}