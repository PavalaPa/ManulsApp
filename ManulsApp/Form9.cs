using Manyls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManulsApp {
    public partial class Form9 : Form {
        public Form9()
        {
            InitializeComponent();
            richTextBox1.Text = $"Работник с именем {emp.Name} добавлен.\n";
        }

        Employee emp = new ManulKeeper("Манулий админ");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            emp.AddWard(new Ы(textBox1.Text));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            emp.Name = textBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите событие из списка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (comboBox1.SelectedIndex == 0)
            {
                emp.Info += TextMessage;
                richTextBox1.Text += "Вы подписались на событие WardsInfo.\n";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                emp.NameChanged += TextMessage;
                richTextBox1.Text += "Вы подписались на событие NameChanged.\n";
            }
        }
        
        private void TextMessage(string messege)
        {
            richTextBox1.Text += messege;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите событие из списка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (comboBox1.SelectedIndex == 0)
            {
                emp.Info -= TextMessage;
                richTextBox1.Text += "Вы отписались от события WardsInfo.\n";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                emp.NameChanged -= TextMessage;
                richTextBox1.Text += "Вы отписались от события NameChanged.\n";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            emp.RemoveWard(new Ы(textBox1.Text));
        }
    }
}
