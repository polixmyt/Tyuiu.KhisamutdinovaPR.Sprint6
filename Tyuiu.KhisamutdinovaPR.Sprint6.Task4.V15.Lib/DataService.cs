using System;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task4.V15.Lib
{
    public class DataService : ISprint6Task4V15
    {
        // Табулирование функции F(x) на отрезке [startValue; stopValue] с шагом 1
        public double[] GetMassFunction(int startValue, int stopValue)
        {
            int length = stopValue - startValue + 1;
            double[] result = new double[length];

            int index = 0;

            for (int x = startValue; x <= stopValue; x++)
            {
                double y;

                double denominator = 3.0;

                if (denominator == 0)
                {
                    y = 0.0; // формальная проверка деления на ноль
                }
                else
                {
                    // F(x) = sin(x) + (2x / 3) - cos(x) * 4x
                    y = Math.Sin(x) + (2.0 * x) / denominator - Math.Cos(x) * 4.0 * x;
                }

                y = Math.Round(y, 2);   // округление до 2 знаков
                result[index] = y;
                index++;
            }

            return result;
        }
    }
}