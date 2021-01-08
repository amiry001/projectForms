using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace projectForms
{
    public partial class Registeration : Form
    {
        SqlConnection con = new SqlConnection(@" Server = AMIRY-FATIMA; Database = BookRMS; Trusted_Connection = True");
        public Registeration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Register values('" + tbenroll.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','"+comboBox1.Text+"'," + textBox3.Text + "," + textBox4.Text + ",'" + textBox5.Text + "','" + textBox6.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            tbenroll.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text= "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
           

            MessageBox.Show("Member Added Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
