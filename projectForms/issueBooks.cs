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
    public partial class issueBooks : Form
    {
        SqlConnection con = new SqlConnection(@" Server = AMIRY-FATIMA; Database = BookRMS; Trusted_Connection = True");
        public issueBooks()
        {
            InitializeComponent();
        }

        private void issueBooks_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            else
            {
                con.Open();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int bookQuantity = 0;

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from Book_info where BookName= '" +tbbook.Text+"' ";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
               bookQuantity = Convert.ToInt32(dr2["AvailableBooks"].ToString());
            }

            if (bookQuantity > 0)
            {



                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into issue_books values('" + textBox1.Text + "','" + tbname.Text + "','" + tbsurname.Text + "','" + tbemail.Text + "','" + tbbook.Text + "','" + dateTimePicker1.Value.ToShortDateString() +"','')";
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update Book_info set AvailableBooks=AvailableBooks-1 where BookName='" + tbbook.Text + "'";
                cmd1.ExecuteNonQuery();


                MessageBox.Show("Book issued successfully");
            }
            else 
            {
                MessageBox.Show("Book not available!");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Register where enrollmentNO='" + textBox1.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("This Member Not Found!");
            }
            else
            {

                foreach (DataRow dr in dt.Rows)
                {
                    tbname.Text = dr["name"].ToString();
                    tbsurname.Text = dr["surName"].ToString();
                    tbemail.Text = dr["Email"].ToString();
                    
                   
                  

                }
            }
        }

        private void tbbook_KeyUp(object sender, KeyEventArgs e)
        {
            int count = 0;
            if (e.KeyCode != Keys.Enter)
            {
                listBox1.Items.Clear();
                
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select* from Book_info where BookName like('%" + tbbook.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                count = Convert.ToInt32(dt.Rows.Count.ToString());

                if (count>0)
                {
                    listBox1.Visible = true;
                    foreach ( DataRow dr in dt.Rows)
                    {
                        listBox1.Items.Add(dr["BookName"].ToString());
                    }
                }
                
            }

        }

        private void tbbook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
               tbbook.Text= listBox1.SelectedItem.ToString();
                listBox1.Visible = false;
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            tbbook.Text = listBox1.SelectedItem.ToString();
           listBox1.Visible = false;
        }
    }
}
