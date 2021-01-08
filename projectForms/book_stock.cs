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
    public partial class book_stock : Form
    {
        SqlConnection con = new SqlConnection(@" Server = AMIRY-FATIMA; Database = BookRMS; Trusted_Connection = True");
        private string connectionString;

        public book_stock()
        {
            InitializeComponent();
        }

        private void book_stock_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            else
            {
                con.Open();
                fill_bookinfo();
            }
        }
        public void fill_bookinfo()
        {

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select id, BookName, BookAuthor, BookPages, BookEdition, BookType, BookQuantity, AvailableBooks from Book_info";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)

            {


                int bookID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
               
                SqlCommand cmd = new SqlCommand("delete Book_info where Id='" + bookID + "'", con);
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("successfully deleted.");
                fill_bookinfo();
            }

        

        }

        
    }
}
