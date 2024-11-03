using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Manyls {
    abstract public class Employee {
        //Properties
        abstract public string Name { get; set; }
        public virtual string Zoo { get; set; } = "Неизвестный зоопарк";
        public DateTime BirthDay { get; set; }
        abstract public List<NewPallasCat> Wards { get; set; }
        abstract public string PathName { get; set; }

        static int nextId;
        int iD;
        public int ID
        {
            get { return iD; }
            private set { iD = value; }
        }

        //Methods
        abstract public void ShowPhoto(PictureBox box);
        abstract public void WriteToFile(string path = null);
        public string GetFilePath(string fileExtensions = "*.TXT", string textFiles = "Text")
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
        public string ReadFromFile(string path)
        {
            if (!File.Exists(path)) return null;
            StreamReader reader = new StreamReader(path);
            string s = reader.ReadToEnd();
            return s;
        }


        //Сonstructors
        public Employee(string zoo) {
            ID = Interlocked.Increment(ref nextId);
            Zoo = zoo;
        }


    }
}