using System;
using System.Windows.Forms;
using Tyuiu.KhisamutdinovaPR.Sprint6.Task3.V30.Lib;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task3.V30
{
    public partial class FormMain : Form
    {
        DataService ds = new DataService();

        public FormMain()
        {
            InitializeComponent();

            // Настройка DataGridView 5x5
            dataGridViewMatrix.ColumnCount = 5;
            dataGridViewMatrix.RowCount = 5;
            dataGridViewMatrix.RowHeadersVisible = false;
            dataGridViewMatrix.AllowUserToAddRows = false;
            dataGridViewMatrix.AllowUserToDeleteRows = false;
            dataGridViewMatrix.ReadOnly = true;
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            // Исходный массив из условия
            int[,] matrix =
            {
                { -9,  -4,  17,  -1, -20 },
                { -19, 18,  -4,   2,  14 },
                { -12, 16,  -2,   7,  18 },
                { -16, 15,   4,  12, -13 },
                { -15, -4, -16,   1, -14 }
            };

            // Обработка в библиотеке
            int[,] result = ds.Calculate(matrix);

            // Вывод в DataGridView
            int rows = result.GetLength(0);
            int cols = result.GetLength(1);

            dataGridViewMatrix.RowCount = rows;
            dataGridViewMatrix.ColumnCount = cols;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    dataGridViewMatrix.Rows[i].Cells[j].Value = result[i, j];
                }
            }
        }
    }
}