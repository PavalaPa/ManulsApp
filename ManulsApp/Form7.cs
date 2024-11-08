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
using System.Xml.Linq;

namespace ManulsApp {
    public partial class Form7 : Form {
        public Form7()
        {
            InitializeComponent();
        }
        List<NewPallasCat> Cats = new List<NewPallasCat>();
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string r = "Котики манулы хорошие люблю пушистых котов...\n";
            if (listBox1.SelectedItem is NewPallasCat selectedCat)
            {
                pictureBox1.Image = selectedCat.ImageBitmap;
                selectedCat.ShowPhoto(pictureBox3);
                selectedCat.ManulasProp(ref r, out string result);
                richTextBox1.Text = result;
            }
            if (listBox1.SelectedItem is FemaleManul sCat)
            {
                sCat.ManulasProp(ref r, out string result);
                richTextBox2.Text = result;
            }
            else
            {
                richTextBox2.Text = "";
            }
        }
        
        private void Form7_Load(object sender, EventArgs e)
        {
            Cats.Add(new NewPallasCat("Ева", new DateTime(12/07/2010), "Новосибирский зоопарк", null));
            Cats.Add(new FemaleManul("Ева", new DateTime(12 / 07 / 2010), "Новосибирский зоопарк", null));
            Cats.Add(new FemaleManul("Намика", new DateTime(07 / 07 / 2022), "N зоопарк", "C:\\Users\\valentinka\\Desktop\\Дристать вечно\\Manul_kitten.jpg"));
            Cats.Add(new NewPallasCat("Боул", new DateTime(10 / 07 / 2013), "Новосибирский зоопарк", "C:\\Users\\valentinka\\Desktop\\Дристать вечно\\yS5xbLSgRAY.jpg"));
            listBox1.DataSource = Cats;
            listBox1.DisplayMember = "Name";
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /*//Tests "sealed"
        class class1
        {
            public string Prop { get; set; }
            public class1(string n, string sn)
            { 
                Prop = funct(n, sn);
            }
            public virtual string funct(string n, string m)
            {
                return $"{n} {m}";
            }
        }
        class class2 : class1 {
            public string Prop { get; set; }
            public class2(string n, string sn) : base(n, sn) 
            { 
                Prop = funct(n, sn);
            }
            public sealed override string funct(string n, string m)
            {
                return $"Это {base.funct(n, m)}!";
            }
        }
        class class3 : class2 {
            public string Prop { get; set; }
            public class3(string n, string sn) : base(n, sn)
            {
                Prop = funct(n, sn);
            }
            public sealed override string funct(string n, string m)
            {
                return $"Это {base.funct(n, m)}!";
            }
        }*/
    }
}
