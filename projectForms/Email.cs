using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace projectForms
{
    public partial class Email : Form
    {
        public Email()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

         
            
                try
                {
                    label3.Text = "";

                    label3.ForeColor = Color.Black;


                    string to = textBox1.Text.Trim();
                    string subjet = textBox2.Text.Trim();
                    string body = richTextBox1.Text.Trim();


                    string smtpAddress = "smtp.gmail.com";
                    int portNumber = 587;
                    string emailfrom = "admiin985@gmail.com";
                    string password = "abcdefghijklmnop001";

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(emailfrom);
                        mail.To.Add(to);
                        mail.Subject = subjet;
                        mail.Body = body;
                        mail.IsBodyHtml = false;

                        SmtpClient smtp = new SmtpClient(smtpAddress, portNumber);
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(emailfrom, password);
                        smtp.EnableSsl = true;

                        smtp.Send(mail);

                        label3.Text = "Email Sent";
                        label3.ForeColor = Color.MediumSeaGreen;

                      
                      textBox1.Text = "";
                      textBox2.Text = "";
                      richTextBox1.Text = "";


                }
                }
                  catch (Exception ex)
                {

                MessageBox.Show(ex.Message);
                }  
         
    }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";
        }
    }
}
