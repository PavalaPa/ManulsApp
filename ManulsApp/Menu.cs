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
    public partial class Menu : Form {
        public Menu()
        {
            InitializeComponent();
        }

        private void лр1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            //f.MdiParent = this;
        }

        private void лр2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLR3 f = new FormLR3();
            f.Show();
        }

        private void лр3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
        }

        private void лр5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Form5();
            f.Show();
        }

        private void лр6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Form6();
            f.Show();
        }

        private void лр7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Form7();
            f.Show();
        }
    }
}
