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
    public partial class Form5 : Form {
        List<Ы> Pallas = new List<Ы>();
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Pallas.Add(new Ы("Тимофей", new DateTime(2020, 6, 11), "Московский зоопарк", null, false));
            listBox1.DataSource = Pallas;
            listBox1.DisplayMember = "Name";
            label5.DataBindings.Add("Text", Pallas, "PallasCatID");
            textBox3.DataBindings.Add("Text", Pallas, "Name");
            textBox4.DataBindings.Add("Text", Pallas, "Zoo");
            dateTimePicker2.DataBindings.Add("Value", Pallas, "BirthDay");
            checkBox2.DataBindings.Add("Checked", Pallas, "IsFem");
            label6.DataBindings.Add("Text", Pallas, "Age");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = null; textBox2.Text = null; dateTimePicker1.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pallas.Add(new Ы(textBox1.Text, dateTimePicker1.Value, textBox2.Text, null, checkBox1.Checked));
            listBox1.DataSource = null;
            listBox1.DataSource = Pallas;
            listBox1.DisplayMember = "Name";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var NewPallas = new Ы();
            var path = NewPallas.GetFilePath();
            richTextBox1.Text = NewPallas.ReadFromFile(path);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var NewPallas = new Ы(textBox1.Text, dateTimePicker1.Value, textBox2.Text, null, checkBox1.Checked);
            var path = NewPallas.GetFilePath();
            NewPallas.WriteToFile(path);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var Cat = Pallas.ElementAt(int.Parse(label5.Text) - 1);
            var desk = "Мяу! ";
            Cat.ManulasProp(ref desk, out string result);
            richTextBox1.Text = result;
        }
    }
}
