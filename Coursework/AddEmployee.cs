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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Coursework {
    public partial class AddEmployee : Form {
        public AddEmployee(List<string> zooList)
        {
            InitializeComponent();
            foreach (var item in zooList)
            {
                comboBox1.Items.Add(item);
            }
        }
        public Employee Employee { get; private set; }
        string PathNamePic;
        private void openbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.JPG;*.PNG;*.BMP;*.GIF)|*.JPG;*.PNG;*.BMP;*.GIF|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                    PathNamePic = ofd.FileName;
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0) { Employee = new ManulKeeper(richTextBox1.Text, dateTimePicker1.Value, comboBox1.Text, PathNamePic,dateTimePicker2.Value); }
            if (comboBox2.SelectedIndex == 1) { Employee = new ManulVeterinarian(richTextBox1.Text, dateTimePicker1.Value, comboBox1.Text, dateTimePicker2.Value, PathNamePic); }
            this.DialogResult = DialogResult.OK; // Устанавливаем результат
            this.Close();
        }

    }
}
