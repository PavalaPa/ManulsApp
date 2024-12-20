using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Manyls {
    public class ManulVeterinarian : Employee {
        public ManulVeterinarian(string name) : base(name) { }
        public ManulVeterinarian(string name, DateTime bday, string zoo, DateTime startWorking, List<NewPallasCat> wards) : base(name, bday, zoo, startWorking)
        {
            Wards = wards;
        }

        public void NameText(PictureBox box, Font currFont, Color color)
        {
            using (Graphics g = Graphics.FromHwnd(box.Handle))
            {
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawString(this.Name, currFont, brush, 1, 1);
                }
            }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                return base.ToString();
            }
            return this.Name;
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

        public override string WriteToFile(string resum = "Резюме отсутствует.", string path = null)
        {
            string text = $"Работник {Name} - Кипер манулов. Работает в зоопарке, известном как: {Zoo}. Устроился на работу в {StartWorking}.\nДата рождения работника:{BirthDay} (Полных лет:{CalcAge(BirthDay)})\nОтветственен за следующих манулов:";
            if (path == null) path = $"{Name}.txt";
            StreamWriter writer = new StreamWriter(path);
            writer.Write(text);
            for (int i = 0; i < Wards.Count; i++)
            {
                if (i == Wards.Count - 1) 
                { 
                    writer.Write($"{Wards[i].Name}.\n");
                    text += $"{Wards[i].Name}.\n";
                    break; 
                }
                writer.Write($"{Wards[i].Name}, ");
                text += $"{Wards[i].Name}, ";
            }
            if (resum != "Резюме отсутствует.") 
            { 
                writer.Write("Ресюме работника:\n");
                text += "Ресюме работника:\n";
            }
            writer.WriteLine(resum);
            writer.Close();
            return text;
        }
    }
}