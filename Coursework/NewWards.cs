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
    public partial class NewWards : Form {
        public NewWards(List<string> manuls)
        {
            InitializeComponent();
            foreach (var item in manuls)
            {
                comboBox1.Items.Add(item);
            }
        }
        public string manulToDel = "";
        public string manulToAdd = "";
        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "") { MessageBox.Show("Введите имя манула!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            manulToAdd = textBox1.Text;
            this.DialogResult = DialogResult.OK; // Устанавливаем результат
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) { MessageBox.Show("Выберите манула из списка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            manulToDel = comboBox1.Text;
            this.DialogResult = DialogResult.OK; // Устанавливаем результат
        }
    }
}
