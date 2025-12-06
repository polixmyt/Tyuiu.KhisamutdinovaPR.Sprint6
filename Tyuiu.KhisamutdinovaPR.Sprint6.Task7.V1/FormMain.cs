using System;
using System.Windows.Forms;
using Tyuiu.KhisamutdinovaPR.Sprint6.Task7.V1.Lib;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task7.V1
{
    public partial class FormMain : Form
    {
        DataService ds = new DataService();

        int[,] matrixIn;
        int[,] matrixOut;

        public FormMain()
        {
            InitializeComponent();

            dataGridViewIn.ReadOnly = true;
            dataGridViewIn.AllowUserToAddRows = false;

            dataGridViewOut.ReadOnly = true;
            dataGridViewOut.AllowUserToAddRows = false;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string path = ofd.FileName;

                    // исходная матрица
                    matrixIn = ds.LoadFromCsv(path);
                    // обработанная матрица (по интерфейсу)
                    matrixOut = ds.GetMatrix(path);

                    ShowMatrix(matrixIn, dataGridViewIn);
                    ShowMatrix(matrixOut, dataGridViewOut);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (matrixOut == null || matrixOut.Length == 0)
            {
                MessageBox.Show("Нет данных для сохранения");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "OutPutFileTask7V1.csv";
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ds.SaveToCsv(sfd.FileName, matrixOut);
                    MessageBox.Show("Файл сохранён");
                }
            }
        }

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