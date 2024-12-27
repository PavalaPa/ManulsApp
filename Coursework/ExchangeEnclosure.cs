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

namespace Coursework {
    public partial class ExchangeEnclosure : Form {
        public ExchangeEnclosure(List<string> manuls)
        {
            InitializeComponent();
            foreach (var manul in manuls)
            {
                Cats.Add(new NewPallasCat(manul));
                comboBox1.Items.Add(manul);
            }
            foreach (var eclosure in eclosures)
            {
                listBox1.Items.Add(eclosure.Name);
            }
            foreach(var capy in capybaras)
            {
                comboBox2.Items.Add(capy.Name);
            }
        }
        static Eclosure capyEc = new Eclosure("Вольер для Капи");
        List<Eclosure> eclosures = new List<Eclosure>() { capyEc, new Eclosure("Большой вольер")};
        List<NewPallasCat> Cats = new List<NewPallasCat>();
        List<Capybara> capybaras = new List<Capybara>() { new Capybara("Нева"), new Capybara("Лапочка"), new Capybara("Карамелька", capyEc) };
        private void ExchangeEnclosure_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите название вольера.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var enc = new Eclosure(textBox1.Text);
            eclosures.Add(enc);
            listBox1.Items.Add(enc.Name);
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите животных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Cats[comboBox1.SelectedIndex].TransferEclosure(capybaras[comboBox2.SelectedIndex]); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите манула.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите вольер.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Cats[comboBox1.SelectedIndex].TransferEclosure(setEclosure: eclosures[listBox1.SelectedIndex], Exchange: false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите капибару.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите вольер.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            capybaras[comboBox2.SelectedIndex].TransferEclosure(setEclosure: eclosures[listBox1.SelectedIndex], Exchange: false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 && comboBox2.SelectedIndex == -1) 
            {
                MessageBox.Show("Выберите животное.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBox1.SelectedIndex != -1)
            {
                Cats[comboBox1.SelectedIndex].Transfer();
            }
            if (comboBox2.SelectedIndex != -1)
            {
                capybaras[comboBox2.SelectedIndex].Transfer();
            }
        }
    }
}
