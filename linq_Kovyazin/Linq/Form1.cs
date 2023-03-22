using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Linq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            List<People> lyudi = new List<People>();
            StreamReader sr = new StreamReader("zad1.txt");
            
            while (!sr.EndOfStream)
            {
                
                string file = sr.ReadLine();
                if (File.Exists(file))
                {
                    MessageBox.Show("Файл не найден!");
                }
                string[] razdel = file.Split(new char[] { ' ' });
                string name = razdel[0];
                string surname = razdel[1];
                string otchestvo = razdel[2];
                int age = int.Parse(razdel[3]);
                double weight = double.Parse(razdel[4]);
                People people = new People(name, surname, otchestvo, age, weight);
                lyudi.Add(people);
            }
            var proverka = from people in lyudi
                           where people.age < 40
                           select people;
            foreach (People peop in proverka)
            {
                listBox1.Items.Add($"{peop.name},{peop.surname},{peop.otchestvo},{peop.age},{peop.weight}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            listBox2.Visible = false;
            listBox3.Visible = false;
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Visible = true;
            listBox3.Visible = true;

            List<Departament> departament = new List<Departament>()
            { 
                new Departament { Name = "Отдел закупок", Reg ="Германия"},
                new Departament { Name = "Отдел продаж", Reg ="Испания" },
                new Departament { Name = "Отдел маркетинга", Reg ="Испания" }


            };
            List<Employ> employes = new List<Employ>()
            {
                new Employ {Name="Иванов", departament =" Отдел закупок "},
                new Employ {Name="Петров",departament =" Отдел закупок "},
                new Employ {Name="Сидоров", departament =" Отдел продаж "},
                new Employ {Name="Лямин", departament =" Отдел продаж "},
                new Employ {Name="Сидоренко", departament =" Отдел маркетинга "},
                new Employ {Name="Кривоносов", departament =" Отдел продаж "}

            };
            var proverka1 = from employes1 in employes
                            join departament1 in departament on employes1.departament equals departament1.Name
                            group employes1 by departament1.Reg into gr1
                            select new { departament = gr1.ToList(), Reg = gr1.Key };
            foreach(var gr in proverka1)
            {
                listBox2.Items.Add(gr.Reg);
                foreach(var info in gr.departament)
                {
                    listBox2.Items.Add($"{info.Name},{info.departament}");
                }
            }
            var proverka2 = from emp in employes
                            join depart in departament on emp.departament equals depart.Name
                            where depart.Reg.ToUpper().StartsWith("И")
                            select emp;
            foreach(var info in proverka2)
            {
                listBox3.Items.Add($"{info.Name},{info.departament}");
            }


        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}

