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
    public partial class ChangeName : Form {
        public ChangeName()
        {
            InitializeComponent();
        }
        public string newName;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите новое имя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            newName = textBox1.Text;
            this.DialogResult = DialogResult.OK; // Устанавливаем результат
            this.Close();
        }
    }
}
