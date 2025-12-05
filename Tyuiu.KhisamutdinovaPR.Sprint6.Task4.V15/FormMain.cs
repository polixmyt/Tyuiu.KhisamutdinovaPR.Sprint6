using System;
using System.IO;
using System.Windows.Forms;
using Tyuiu.KhisamutdinovaPR.Sprint6.Task4.V15.Lib;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task4.V15
{
    public partial class FormMain : Form
    {
        DataService ds = new DataService();

        int startValue = -5;
        int stopValue = 5;
        double[] values;

        public FormMain()
        {
            InitializeComponent();

            // Настройка Chart
            chartFunction.Series.Clear();
            Series series = new Series("F(x)");
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2;
            chartFunction.Series.Add(series);
            chartFunction.ChartAreas[0].AxisX.Title = "X";
            chartFunction.ChartAreas[0].AxisY.Title = "F(x)";
        }

        // Кнопка "Выполнить"
        private void buttonDone_Click(object sender, EventArgs e)
        {
            values = ds.GetMassFunction(startValue, stopValue);

            // Вывод таблицы в TextBox
            textBoxResult.Clear();
            textBoxResult.AppendText("   x\tF(x)\r\n");
            textBoxResult.AppendText("---------------------\r\n");

            int x = startValue;

            chartFunction.Series[0].Points.Clear();

            for (int i = 0; i < values.Length; i++)
            {
                string line = string.Format("{0,4}\t{1,6:F2}", x, values[i]);
                textBoxResult.AppendText(line + Environment.NewLine);

                // Точка для графика
                chartFunction.Series[0].Points.AddXY(x, values[i]);

                x++;
            }
        }

        // Кнопка "Сохранить в файл"
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (values == null)
            {
                MessageBox.Show("Сначала вычислите значения функции.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string tempDir = Path.GetTempPath();
            string fileName = "OutPutFileTask4V15.txt";
            string fullPath = Path.Combine(tempDir, fileName);

            using (StreamWriter sw = new StreamWriter(fullPath, false))
            {
                int x = startValue;
                for (int i = 0; i < values.Length; i++)
                {
                    sw.WriteLine($"{x}\t{values[i]:F2}");
                    x++;
                }
            }

            MessageBox.Show($"Файл сохранён по пути:\n{fullPath}", "Сохранение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}