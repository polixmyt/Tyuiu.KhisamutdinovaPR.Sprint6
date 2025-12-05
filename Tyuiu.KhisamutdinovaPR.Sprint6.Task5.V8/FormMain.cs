using System;
using System.IO;
using System.Windows.Forms;
using Tyuiu.KhisamutdinovaPR.Sprint6.Task5.V8.Lib;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task5.V8
{
    public partial class FormMain : Form
    {
        DataService ds = new DataService();

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"InPutFileTask5V8.txt";

                var numbers = ds.LoadFromFile(path);
                var negative = ds.GetNegative(numbers);

                // Очистка DataGridView
                dataGridViewInput.Rows.Clear();
                dataGridViewInput.Columns.Clear();
                dataGridViewInput.Columns.Add("col1", "Значение");

                // Вывод всех чисел
                foreach (double n in numbers)
                {
                    dataGridViewInput.Rows.Add(Math.Round(n, 3));
                }

                // Вывод отрицательных чисел в TextBox
                textBoxOutput.Text = "";
                foreach (double n in negative)
                {
                    textBoxOutput.AppendText(Math.Round(n, 3) + Environment.NewLine);
                }

                // Заполнение графика
                chartValues.Series[0].Points.Clear();
                int index = 1;
                foreach (var n in negative)
                {
                    chartValues.Series[0].Points.AddXY(index, n);
                    index++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}