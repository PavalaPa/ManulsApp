using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manyls;

namespace ManulsApp {
    public partial class FormLR3 : Form {
        public FormLR3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ы p1 = new Ы();
            if (textBox1.Text != "") p1.Name = textBox1.Text;
            p1.Age = (int)numericUpDown1.Value;
            p1.BirthDay = dateTimePicker1.Value;
            if (textBox2.Text != "") p1.Zoo = textBox2.Text;
            richTextBox1.Text += String.Format("Имя: {0}, Возраст: {1}, Дата рождения: {2}, Зоопарк: {3}\n", p1.Name, p1.Age.ToString(), p1.BirthDay, p1.Zoo);
            textBox1.Text = null; textBox2.Text = null; numericUpDown1.Value = 0; dateTimePicker1.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = null;
        }
    }
}
