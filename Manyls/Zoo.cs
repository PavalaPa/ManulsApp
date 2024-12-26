using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Manyls {
    public class Zoo {
        //Constructor
        public Zoo() { }
        public Zoo(string name) 
        { 
            Name = name; 
        }
        //Properties
        private int m_id = -1;
        public int ID { get { return m_id; } set { m_id = value; } }
        public string Name;

        //Ассоциации
        public List<Employee> Employees { get; set; }

        public bool AssignTask(Employee employee, string task)
        {
            if (employee is ManulVeterinarian)
            {
                MessageBox.Show($"{employee.Name} выполняет задачу: {task}");
                return true;
            }
            if (employee is ManulKeeper) 
            {
                MessageBox.Show($"{employee.Name} выполняет задачу: {task}");
                return true;
            }
            else
            {
                MessageBox.Show($"Сотрудник не работает с манулами.");
                return false;
            }
        }
        public List<NewPallasCat> PallasCats { get; set; }
        public int CountCats => PallasCats.Count; // Геттер вычисляет количество элементов в списке

        //для диаграммы классов
        public Employee Employees_ { get; set; }

        public NewPallasCat NewPallasCat_ { get; set; }
    }
}