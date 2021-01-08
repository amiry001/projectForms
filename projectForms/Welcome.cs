using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectForms
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void bookTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Addbook ab = new Addbook();
            ab.ShowDialog();
        }

        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            view_books vb = new view_books();
             vb.ShowDialog();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registeration r = new Registeration();
            r.ShowDialog();
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_members vm = new view_members();
            vm.ShowDialog();
        }

        private void ıssueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            issueBooks ib = new issueBooks();
            ib.ShowDialog();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            returnBooks rb = new returnBooks();
            rb.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            book_stock bs = new book_stock();
            bs.ShowDialog();
            
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Email em = new Email();
            em.ShowDialog();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.ShowDialog();
        }

        private void viewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_emp ve = new View_emp();
            ve.ShowDialog();
        }

        private void salaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salary s = new Salary();
            s.ShowDialog();
        }
    }
}
