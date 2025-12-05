using System;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task2.V7.Lib
{
    public class DataService : ISprint6Task2V7
    {
        // Табулирование функции на отрезке [startValue; stopValue] с шагом 1.
        // Возвращает массив значений F(x), округлённых до двух знаков.
        public double[] GetMassFunction(int startValue, int stopValue)
        {
            int length = stopValue - startValue + 1;
            double[] result = new double[length];

            int index = 0;

            for (int x = startValue; x <= stopValue; x++)
            {
                double y;
                double denominator = Math.Cos(x) + 1;

                if (denominator == 0)
                {
                    // защита от деления на ноль
                    y = 0.0;
                }
                else
                {
                    // F(x) = 3x + 2 - (2x - x) / (cos(x) + 1)
                    y = 3 * x + 2 - (2 * x - x) / denominator;
                }

                y = Math.Round(y, 2);     // округление до 2 знаков
                result[index] = y;
                index++;
            }

            return result;
        }
    }
}