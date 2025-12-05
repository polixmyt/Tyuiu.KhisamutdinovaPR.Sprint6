using System;
using System.Windows.Forms;
using Tyuiu.KhisamutdinovaPR.Sprint6.Task1.V17.Lib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task1.V17
{
    public partial class FormMain : Form
    {
        DataService ds = new DataService();

        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка корректности ввода
            if (!int.TryParse(textBox1.Text, out int startValue))
            {
                MessageBox.Show("Некорректное значение начала диапазона", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox2.Text, out int stopValue))
            {
                MessageBox.Show("Некорректное значение конца диапазона", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получаем массив значений один раз
            double[] valueArray = ds.GetMassFunction(startValue, stopValue);
            int len = valueArray.Length;

            textBox3.Clear();
            textBox3.AppendText("+----------+----------+" + Environment.NewLine);
            textBox3.AppendText("|    X     |    F     |" + Environment.NewLine);
            textBox3.AppendText("+----------+----------+" + Environment.NewLine);

            int x = startValue;

            for (int i = 0; i < len; i++)
            {
                string strLine = string.Format("|{0,5}    |  {1,6:F2}   |", x, valueArray[i]);
                textBox3.AppendText(strLine + Environment.NewLine);
                x++;
            }

            textBox3.AppendText("+----------+----------+" + Environment.NewLine);
        }
    }
}