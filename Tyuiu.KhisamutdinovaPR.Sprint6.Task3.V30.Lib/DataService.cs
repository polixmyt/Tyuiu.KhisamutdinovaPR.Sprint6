using System;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task3.V30.Lib
{
    public class DataService : ISprint6Task3V30
    {
        // Заменить чётные значения в последней строке матрицы на 0
        public int[,] Calculate(int[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int lastRow = rows - 1;

            for (int j = 0; j < cols; j++)
            {
                if (matrix[lastRow, j] % 2 == 0)
                {
                    matrix[lastRow, j] = 0;
                }
            }

            return matrix;
        }
    }
}