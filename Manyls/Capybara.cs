using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Manyls {
    public class Capybara: ITransfer {
        public Capybara() { }

        public string Name { get; set; } = "NoName";
        public Eclosure Eclosure { get; set; }
        public Capybara(string name, Eclosure eclosure)
        {
            Name = name;
            Eclosure = eclosure;
        }
        public Capybara(string name) { Name = name; }
        public bool Transfer()
        {
            if (Eclosure == null)
            {
                MessageBox.Show("Невозможно прочитать данные о вольере, т.к. он не был добавлен.");
                return false;
            }
            MessageBox.Show($"{this.Name} проживает в вольере: {Eclosure.Name}.");
            return true;
        }

        public void TransferEclosure(ITransfer someAnimal = null, Eclosure setEclosure = null, bool Exchange = true)
        {
            if (Exchange)
            {
                if (Eclosure == null)
                {
                    MessageBox.Show($"Невозможно поменять животных вольерами, т.к. вольер капибары {this.Name} не назначен.");
                    return;
                }
                if (!someAnimal.Transfer())
                {
                    MessageBox.Show($"Невозможно поменять животных вольерами, т.к. вольер животного {someAnimal.Name} не назначен.");
                    return;
                }
                var curEclosure = someAnimal.Eclosure;
                someAnimal.Eclosure = this.Eclosure;
                this.Eclosure = curEclosure;
                MessageBox.Show($"Обмен вольерами произведен! Капибара {this.Name} теперь проживает в вольере {this.Eclosure.Name}, а животное {someAnimal.Name} теперь проживает в {someAnimal.Eclosure.Name}.");
            }
            else
            {
                if (setEclosure == null)
                {
                    MessageBox.Show($"Невозможно поменять вольер капибары {this.Name}, т.к. менять не на что.");
                    return;
                }
                this.Eclosure = setEclosure;
                MessageBox.Show($"Обмен вольерами произведен! Капибара {this.Name} теперь проживает в вольере {this.Eclosure.Name}.");
            }
        }
    }
}