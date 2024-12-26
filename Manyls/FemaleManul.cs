using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace Manyls {
    public class FemaleManul : NewPallasCat {
        public FemaleManul() : base() { }

        public FemaleManul(int age, string name, string pathName) : base(age, name, pathName) { }

        public new void ManulasProp(ref string description, out string result, string name = "Кот")
        {
            description = $"{this.Name} - манул. Семейство кошачьих. " + description;
            result = description + $"Возраст: {Age}. Зоопарк: {Zoo}. Это самка манула.";
            return;
        }
        private string projectDirectory = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
        public override sealed Bitmap ImageBitmap 
        {
            get
            {
                if (string.IsNullOrEmpty(pathName) || !File.Exists(pathName))
                {
                    return new Bitmap(Path.Combine(projectDirectory, "Manyls\\MyManul.jpg"));
                }
                return new Bitmap(pathName);
            }   
        }
        
        public override void ShowPhoto(PictureBox box)
        {
            base.ShowPhoto(box);
            Graphics g = Graphics.FromHwnd(box.Handle);
            g.DrawString(Name, new Font("Cambria", 20), Brushes.White, box.Width / 2, box.Height / 2);
        }
    }
}