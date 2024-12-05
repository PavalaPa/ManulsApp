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
    public partial class Form11 : Form {
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewPallasCat cat = new NewPallasCat(textBox1.Text);
            ICurrentActions[] actions = { new Feeding(), new Cleening(), new Rest() };
            foreach (var action in actions)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    richTextBox1.Text += cat.TimeToRest(dateTimePicker1.Value, (IRestDay)action) + "\n";
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    richTextBox1.Text += cat.TimeToRest(dateTimePicker1.Value, (IRestDay)action) + "\n";
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    richTextBox1.Text += cat.TimeToEat(dateTimePicker1.Value, (IFeedingManul)action) + "\n";
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            NewPallasCat cat = new NewPallasCat(textBox1.Text);
            var cleeningAct = new Cleening();
            IFeedingManul[] actions = { new Rest(), new Feeding()};
            string pallasName = textBox1.Text;
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите действие из списка.");
                return;
            }
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text += cleeningAct.CleaningEnclosure(dateTimePicker1.Value) + $"{pallasName}\n";
            }
            foreach (var action in actions)
            {
                if (comboBox1.SelectedIndex == 2)
                {
                    richTextBox1.Text += cat.TimeToEat(dateTimePicker1.Value, action) + $"{pallasName}\n";
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text += cat.TimeToRest(dateTimePicker1.Value, new Rest()) + $"{pallasName}\n";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
