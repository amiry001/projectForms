using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
namespace projectForms
{
    class Register

    {
        int registerID;
        string name;
        string surname;
        int phoneNo;
        string email;
        string gender;
        int membershipID;
        string adress;
        DateTime membershipdate;

        public Register(int registerID, string name, string surname, int phoneNo,
            string email, string gender, int membershipID, string adress, DateTime membershipdate)
        {
            RegisterID = registerID;
            Name = name;
            Surname = surname;
            PhoneNo = phoneNo;
            Email = email;
            Gender = gender;
            MembershipID = membershipID;
            Adress = adress;
            Membershipdate = membershipdate;
        }

        public int RegisterID { get => registerID; set => registerID = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int PhoneNo { get => phoneNo; set => phoneNo = value; }
        public string Email { get => email; set => email = value; }
        public string Gender { get => gender; set => gender = value; }
        public int MembershipID { get => membershipID; set => membershipID = value; }
        public string Adress { get => adress; set => adress = value; }
        public DateTime Membershipdate { get => membershipdate; set => membershipdate = value; }
    }


  
    


    


}
