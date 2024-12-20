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
    public partial class Form12 : Form {
        public Form12()
        {
            InitializeComponent();
            
        }
        NewPallasCat cat;
        List<Zoo> zoos;
        private void button6_Click(object sender, EventArgs e)
        {
            cat = new NewPallasCat(textBox3.Text);
            var curZoo = new Zoo(comboBox1.Text);
            cat.zoo = curZoo; 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var curZoo = new Zoo(comboBox1.Text);
            cat.zoo = curZoo;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = $"Манул удален без потери зоопарка. Зоопарки:{zoos.ToString()}";
        }
    }
}
