using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Manyls;

namespace ManulsApp {
    public partial class Form10 : Form {
        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var keeper = new ManulKeeper("Степан Васильевич", new DateTime(2002,11,11), "Лен. зоопарк", null, new DateTime(2023, 10, 15), new List<NewPallasCat> { new NewPallasCat("Шу"), new NewPallasCat("Намика"), new NewPallasCat("Свэн")});
            richTextBox1.Text = $"Манулы, за которых ответственен {keeper.Name}: {keeper[0].Name}, {keeper[1].Name}, {keeper["Свэн"].Name}.\n";
            keeper[0] = new NewPallasCat("Другой котёнок");
            richTextBox1.Text += $"Манулы, за которых ответственен {keeper.Name}: {keeper[0].Name}, {keeper[1].Name}, {keeper["Свэн"].Name}.\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var vet = new ManulVeterinarian("Павел Фёдорович", new DateTime(1987, 07, 22), "Лен. Зоопарк", new DateTime(2001, 02, 02), new List<NewPallasCat> { new NewPallasCat() });
            vet[listBox1.SelectedIndex, 0] = 6; vet[listBox1.SelectedIndex, 1] = 9; vet[listBox1.SelectedIndex, 2] = 7;
            richTextBox2.Text = $"Ветеринар {vet.Zoo}а {vet.Name}, оценил {listBox1.SelectedItem} на {vet[listBox1.SelectedIndex, listBox1.SelectedIndex]}";
        }
    }
}
