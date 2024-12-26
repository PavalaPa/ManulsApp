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
    public partial class AddManul : Form {
        public AddManul(List<string> zooList)
        {
            InitializeComponent();
            foreach (var item in zooList)
            {
                comboBox1.Items.Add(item);
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            Cat = new NewPallasCat(richTextBox1.Text, dateTimePicker1.Value, comboBox1.Text, PathNamePic, checkBox1.Checked);
            this.DialogResult = DialogResult.OK; // Устанавливаем результат
            this.Close();
        }
        public NewPallasCat Cat { get; private set; }
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
    }
}
