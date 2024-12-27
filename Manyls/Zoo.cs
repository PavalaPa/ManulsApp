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

        public bool AssignTask(string employeeName, string task)
        {
            // Находим сотрудника по имени
            var employee = Employees.FirstOrDefault(e => e.Name.Equals(employeeName, StringComparison.OrdinalIgnoreCase));

            // Если сотрудник найден
            if (employee != null)
            {
                if (employee is ManulVeterinarian || employee is ManulKeeper)
                {
                    employee.PerformTask(task);  // Выполняем задачу для найденного сотрудника
                    return true;
                }
                else
                {
                    MessageBox.Show($"Сотрудник {employee.Name} не работает с манулами.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Сотрудник с таким именем не найден.");
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