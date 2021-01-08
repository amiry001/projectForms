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
    public partial class returnBooks : Form
    {
        SqlConnection con = new SqlConnection(@" Server = AMIRY-FATIMA; Database = BookRMS; Trusted_Connection = True");
        public returnBooks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            fill_grid(textBox1.Text);

        }

        private void returnBooks_Load(object sender, EventArgs e)
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

        public void fill_grid(string enrollment)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select* from issue_books where enrollmentNo='"+enrollment.ToString()+"'and BookReturnDate=''";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select* from issue_books where id='"+i+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt); 
            foreach (DataRow dr in dt.Rows)
            {
                label2.Text = dr["BookName"].ToString();
                label3.Text = Convert.ToString(dr["BookIssuedate"].ToString());

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update issue_books set BookReturnDate='"+dateTimePicker1.Value.ToString()+"' where id='"+i+"'";
            cmd.ExecuteNonQuery();


            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update Book_info set AvailableBooks=AvailableBooks+1 where BookName='" + label2.Text + "'";
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Book returned successfully");
            fill_grid(textBox1.Text);
        }

      
    }
}
