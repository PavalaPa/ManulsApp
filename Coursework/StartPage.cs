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
    public partial class StartPage : Form {
        public StartPage()
        {
            InitializeComponent();
            listView1.Items.Clear();
            AddManuls();
            imageList = new ImageList();
            imageList.ImageSize = new Size(90, 60);
            listView1.SmallImageList = imageList;
        }
        private void AddManuls()
        {
            NewPallasCat cat1 = new NewPallasCat("Ева", new DateTime(20, 07, 12), "Новосибирский зоопарк", null, true);
            ListViewItem lvi1 = new ListViewItem(new string[] { "", cat1.PallasCatID.ToString(), cat1.Name, cat1.Age.ToString(), cat1.Zoo, cat1.IsFem.ToString() });
            listView1.Items.Add(lvi1);
        }
        ImageList imageList;
        int indexPic = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> ZooList = listBox1.Items.Cast<string>().ToList(); //LINQ
            AddManul Manulform = new AddManul(ZooList);
            if (Manulform.ShowDialog() == DialogResult.OK)
            {
                NewPallasCat SomeCat = Manulform.Cat;
                if (SomeCat == null)
                {
                    MessageBox.Show("Некорректные данные о животном", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Bitmap EmptyImg = new Bitmap(30, 30);
                using (Graphics g = Graphics.FromImage(EmptyImg)) //Новая графика
                {
                    g.Clear(Color.White);
                }
                if (SomeCat.PathName == null)
                {
                    imageList.Images.Add(EmptyImg);
                }
                else
                {
                    imageList.Images.Add(new Bitmap(SomeCat.PathName));
                }
                listView1.SmallImageList = imageList;

                ListViewItem lvi = new ListViewItem(new string[] { "", SomeCat.PallasCatID.ToString(), SomeCat.Name, SomeCat.Age.ToString(), SomeCat.Zoo, SomeCat.IsFem.ToString() });
                lvi.ImageIndex = indexPic;
                listView1.Items.Add(lvi);
                indexPic++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
