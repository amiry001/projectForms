using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectForms
{
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double allowance = 0;
            if (listBox1.SelectedIndex == 0)
                allowance = 2.5;
            if (listBox1.SelectedIndex == 1)
                allowance = 4.5;
            if (listBox1.SelectedIndex == 2)
                allowance = 1.5;
            double salary = 0;
            salary += int.Parse(textBox3.Text);

            if(checkBox1.Checked ==true)
            {
                salary += 1000;
            }

            if (checkBox2.Checked == true)
            {
                salary += 2000;
            }
            if (checkBox3.Checked == true)
            {
                salary += salary * (allowance / 100);
            }
            textBox2.Text = salary.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();



        }
    }
}
