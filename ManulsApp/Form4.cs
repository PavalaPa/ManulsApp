using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Manyls;

namespace ManulsApp {
    public partial class Form4 : Form {

        List<NewPallasCat> Pallas = new List<NewPallasCat>();
        //List<NewPallasCat> Pallas_lr4 = new List<NewPallasCat>();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = null; textBox2.Text = null; dateTimePicker1.Value = DateTime.Now; pictureBox2.Image = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pallas.Add(new NewPallasCat(textBox1.Text, dateTimePicker1.Value, textBox2.Text, PathNamePic));
            listBox1.DataSource = null;
            listBox1.DataSource= Pallas;
            listBox1.DisplayMember = "Name";
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
            Pallas.Add(new NewPallasCat("Тимофей", new DateTime(2020, 6, 11), "Московский зоопарк", null));
            listBox1.DataSource = Pallas;
            listBox1.DisplayMember = "Name";
            textBox3.DataBindings.Add("Text", Pallas, "PallasCatID");
            textBox4.DataBindings.Add("Text", Pallas, "Name");
            textBox5.DataBindings.Add("Text", Pallas, "Zoo");
            //pictureBox1.DataBindings.Add("Image", Pallas, "ImageBitmap");
            dateTimePicker2.DataBindings.Add("Value", Pallas, "BirthDay");
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            /*
            // Работаем с полями
            Pallas_lr4.Add(new NewPallasCat("Ева", "Новосибирский зоопарк", new DateTime(2018, 6, 20)));
            listBox1.DataSource = Pallas_lr4;
            listBox1.DisplayMember = "Name";
            textBox4.DataBindings.Add("Text", Pallas_lr4, "Name_lr4");
            textBox5.DataBindings.Add("Text", Pallas_lr4, "Zoo_lr4");
            dateTimePicker2.DataBindings.Add("Value", Pallas, "BirthDay_lr4");
            */

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is NewPallasCat selectedCat)
            {
                pictureBox1.Image = selectedCat.ImageBitmap;
            }
        }

        private string PathNamePic;
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.JPG;*.PNG;*.BMP;*.GIF)|*.JPG;*.PNG;*.BMP;*.GIF|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox2.Image = new Bitmap(ofd.FileName);
                    PathNamePic = ofd.FileName;
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*Pallas_lr4.Add(new NewPallasCat(textBox1.Text, textBox2.Text, dateTimePicker1.Value));
            listBox1.DataSource = null;
            listBox1.DataSource = Pallas_lr4;
            listBox1.DisplayMember = "Name"; */
        }
    }
}
