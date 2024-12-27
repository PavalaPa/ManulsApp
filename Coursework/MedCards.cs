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

namespace Coursework {
    public partial class MedCards : Form {
        public MedCards()
        {
            InitializeComponent();
        }
        NewPallasCat cat1 = new NewPallasCat();
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
            richTextBox1.Text = "Поменять медкарту манула невозможно, т.к. поле скрыто.";
        }
    }
}
