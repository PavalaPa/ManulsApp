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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ManulsApp {
    public partial class Form2 : Form {
        public Form2()
        {
            InitializeComponent();
            foreach (var item in comboBox1.Items)
            {
                zoos.Add(new Zoo(item.ToString()));
            }
        }
        NewPallasCat cat;
        List<Zoo> zoos = new List<Zoo>();
        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) 
            { 
                MessageBox.Show("Выберите зоопарк из списка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return; 
            }
            cat = new NewPallasCat(textBox3.Text);
            var curZoo = zoos[comboBox1.SelectedIndex];
            cat.zoo = curZoo;
            richTextBox2.Text = $"Создан манул {cat.Name}, который находится в {cat.zoo.Name}.";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "Манул удален без потери зоопарка. Зоопарки:\n";
            foreach (var zoo in zoos) {
                richTextBox2.Text += zoo.Name + "\n";
               }
            cat = new NewPallasCat();
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите зоопарк из списка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cat.Name == "NoName") 
            {
                MessageBox.Show("Манул удален!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var curZoo = zoos[comboBox1.SelectedIndex];
            cat.zoo = curZoo;
            richTextBox2.Text = $"Манул {cat.Name} теперь находится в {cat.zoo.Name}.";
        }
        NewPallasCat cat1;
        private void button1_Click(object sender, EventArgs e)
        {
            cat1 = new NewPallasCat(0, textBox1.Text, false, textBox2.Text);
            richTextBox1.Text = $"Создан манул {cat1.Name} с медкартой от {cat1.GetMedName()}.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cat1 = new NewPallasCat();
            richTextBox1.Text = "Манул был удален вместе с медкартой.";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Поле с медкартой скрыто, а методов, позволяющих его менять в классе нет, вам точно нужно менять медкарту?";
        }
        NewPallasCat cat3;
        List<Employee> empls = new List<Employee>();
        private void button9_Click(object sender, EventArgs e)
        {
            cat3 = new NewPallasCat(textBox4.Text);
            richTextBox3.Text = $"Манул {cat3.Name} успешно добавлен!";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                empls.Add(new ManulVeterinarian(textBox5.Text));
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                empls.Add(new ManulKeeper(textBox5.Text));
            }
            richTextBox3.Text += $"{comboBox2.Text} {textBox5.Text}";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = $"Добавлен манул {cat3.Name}. За ним следят:\n";
            foreach (Employee emp in empls)
            {
                richTextBox3.Text += $"{emp.GetType()} {emp.Name}\n";
            }
        }
    }
}
