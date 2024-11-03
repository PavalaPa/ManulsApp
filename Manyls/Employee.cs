using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Manyls {
    abstract public class Employee {
        //Properties
        public virtual string Zoo { get; set; } = "Неизвестный зоопарк";
        public DateTime BirthDay { get; set; }
        public DateTime StartWorking { get; set; }
        abstract public List<NewPallasCat> Wards { get; set; }
        abstract public string PathName { get; set; }

        static int nextId;
        int iD;
        public int ID
        {
            get { return iD; }
            private set { iD = value; }
        }

        private string name;
        public virtual string Name
        {
            get
            {
                var words = name.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length > 0)
                    {
                        words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                    }
                }
                return string.Join(" ", words);
            }
            set
            {
                if (!string.IsNullOrEmpty(value) || value.Split().Length < 2) name = "NoName";
                else name = value;
            }
        }
        //Methods
        abstract public void WriteToFile(string resum = "Резюме отсутствует.", string path = null);
        public virtual string GetFilePath(string fileExtensions = "*.TXT", string textFiles = "Text")
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = $"{textFiles} Files({fileExtensions})|{fileExtensions}|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(ofd.FileName))
                {
                    return ofd.FileName;
                }
                else
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return null;
        }
        public virtual string ReadFromFile(string path)
        {
            if (!File.Exists(path)) return null;
            StreamReader reader = new StreamReader(path);
            string s = reader.ReadToEnd();
            return s;
        }
        public virtual void ShowPhoto(PictureBox box, bool flagForName = true)
        {
            Graphics g = Graphics.FromHwnd(box.Handle);
            if (new Bitmap(PathName) == null) { g.Clear(Color.Cornsilk); return; }
            g.DrawImage(new Bitmap(PathName), new Rectangle(0, 0, box.Width, box.Height));
            if (flagForName)
            {
                Color glowColor = Color.FromArgb(150, Color.Green); // Прозрачный зеленый цвет

                // Смещение для свечения
                int glowOffset = 2;

                // Рисуем свечения (разные смещения)
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i != 0 || j != 0) // Пропускаем центр
                        {
                            g.DrawString(Name, new Font("Cambria", 20), new SolidBrush(glowColor), (box.Width / 2) + i * glowOffset, (box.Height / 2) + j * glowOffset);
                        }
                    }
                }
            }
            g.DrawString(Name, new Font("Cambria", 20), Brushes.White, box.Width / 2, box.Height / 2);

        }
        protected int CalcAge(DateTime date)
        {
            DateTime today = DateTime.Now;
            int age = today.Year - date.Year;

            // Проверяем, был ли день рождения в этом году
            if (date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
        //Сonstructors
        public Employee(string name, DateTime bday, string zoo, DateTime startWorking) {
            ID = Interlocked.Increment(ref nextId);
            Name = name;
            BirthDay = bday;
            Zoo = zoo;
            StartWorking = startWorking;
        }


    }
}