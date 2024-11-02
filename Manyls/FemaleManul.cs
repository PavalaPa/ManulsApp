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
        public FemaleManul() { }
        public override void ManulasProp(ref string description, out string result, string name = "Кот")
        {
            base.ManulasProp(ref description, out result, name);
            if (!string.IsNullOrEmpty(name))
            {
                description = $"{name} - манул. Семейство кошачьих. " + description;
                result = description + $"Возраст: {Age}. Зоопарк: {Zoo}. Это самка манула.";
                return;
            }
            description = $"{Name} - манул. Семейство кошачьих. " + description;
            result = description + $"Возраст: {Age}. Зоопарк: {Zoo}. Это самка манула.";
        }
        string projectDirectory = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
        public override sealed Bitmap ImageBitmap 
        {
            get
            {
                if (string.IsNullOrEmpty(pathName) || !File.Exists(pathName))
                return new Bitmap(Path.Combine(projectDirectory, "Manyls\\MyManul.jpg")); // Возвращаем null, если путь не существует

                return new Bitmap(pathName);
            }   
        }

        
    }
}