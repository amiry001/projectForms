using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectForms
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@" Server = AMIRY-FATIMA; Database = BookRMS; Trusted_Connection = True");
        private int count;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
    
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText="select * from Admin where username ='"+textBox1.Text+"' AND password ='" +textBox2.Text+"' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());


            if (count == 0)
            {
                MessageBox.Show("Error in Login");
            }
            else
            {
                Welcome form = new Welcome();
                this.Hide();
                form.ShowDialog();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            label4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            checkBox1.Checked = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            checkBox1.Checked = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (con.State==ConnectionState.Open)
            {
                con.Close();
            }
            else
            {
                con.Open();
            }
            
        }

       
    }
   
    

}

