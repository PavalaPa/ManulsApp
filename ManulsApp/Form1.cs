using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manyls;

namespace ManulsApp {
    public partial class Form1 : Form {
        private ImageList imageList;
        public Form1()
        {
            InitializeComponent();
            listView1.Items.Clear();
            Lab2_test();
            imageList = new ImageList();
            imageList.ImageSize = new Size(90, 60);
            listView1.SmallImageList = imageList;
        }

        private void Lab2_test()
        {
            //NewPallasCat cat = new NewPallasCat("МАНУЛ1");
            NewPallasCat cat1 = new NewPallasCat(3, "Ева");
            ListViewItem lvi1 = new ListViewItem(new string[] { "", cat1.PallasCatID.ToString(), cat1.Name, cat1.Age.ToString(), cat1.Name.GetHashCode().ToString() });
            listView1.Items.Add(lvi1);
        }

        private string PathNamePic;
        private int indexPic = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.JPG;*.PNG;*.BMP;*.GIF)|*.JPG;*.PNG;*.BMP;*.GIF|All files (*.*)|*.*";

            if(ofd.ShowDialog() == DialogResult.OK)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            NewPallasCat SomeCat = new NewPallasCat();
            BackColor = Color.FromArgb(NewPallasCat.BackColor.R, NewPallasCat.BackColor.G, NewPallasCat.BackColor.B);
            if (richTextBox1.Text != null) SomeCat.Name = richTextBox1.Text;
            SomeCat.Age = (int)numericUpDown1.Value;
            SomeCat.PathName = PathNamePic;
            //richTextBox2.AppendText(NewPallasCat.Zoo);
            Bitmap EmptyImg = new Bitmap(30, 30);

            using (Graphics g = Graphics.FromImage(EmptyImg)) //Новая графика
            {
                g.Clear(Color.White);
            }
            if (PathNamePic == null)
            {
                imageList.Images.Add(EmptyImg);
            }
            else
            {
                imageList.Images.Add(new Bitmap(PathNamePic));
            }
            listView1.SmallImageList = imageList;

            ListViewItem lvi = new ListViewItem(new string[] { "", SomeCat.PallasCatID.ToString(), SomeCat.Name, SomeCat.Age.ToString(), SomeCat.Name.GetHashCode().ToString()});
            lvi.ImageIndex = indexPic;
            listView1.Items.Add(lvi); 
            indexPic++;

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = null;
            numericUpDown1.Value = 0;
            PathNamePic = null;
            pictureBox1.Image = null;
        }
    }
}
