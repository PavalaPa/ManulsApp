using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;

namespace Manyls {
    public class ManulKeeper : Employee {
        private List<NewPallasCat> wards = new List<NewPallasCat>();
        public override List<NewPallasCat> Wards 
        {
            get => new List<NewPallasCat>(wards); // Возвращаем копию списка, чтобы избежать изменения оригинала
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Список не может быть null.");
                }

                wards = new List<NewPallasCat>(value); // Устанавливаем новый список
            }
        }
        public void AddWard(NewPallasCat ward)
        {
            if (ward == null)
            {
                throw new ArgumentNullException(nameof(ward), "Объект не может быть null.");
            }
            wards.Add(ward);
        }

        public void RemoveWard(NewPallasCat ward)
        {
            if (ward == null)
            {
                throw new ArgumentNullException(nameof(ward), "Объект не может быть null.");
            }
            wards.Remove(ward);
        }
        public void RemoveWard(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя не может быть пустым или null.", nameof(name));
            }

            // Находим объект по имени и удаляем его
            var wardToRemove = wards.FirstOrDefault(ward => ward.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (wardToRemove != null)
            {
                wards.Remove(wardToRemove);
            }
            else
            {
                throw new InvalidOperationException($"Объект с именем '{name}' не найден.");
            }
        }

        public void RemoveWard(int id)
        {
            // Находим объект по ID и удаляем его
            var wardToRemove = wards.FirstOrDefault(ward => ward.PallasCatID == id);

            if (wardToRemove != null)
            {
                wards.Remove(wardToRemove);
            }
            else
            {
                throw new InvalidOperationException($"Объект с ID '{id}' не найден.");
            }
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
            writer.Write($"Работник {Name} - Врач манулов. Работает в зоопарке, известном как: {Zoo}. Устроился на работу в {StartWorking}.\nДата рождения работника:{BirthDay} (Полных лет:{CalcAge(BirthDay)})\nОтветственен за следующих манулов:");
            for(int i = 0; i < Wards.Count; i++)
            {
                if (i == Wards.Count - 1) { writer.Write($"{Wards[i].Name}.\n"); break; }
                writer.Write($"{Wards[i].Name}, ");
            }
            if (resum != "Резюме отсутствует.") { writer.Write("Ресюме работника:\n"); }
            writer.WriteLine(resum);
            writer.Close();
        }

        //Construct
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