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
    public partial class Addbook : Form
    {
        SqlConnection con = new SqlConnection(@" Server = AMIRY-FATIMA; Database = BookRMS; Trusted_Connection = True");
        public Addbook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText ="insert into Book_info values('"+textBox1.Text+"','"+textBox2.Text+"',"+textBox3.Text+",'"+textBox4.Text+"',"+textBox5.Text+",'"+textBox6.Text+"','" +textBox7.Text+"',"+textBox8.Text+ "," + textBox8.Text + ")";
            cmd.ExecuteNonQuery();
            con.Close();


            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";

            MessageBox.Show("Book Added Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        
    }
}
