using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Manyls {
    public class ManulVeterinarian : Employee {
        public ManulVeterinarian(string name, DateTime bday, string zoo, DateTime startWorking) : base(name, bday, zoo, startWorking)
        {

        }
        private List<NewPallasCat> wards;
        public override List<NewPallasCat> Wards 
        { 
            get => wards; 
            set => wards = value; 
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
            
        }
    }
}