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
    public partial class Form8 : Form {
        public Form8()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                richTextBox1.Text = emps[listBox1.SelectedIndex].WriteToFile();
            }

            else if (comboBox2.SelectedIndex == 2)
            {
                if (emps[listBox1.SelectedIndex] is ManulVeterinarian)
                {
                    using (FontDialog fontDialog = new FontDialog())
                    using (ColorDialog colorDialog = new ColorDialog())
                    {
                        fontDialog.Font = pictureBox1.Font;

                        if (fontDialog.ShowDialog() == DialogResult.OK && colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            Font currFont = fontDialog.Font;
                            Color color = colorDialog.Color;
                            ManulVeterinarian emp = (ManulVeterinarian)emps[listBox1.SelectedIndex];
                            // Вызываем метод NameText с выбранным шрифтом и цветом
                            emp.NameText(pictureBox1, currFont, color);
                        }
                    }
                }
                else
                {
                    richTextBox1.Text = "Такого метода не существует.";
                }
            }
            else
            {
                richTextBox1.Text = emps[listBox1.SelectedIndex].ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        List<Employee> emps = new List<Employee>();
        private void Form8_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Врач");
            comboBox1.Items.Add("Кипер");
            listBox1.DataSource = emps;
            listBox1.DisplayMember = "Name";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1) { emps.Add(new ManulKeeper(textBox1.Text, DateTime.Now, textBox2.Text, null, DateTime.Now, null)); }
            else {emps.Add(new ManulVeterinarian(textBox1.Text, DateTime.Now, textBox2.Text, DateTime.Now, null));}
            listBox1.DataSource = null;
            listBox1.DataSource = emps;
            listBox1.DisplayMember = "Name";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
