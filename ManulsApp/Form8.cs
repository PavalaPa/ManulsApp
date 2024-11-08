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

    }
}
