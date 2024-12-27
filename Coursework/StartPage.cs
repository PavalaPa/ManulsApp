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
    public partial class StartPage : Form {
        public StartPage()
        {
            InitializeComponent();
            listView1.Items.Clear();
            AddManuls();
            AddZoos();
            AddEmployes();
            imageListEmps = new ImageList();
            imageListEmps.ImageSize = new Size(90, 60);
            listView2.SmallImageList = imageListEmps;
            imageList = new ImageList();
            imageList.ImageSize = new Size(90, 60);
            listView1.SmallImageList = imageList;
        }
        private void AddManuls()
        {
            NewPallasCat cat1 = new NewPallasCat("Ева", new DateTime(2020, 07, 12), "Новосибирский зоопарк", null, true);
            ListViewItem lvi1 = new ListViewItem(new string[] { "", cat1.PallasCatID.ToString(), cat1.Name, cat1.Age.ToString(), cat1.Zoo, cat1.IsFem.ToString(), cat1.BirthDay.ToString() });
            listView1.Items.Add(lvi1);
        }
        private void AddZoos()
        {
            listBox1.Items.Add("Новосибирский зоопарк");
        }
        private void AddEmployes()
        {
            Employee employee = new ManulKeeper("Арсений Филипович", new DateTime(2000, 07, 12), "Новосибирский зоопарк", null, new DateTime(20, 01, 12));
            emps.Add(employee);
            ListViewItem lvi1 = new ListViewItem(new string[] { "", employee.ID.ToString(), employee.Name, employee.BirthDay.ToString(), employee.Zoo, employee.StartWorking.ToString() });
            listView2.Items.Add(lvi1);
        }
        ImageList imageList;
        int indexPic = 0;
        ImageList imageListEmps;
        int indexPicEmps = 0;

        List<Employee> emps = new List<Employee>();
        List<string> manuls = new List<string>() {"Ева"};
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> ZooList = listBox1.Items.Cast<string>().ToList(); //LINQ
            AddManul Manulform = new AddManul(ZooList);
            if (Manulform.ShowDialog() == DialogResult.OK)
            {
                NewPallasCat SomeCat = Manulform.Cat;
                if (SomeCat == null)
                {
                    MessageBox.Show("Некорректные данные о животном", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Bitmap EmptyImg = new Bitmap(30, 30);
                using (Graphics g = Graphics.FromImage(EmptyImg)) //Новая графика
                {
                    g.Clear(Color.White);
                }
                if (SomeCat.PathName == null)
                {
                    imageList.Images.Add(EmptyImg);
                }
                else
                {
                    imageList.Images.Add(new Bitmap(SomeCat.PathName));
                }
                listView1.SmallImageList = imageList;

                ListViewItem lvi = new ListViewItem(new string[] { "", SomeCat.PallasCatID.ToString(), SomeCat.Name, SomeCat.Age.ToString(), SomeCat.Zoo, SomeCat.IsFem.ToString(), SomeCat.BirthDay.ToString() });
                manuls.Add(SomeCat.Name);
                lvi.ImageIndex = indexPic;
                listView1.Items.Add(lvi);
                indexPic++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Проверяем, выбрана ли хотя бы одна строка
            if (listView1.SelectedItems.Count > 0)
            {
                //Удаляем выбранные элементы
                foreach (ListViewItem selectedItem in listView1.SelectedItems)
                {
                    manuls.Remove(selectedItem.Text);
                    listView1.Items.Remove(selectedItem);
                }

                MessageBox.Show("Выбранные строки успешно удалены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите название зоопарка в область перед кнопкой!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            listBox1.Items.Add(textBox1.Text);
            textBox1.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Введите название зоопарка, который вы хотите удалить, в область перед кнопкой или выберите зоопарк из доступных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox1.Text != "") { listBox1.Items.Remove(textBox1.Text); }
            else { listBox1.Items.Remove(listBox1.SelectedItem); }
            textBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<string> ZooList = listBox1.Items.Cast<string>().ToList(); //LINQ
            AddEmployee Employeeform = new AddEmployee(ZooList);
            if (Employeeform.ShowDialog() == DialogResult.OK)
            {
                Employee Employee = Employeeform.Employee;
                if (Employee == null)
                {
                    MessageBox.Show("Некорректные данные о работнике", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                emps.Add(Employee);
                Bitmap EmptyImg = new Bitmap(30, 30);
                using (Graphics g = Graphics.FromImage(EmptyImg)) //Новая графика
                {
                    g.Clear(Color.White);
                }
                if (Employee.PathName == null)
                {
                    imageListEmps.Images.Add(EmptyImg);
                }
                else
                {
                    imageListEmps.Images.Add(new Bitmap(Employee.PathName));
                }
                listView2.SmallImageList = imageListEmps;

                ListViewItem lvi = new ListViewItem(new string[] { "", Employee.ID.ToString(), Employee.Name, Employee.BirthDay.ToString(), Employee.Zoo, Employee.StartWorking.ToString() });
                lvi.ImageIndex = indexPicEmps;
                listView2.Items.Add(lvi);
                indexPicEmps++;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Проверяем, выбрана ли хотя бы одна строка
            if (listView2.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in listView2.SelectedItems)
                {
                    // Получаем индекс элемента в ListView
                    int index = selectedItem.Index;

                    // Удаляем элемент из ListView
                    listView2.Items.Remove(selectedItem);

                    // Удаляем объект из списка сотрудников emps
                    if (index >= 0 && index < emps.Count)
                    {
                        emps.RemoveAt(index);
                    }
                }

                MessageBox.Show("Выбранные строки успешно удалены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                NewWards newWardsform = new NewWards(manuls);
                if (newWardsform.ShowDialog() == DialogResult.OK)
                {
                    var manulToAdd = new NewPallasCat(newWardsform.manulToAdd);
                    var manulToDell = new NewPallasCat(newWardsform.manulToDel);
                    Employee emp = new ManulKeeper(listView2.Items[listView2.SelectedIndices[0]].SubItems[2].Text);
                    if (checkBox2.Checked)
                    {
                        emp.Info += TextMessage;
                    }
                    if (!checkBox2.Checked)
                    {
                        emp.Info -= TextMessage;
                    }
                    if (manulToDell.Name != "")
                    {
                        emp.RemoveWard(manulToDell);
                    }
                    if (manulToAdd.Name != "")
                    { 
                        emp.AddWard(manulToAdd);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для работы с подопечными.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void TextMessage(string text)
        {
            richTextBox1.Text += text;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            ChangeName changeNameform = new ChangeName();
            if (changeNameform.ShowDialog() == DialogResult.OK)
            {
                //Проверяем, выбрана ли хотя бы одна строка
                if (listView2.SelectedItems.Count > 0)
                {
                    //Employee emp = new ManulKeeper(listView2.Items[listView2.SelectedIndices[0]].SubItems[2].Text);
                    Employee emp = emps[listView2.SelectedIndices[0]];
                    if (checkBox1.Checked)
                    {
                        emp.NameChanged += TextMessage;
                    }
                    else
                    {
                        emp.NameChanged -= TextMessage;
                    }
                    var curlist = listView2.Items[listView2.SelectedIndices[0]].SubItems[2].Text = changeNameform.newName;
                    emp.Name = curlist;
                }
                else
                {
                    MessageBox.Show("Выберите строку для правки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ExchangeEnclosure enclosureForm = new ExchangeEnclosure(manuls);
            enclosureForm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            List<string> ZooList = listBox1.Items.Cast<string>().ToList(); //LINQ
            TaskManagement taskform = new TaskManagement(ZooList, emps);
            taskform.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MedCards medCardsform = new MedCards();
            medCardsform.Show();
        }
    }
}
