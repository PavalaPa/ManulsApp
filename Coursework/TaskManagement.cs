using Manyls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework {
    public partial class TaskManagement : Form {
        public TaskManagement(List<string> zoos, List<Employee> emps)
        {
            InitializeComponent();
            foreach (var zoo in zoos)
            {
                var zo = new Zoo(zoo);
                zo.Employees = emps;
                Zoos.Add(zo);
                comboBox2.Items.Add(zoo);
            }
            Emps = emps;
            foreach (var emp in Emps)
            {
                comboBox1.Items.Add(emp.Name);
            }
        }
        List<Zoo> Zoos = new List<Zoo>();
        List<Employee> Emps = new List<Employee>();
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1) { MessageBox.Show("Выберите зоопарк.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (comboBox1.SelectedIndex == -1) { MessageBox.Show("Выберите работника.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            var zoo = Zoos[comboBox2.SelectedIndex];
            if (zoo.Employees.Count > 0)
            {
                // Получаем выбранного сотрудника из ComboBox
                var emp = comboBox1.SelectedItem.ToString();
                MessageBox.Show($"{emp} выполнил задачу в зоопарке {zoo.Name}. Эта задача также добавлена в его список выполненных задач.");
                // Выполняем задачу для выбранного сотрудника
                zoo.AssignTask(emp, textBox1.Text);
                textBox1.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) { MessageBox.Show("Выберите работника.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            // Получаем выбранного сотрудника из ComboBox
            var emp = comboBox1.SelectedItem.ToString();
            var index = comboBox1.SelectedIndex;
            richTextBox1.Text = $"Список выполненных заданий сотрудника {emp}: {string.Join(", ", Emps[index].CompletedTasks)}.";
        }
    }
}
