using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Tyuiu.KhisamutdinovaPR.Sprint6.Task5.V8.Lib;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task5.V8
{
    public partial class FormMain : Form
    {
        DataService ds = new DataService();

        public FormMain()
        {
            InitializeComponent();

            // Настройка таблиц
            dataGridViewValues.ColumnCount = 1;
            dataGridViewValues.Columns[0].HeaderText = "Все значения";

            dataGridViewNegative.ColumnCount = 1;
            dataGridViewNegative.Columns[0].HeaderText = "Меньше 0";

            // Настройка диаграммы
            chartNegative.Series.Clear();
            var series = new Series("Отрицательные");
            series.ChartType = SeriesChartType.Column;
            chartNegative.Series.Add(series);
            chartNegative.ChartAreas[0].AxisX.Title = "№";
            chartNegative.ChartAreas[0].AxisY.Title = "Значение";
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                // путь к входному файлу (подправь при необходимости)
                string path = @"InPutDataFileTask5V8.txt";

                if (!File.Exists(path))
                {
                    MessageBox.Show($"Файл не найден:\n{path}");
                    return;
                }

                // 1. Читаем все числа из файла для вывода в DataGridView
                string text = File.ReadAllText(path);
                string[] parts = text.Split(
                    new[] { ' ', '\t', '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries);

                double[] allValues = parts
                    .Select(p => double.Parse(
                        p.Replace(',', '.'),
                        CultureInfo.InvariantCulture))
                    .ToArray();

                // 2. Получаем отрицательные числа через библиотеку
                double[] negativeValues = ds.LoadFromDataFile(path);

                // 3. Выводим все числа
                dataGridViewValues.Rows.Clear();
                foreach (double v in allValues)
                {
                    dataGridViewValues.Rows.Add(Math.Round(v, 3));
                }

                // 4. Выводим отрицательные числа
                dataGridViewNegative.Rows.Clear();
                foreach (double v in negativeValues)
                {
                    dataGridViewNegative.Rows.Add(v); // уже округлены в библиотеке
                }

                // 5. Строим диаграмму по отрицательным
                chartNegative.Series[0].Points.Clear();
                for (int i = 0; i < negativeValues.Length; i++)
                {
                    chartNegative.Series[0].Points.AddXY(i + 1, negativeValues[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}