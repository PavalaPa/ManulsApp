using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows;
using System.ComponentModel;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Manyls {

    public class NewPallasCat {
        //Constructor
        //public NewPallasCat(){ }
        //public NewPallasCat(string name) => this.name = name;
        /*
        // Поля для лр 4
        public string Name_lr4;
        public string Zoo_lr4;
        public DateTime BirthDay_lr4;

        public NewPallasCat(string n_lr4, string z_lr4, DateTime b_lr4)
        {
            Name_lr4 = n_lr4;
            Zoo_lr4 = z_lr4;
            BirthDay_lr4 = b_lr4;
        }

        */

        public static readonly MyColor BackColor;
        static NewPallasCat()
        {
            DateTime now = DateTime.Now;
            if (now.DayOfWeek >= DayOfWeek.Sunday)
            {
                NewPallasCat.BackColor = new MyColor(255, 255, 0); // Желтый цвет
                Console.WriteLine("Мяу!");
            }
            else {
                NewPallasCat.BackColor = new MyColor(255, 0, 0); // Красный цвет
            }
        }
        public NewPallasCat()
        {
            PallasCatID = Interlocked.Increment(ref nextId);
        }
        public NewPallasCat(string name)
        {
            PallasCatID = Interlocked.Increment(ref nextId);
            this.Name = name;
        }
        public NewPallasCat(string name, DateTime birth, bool isFem)
        {
            PallasCatID = Interlocked.Increment(ref nextId);
            this.Name = name;
            this.BirthDay = birth;
            this.IsFem = isFem;
            this.Age = CalcAge(birth);
        }
        public NewPallasCat(int age, string name, string pathName)
        {
            PallasCatID = Interlocked.Increment(ref nextId);
            Age = age;
            Name = name;
            PathName = pathName;
        }
        public NewPallasCat(int age, string name)
        {
            PallasCatID = Interlocked.Increment(ref nextId);
            this.Age = age;
            this.Name = name;
            //this.PathName = string.Empty;
        }
        public NewPallasCat(string name, DateTime dateTime, string zoo, string pathName, bool isFem)
        {
            PallasCatID = Interlocked.Increment(ref nextId);
            this.Name = name;
            this.Zoo = zoo;
            this.BirthDay = dateTime;
            this.PathName = pathName;
            this.IsFem = isFem;
            Age = CalcAge(dateTime);
        }
        public NewPallasCat(string name, DateTime dateTime, string zoo, string pathName)
        {
            PallasCatID = Interlocked.Increment(ref nextId);
            this.Name = name;
            this.Zoo = zoo;
            this.BirthDay = dateTime;
            this.PathName = pathName;
        }
        //Properties
        static int nextId;
        int pallasCatID;
        public int PallasCatID
        {
            get { return pallasCatID; } 
            private set { pallasCatID = value; }
        }
        public string Name { get; set; } = "NoName";
        public int Age { get; set; } = 0;
        public DateTime BirthDay { get; set; } = DateTime.Now;
        public string Zoo { get; set; } = "Зоопарк";
        public bool IsFem { get; set; } = false;

        protected string pathName;
        public string PathName
        {
            get => pathName;
            set
            {
                if (value != null && value.Length >= 4)
                {
                    string res = value.Substring(value.Length - 4).ToLower();
                    if (res == ".png" || res == ".gif" || res == ".jpg" || res == ".bmp")
                    {
                        if (File.Exists(value)) // Проверка существования файла
                        {
                            pathName = value;
                        }
                        else
                        {
                            // Если файл не существует, установим путь по умолчанию
                            pathName = "\\ManulsApp\\Manyls\\MyManul.jpg";
                        }
                    }
                    else
                    {
                        // Если расширение не поддерживается, установим путь по умолчанию
                        pathName = "\\ManulsApp\\Manyls\\MyManul.jpg";
                    }
                }
                else
                {
                    // Если значение null или длина меньше 4, установим путь по умолчанию
                    pathName = "\\ManulsApp\\Manyls\\MyManul.jpg";
                }

                OnPropertyChanged(nameof(PathName));
                OnPropertyChanged(nameof(ImageBitmap)); // Обновляем изображение
            }
        }

        // Методы и ивенты
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void ManulasProp(ref string description, out string result, string name = null)
        {
            if (!string.IsNullOrEmpty(name)) 
            {
                description = $"{name} - манул. Семейство кошачьих. " + description;
                result = description + $"Возраст: {Age}. Зоопарк: {Zoo}";
                return;
            }
            description = $"{Name} - манул. Семейство кошачьих. " + description;
            result = description + $"Возраст: {Age}. Зоопарк: {Zoo}";
        }

        public virtual void ShowPhoto(PictureBox box)
        {
            Graphics g = Graphics.FromHwnd(box.Handle);
            g.DrawImage(ImageBitmap, new Rectangle(0, 0, box.Width, box.Height));
            /*Graphics g = Graphics.FromHwnd(box.Handle);
            g.DrawString(Name, new Font("Cambria", 20), Brushes.LightGreen, box.Width / 2, box.Height / 2);*/
        }
        public virtual Bitmap ImageBitmap
        {
            get
            {
                if (string.IsNullOrEmpty(pathName) || !File.Exists(pathName))
                    return null; // Возвращаем null, если путь не существует

                return new Bitmap(pathName);
            }
        }
        public void WriteToFile(bool setInfo = false, string text = "")
        {
            StreamWriter writer = new StreamWriter(this.Name + ".txt");
            if (!setInfo)
            {
                writer.Write($"ID манула: {this.PallasCatID}\nИмя манула: {this.Name}\nВозраст манула: {this.Age}\nЗоопарк в котором содержится:{this.Zoo}\n");
                if (this.IsFem) writer.WriteLine("Манул может размножаться");
                else writer.WriteLine("Манул не может размножаться");
            }
            else
            {
                writer.Write(text);
            }
            writer.Close();
        }
        public void WriteToFile(string path, bool setInfo = false, string text = "")
        {
            if (!File.Exists(path))
            {
                WriteToFile(setInfo, text);
                return;
            }
            else
            {
                StreamWriter writer = new StreamWriter(path);
                if (setInfo == true)
                {
                    writer.Write(text);
                }
                else
                {
                    writer.Write($"ID манула: {this.PallasCatID}\nИмя манула: {this.Name}\nВозраст манула: {this.Age}\nЗоопарк в котором содержится:{this.Zoo}\n");
                    if (this.IsFem) writer.WriteLine("Манул может размножаться");
                    else writer.WriteLine("Манул не может размножаться");
                }
                writer.Close();
            }
        }

        public string ReadFromFile(string path)
        {
            if(!File.Exists(path)) return null;
            StreamReader reader = new StreamReader(path);
            string s = reader.ReadToEnd();
            return s;
        }

        public string GetFilePath()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files(*.TXT)|*.TXT|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if(File.Exists(ofd.FileName))
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
        public int CalcAge(DateTime date)
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

        //public const string Zoo = "Зоопарк";
    }
    //Methods
    /*
    public void ShowPhoto(PictureBox box)
    {
        
    }
    */
    public struct MyColor {
        public int R;
        public int G;
        public int B;
        public MyColor(byte r, byte g, byte b)
        {
            R = (int)r;
            G = (int)g;
            B = (int)b;
        }
    }
}
