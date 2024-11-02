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

namespace ManulsApp {
    public partial class Form6 : Form {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Манулизиция");
            listBox1.Items.Add("Жизнь манулам!");
            listBox1.Items.Add("Манулий Врач");
            listBox1.Items.Add("Манулы:Наглядно");
            listBox2.Items.Add("токсоплазмоз");
            listBox2.Items.Add("блохи");
            listBox2.Items.Add("вирус иммунодефицита кошек (FIV)");
            listBox2.Items.Add("глисты");
            listBox2.Items.Add("вирус лейкоза кошек (FeLV)");
            listBox2.Items.Add("недоедание и обезвоживание");
            listBox2.Items.Add("депрессия");
            listBox2.Items.Add("Аскаридоз");
            listBox2.Items.Add("Гистоплазмоз");
            listBox2.Items.Add("Кальцивироз");
            listBox2.Items.Add("Пневмония");
            listBox2.Items.Add("Сальмонеллёз");
            listBox2.Items.Add("Трихинеллёз");
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text += listBox2.Text + " ";  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MedicalHistory medicalHistory = new MedicalHistory(textBox1.Text, DateTime.Now, checkBox1.Checked, listBox1.SelectedItem.ToString(), richTextBox1.Text.Split().ToList());
            richTextBox2.Text = $"Имя манула: {medicalHistory.Name}\nИмя лечащего врача: {textBox2.Text}\nНазвание клиники: {medicalHistory.veterinaryСlinic}\nБолезни манула: {string.Join(" ",medicalHistory.AttendingPhysicians)}";
            richTextBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewPallasCat medicalHistory = new MedicalHistory();
            MedicalHistory mh = (MedicalHistory)medicalHistory;
            var a = mh.veterinaryСlinic;
            mh.WriteToFile(mh.GetFilePath(), true, richTextBox2.Text);

        }
    }
}
