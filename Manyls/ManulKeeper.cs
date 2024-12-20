using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;

namespace Manyls {
    public sealed class ManulKeeper : Employee {

        private string pathName;
        public override string PathName 
        { 
            get => pathName;
            set 
            {
                if (string.IsNullOrWhiteSpace(value)) pathName = value;
                else
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
        }

        public override string WriteToFile(string resum = "Резюме отсутствует.", string path = null)
        {
            string text;
            if (string.IsNullOrWhiteSpace(path)) path = $"{Name}.txt";
            StreamWriter writer = new StreamWriter(path);
            text = $"Работник {Name} - Врач манулов. Работает в зоопарке, известном как: {Zoo}. Устроился на работу в {StartWorking}.\nДата рождения работника:{BirthDay} (Полных лет:{CalcAge(BirthDay)})\nОтветственен за следующих манулов:";
            writer.Write(text);
            for(int i = 0; i < Wards.Count; i++)
            {
                if (i == Wards.Count - 1) 
                {
                    text += $"{Wards[i].Name}.\n";
                    writer.Write($"{Wards[i].Name}.\n"); 
                    break; 
                }
                text += $"{Wards[i].Name}, ";
                writer.Write($"{Wards[i].Name}, ");
            }
            if (resum != "Резюме отсутствует.") { writer.Write("Ресюме работника:\n"); }
            writer.WriteLine(resum);
            writer.Close();
            return text;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                return base.ToString();
            }
            return this.Name;
        }

        //Construct
        public ManulKeeper(string name) : base(name) { }
        public ManulKeeper(string name, DateTime bday,string zoo, string path, DateTime startWorking): base(name, bday, zoo, startWorking) 
        {
            PathName = path;
        }
        public ManulKeeper(string name, DateTime bday, string zoo, string path, DateTime startWorking, List<NewPallasCat> manuls) : base(name, bday, zoo, startWorking)
        {
            PathName = path;
            Wards = manuls;
        }
    }
}