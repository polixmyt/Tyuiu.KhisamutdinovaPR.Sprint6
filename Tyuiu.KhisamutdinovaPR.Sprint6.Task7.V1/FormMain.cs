// Author: Хисамутдинова Полина
// Project: Tyuiu.KhisamutdinovaPR.Sprint6.Task7.V1
// Description: Загрузка матрицы из CSV, изменение,
//              вывод в два DataGridView и сохранение результата.

using System;
using System.Windows.Forms;
using Tyuiu.KhisamutdinovaPR.Sprint6.Task7.V1.Lib;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task7.V1
{
    public partial class FormMain : Form
    {
        private readonly DataService ds = new DataService();
        private int[,] matrixIn;
        private int[,] matrixOut;

        public FormMain()
        {
            InitializeComponent();

            // Немного настроим DataGridView (можно сделать и в Designer)
            dataGridViewIn.ReadOnly = true;
            dataGridViewIn.AllowUserToAddRows = false;

            dataGridViewOut.ReadOnly = true;
            dataGridViewOut.AllowUserToAddRows = false;
        }

        // Кнопка "Загрузить"
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Выберите файл InPutFileTask7V1.csv";
                ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string path = ofd.FileName;

                        matrixIn = ds.LoadFromCsv(path);
                        matrixOut = ds.ReplaceNegativeInSecondColumnWithOne(matrixIn);

                        ShowMatrix(matrixIn, dataGridViewIn);
                        ShowMatrix(matrixOut, dataGridViewOut);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Ошибка при чтении файла:\n" + ex.Message,
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Кнопка "Сохранить"
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (matrixOut == null || matrixOut.Length == 0)
            {
                MessageBox.Show("Нет данных для сохранения. Сначала загрузите файл.",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Сохранить результат";
                sfd.FileName = "OutPutFileTask7.csv";
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ds.SaveToCsv(sfd.FileName, matrixOut);

                        MessageBox.Show("Файл успешно сохранён.",
                            "Готово",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Ошибка при сохранении файла:\n" + ex.Message,
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Вывод матрицы в DataGridView.
        /// </summary>
        private void ShowMatrix(int[,] matrix, DataGridView grid)
        {
            grid.Columns.Clear();
            grid.Rows.Clear();

            if (matrix == null || matrix.Length == 0)
                return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                grid.Columns.Add("col" + j, (j + 1).ToString());
            }

            grid.RowCount = rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    grid[j, i].Value = matrix[i, j];
                }
            }
        }
    }
}