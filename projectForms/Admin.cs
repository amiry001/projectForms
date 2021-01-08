using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectForms
{
    class Admin
    {
        string email;
        string password;
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        public Admin(string email, string password)
        {
            Email = email;
            Password = password;
        }

      
    }                
      
      
       
         
           
            
        

      
         
}