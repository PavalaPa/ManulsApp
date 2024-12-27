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

        //Ассоциация
        public Zoo AssociatedZoo { get; set; }
        public List<string> CompletedTasks { get; private set; } = new List<string>();
        public void PerformTask(string task)
        {
            CompletedTasks.Add(task); // Сотрудник фиксирует выполненную задачу как свою.
        }
        public virtual string Zoo { get; set; } = "Неизвестный зоопарк";
        public DateTime BirthDay { get; set; }
        public DateTime StartWorking { get; set; }

        private int[,] manulMark = new int[3,3];
        public int this [int i, int j]
        {
            get => manulMark[i, j];
            set => manulMark[i, j] = value;
        }

        private List<NewPallasCat> wards = new List<NewPallasCat>();
        public List<NewPallasCat> Wards 
        {
            get => new List<NewPallasCat>(wards); // Возвращаем копию списка, чтобы избежать изменения оригинала
            set
            {
                if (value == null)
                {
                    //throw new ArgumentNullException(nameof(value), "Список не может быть null.");
                    value = new List<NewPallasCat>();
                }
                else
                    wards = new List<NewPallasCat>(value); // Устанавливаем новый список
            }
        }

        public delegate void WardsInfo(string NameOfCurManul); //указатель на метод
        //public delegate void WardsInfo(object obj, EmployeeEvents e);
        public event WardsInfo Info; //объявляем событие 

        public NewPallasCat this[int index]
        {
            get => wards[index];
            set => wards[index] = value;
        }

        public NewPallasCat this[string name]
        {
            get
            {
                NewPallasCat pallasCat = null;
                foreach (NewPallasCat cat in wards)
                {
                    if (cat.Name == name)
                    {
                        pallasCat = cat;
                        break;
                    }
                }
                return pallasCat;
            }
        }
        public void AddWard(NewPallasCat ward)
        {
            if (ward == null)
            {
                Info.Invoke("Было введено пустое значение. ");
                //Info.Invoke(this, new EmployeeEvents("Было введено пустое значение. ", null));
                return;
            }
            wards.Add(ward);
            Info?.Invoke($"В список подопечных {Name} был добавлен новый манул с именем {ward.Name}. ");
        }
        public void RemoveWard(NewPallasCat ward)
        {
            if (ward == null)
            {
                Info.Invoke("Было введено пустое значение. ");
                return;
            }
            wards.Remove(ward);
            Info?.Invoke($"Из списка подопечных {Name} был удален манул с именем {ward.Name}. ");
        }
        public void RemoveWard(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Info.Invoke("Было введено пустое значение. ");
                return;
            }

            try
            {
                // Используем индексатор для поиска манула по имени
                var wardToRemove = this[name];
                wards.Remove(wardToRemove);
                Info?.Invoke($"Из списка подопечных {Name} был удален манул с именем {name}. ");
            }
            catch (NullReferenceException)
            {
                throw new InvalidOperationException($"Манул с именем '{name}' не найден.");
            }
        }

        public void RemoveWard(int id)
        {
            // Находим объект по ID и удаляем его
            var wardToRemove = wards.FirstOrDefault(ward => ward.PallasCatID == id);

            if (wardToRemove != null)
            {
                wards.Remove(wardToRemove);
                Info?.Invoke($"Из списка подопечных был удален манул с именем {wardToRemove.Name}. ");
            }
            else
            {
                Info?.Invoke($"Было введено пустое значение или объект с id = {id} не найден. ");
                return;
            }
        }
        abstract public string PathName { get; set; }

        static int nextId;
        int iD;
        public int ID
        {
            get { return iD; }
            private set { iD = value; }
        }
        public delegate void EventHandler(string NameOfCurManul);
        public event EventHandler NameChanged;

        private string name;
        public virtual string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    NameChanged?.Invoke($"Имя работника было изменено c {name} на {value}");
                    name = value;
                }
            }
        }
        /*private string name;
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
                if (string.IsNullOrEmpty(value) || value.Split(' ').Length < 2)
                { 
                    name = "NoName"; 
                }
                else name = value;
            }
        }*/
        //Methods
        abstract public string WriteToFile(string resum = "Резюме отсутствует.", string path = null);
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
        public Employee(string name)
        {
            Name = name;
        }
        public Employee(string name, DateTime bday, string zoo, DateTime startWorking) {
            ID = Interlocked.Increment(ref nextId);
            Name = name;
            BirthDay = bday;
            Zoo = zoo;
            StartWorking = startWorking;
        }

        // Для диаграммы классов
        public NewPallasCat wards_ { get; set; }
    }
}