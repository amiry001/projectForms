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
    public partial class View_emp : Form
    {
        SqlConnection con = new SqlConnection(@" Server = AMIRY-FATIMA; Database = BookRMS; Trusted_Connection = True");
        public View_emp()
        {
            InitializeComponent();
        }

        private void View_emp_Load(object sender, EventArgs e)
        {
            try
            {


                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select* from Employee";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {


                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select* from Employee where Id like('" + textBox1.Text + "')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select* from Employee where Id=" + i + " ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    textBox8.Text = dr["EmployeeNo"].ToString();
                    textBox2.Text = dr["Ename"].ToString();
                    textBox3.Text = dr["Esurname"].ToString();
                    textBox4.Text = dr["Eaddress"].ToString();
                    textBox5.Text = dr["Ephone"].ToString();
                    textBox6.Text = dr["Eduty"].ToString();
                    

                }
                con.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Employee set EmployeeNo="+textBox8.Text+",Ename='" + textBox2.Text + "', Esurname='" + textBox3.Text + "', Eaddress='" + textBox4.Text + "', Ephone='" + textBox5.Text + "', Eduty='" + textBox6.Text + "' where Id =" + i + "";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Updated Successfully");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            con.Open();
            if (MessageBox.Show("Are you sure to delete", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)

            {


                int EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

                SqlCommand cmd = new SqlCommand("delete Employee where Id='" + EmployeeID + "'", con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("successfully deleted.");
                con.Close();
               
            }
        }
    }
}
