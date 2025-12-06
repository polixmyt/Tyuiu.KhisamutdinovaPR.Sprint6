using System;
using System.IO;
using System.Windows.Forms;
using Tyuiu.KhisamutdinovaPR.Sprint6.Task6.V16.Lib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task6.V16
{
    public partial class FormMain : Form
    {
        DataService ds = new DataService();
        string currentFilePath = string.Empty;

        public FormMain()
        {
            InitializeComponent();
        }

        // Кнопка "Открыть файл"
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите файл InPutFileTask6V16.txt";
            ofd.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = ofd.FileName;

                // Загружаем текст в textBoxIn
                textBoxIn.Text = File.ReadAllText(currentFilePath);
            }
        }

        // Кнопка "Выполнить"
        private void buttonDo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentFilePath))
            {
                MessageBox.Show("Сначала выберите файл через кнопку \"Открыть файл\".",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string result = ds.CollectTextFromFile(currentFilePath);
                textBoxOut.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}