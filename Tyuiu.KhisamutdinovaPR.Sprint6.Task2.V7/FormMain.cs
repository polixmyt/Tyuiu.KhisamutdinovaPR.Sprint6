using System;
using System.Windows.Forms;
using Tyuiu.KhisamutdinovaPR.Sprint6.Task2.V7.Lib;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task2.V7
{
    public partial class FormMain : Form
    {
        // объект библиотеки
        DataService ds = new DataService();

        public FormMain()
        {
            InitializeComponent();

            
            dataGridViewFunction.ColumnCount = 2;
            dataGridViewFunction.Columns[0].HeaderText = "X";
            dataGridViewFunction.Columns[1].HeaderText = "F(x)";
            dataGridViewFunction.Columns[0].Width = 60;
            dataGridViewFunction.Columns[1].Width = 80;

            dataGridViewFunction.RowHeadersVisible = false;
            dataGridViewFunction.ReadOnly = true;
            dataGridViewFunction.AllowUserToAddRows = false;
            dataGridViewFunction.AllowUserToDeleteRows = false;
        }

        // обработчик кнопки "Выполнить"
        private void buttonDone_Click(object sender, EventArgs e)
        {
            // Диапазон по условию [-5; 5] с шагом 1
            int startValue = -5;
            int stopValue = 5;

            // получаем массив значений из библиотеки
            double[] values = ds.GetMassFunction(startValue, stopValue);
            int len = values.Length;

            // очищаем грид и задаём нужное количество строк
            dataGridViewFunction.Rows.Clear();
            dataGridViewFunction.RowCount = len;

            int x = startValue;

            for (int i = 0; i < len; i++)
            {
                dataGridViewFunction.Rows[i].Cells[0].Value = x;                 // X
                dataGridViewFunction.Rows[i].Cells[1].Value = values[i].ToString("F2"); // F(x)
                x++;
            }
        }
    }
}