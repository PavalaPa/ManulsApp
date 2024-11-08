using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Manyls {
    public class ManulVeterinarian : Employee {
        public ManulVeterinarian(string name, DateTime bday, string zoo, DateTime startWorking, List<NewPallasCat> wards) : base(name, bday, zoo, startWorking)
        {
            Wards = wards;
        }
        private List<NewPallasCat> wards;
        public override List<NewPallasCat> Wards 
        { 
            get => wards; 
            set => wards = value; 
        }
        public void NameText(PictureBox box, Font currFont)
        {
            Graphics g = Graphics.FromHwnd(box.Handle);
            g.DrawString(this.Name, currFont, Brushes.Red, 1, 1);
        }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                return base.ToString();
            }
            return this.Name;
        }
        public void AddWard(NewPallasCat ward)
        {
            if (ward == null)
            {
                throw new ArgumentNullException(nameof(ward), "Объект не может быть null.");
            }
            wards.Add(ward);
        }
        private string pathName;
        public override string PathName 
        { 
            get => pathName;
            set
            {
                string res = value.Substring(value.Length - 4).ToLower();
                if (File.Exists(value) && (res == ".png" || res == ".gif" || res == ".jpg" || res == ".bmp")) // Проверка существования файла
                {
                    pathName = value;
                }
                else
                {
                    // Если файл не существует, установим путь по умолчанию
                    pathName = "NoPhoto.jpg";
                }
            }
        }

        public override void WriteToFile(string resum = "Резюме отсутствует.", string path = null)
        {
            if (path == null) path = $"{Name}.txt";
            StreamWriter writer = new StreamWriter(path);
            writer.Write($"Работник {Name} - Кипер манулов. Работает в зоопарке, известном как: {Zoo}. Устроился на работу в {StartWorking}.\nДата рождения работника:{BirthDay} (Полных лет:{CalcAge(BirthDay)})\nОтветственен за следующих манулов:");
            for (int i = 0; i < Wards.Count; i++)
            {
                if (i == Wards.Count - 1) { writer.Write($"{Wards[i].Name}.\n"); break; }
                writer.Write($"{Wards[i].Name}, ");
            }
            if (resum != "Резюме отсутствует.") { writer.Write("Ресюме работника:\n"); }
            writer.WriteLine(resum);
            writer.Close();
        }
    }
}