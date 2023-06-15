using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Account
    {
        string userName;
        string passWord;
        string fullName;
        int yearBorn;
        string role;
        public Account(string username, string password, string fullname, int yearborn, string role)
        {
            Name = username;
            PassWord = password;
            FullName = fullname;
            YearBorn = yearborn;
            Role = role;
        }
    
        public string Name{
            get
            {
                return userName;
            }
            set {
                if ((value.Length < 4)||(value.Length > 20)){
                    Console.WriteLine("                USERNAME LENGTH MUST 4->20");
                    userName = "-1";
                }
                else
                {
                    userName = value;
                }
            }
        }
        public string PassWord
        {
            get
            {
                return passWord;
            }
            set
            {
                if ((value.Length < 4) || (value.Length > 20))
                {
                    Console.WriteLine("                PASSWORD LENGTH MUST 4->20");
                    passWord = "-1";
                }
                else
                {
                    passWord = value;
                }
            }
        }
        public string FullName{
            get { return fullName; }
            set {
                if ((value.Length < 4) || (value.Length > 20))
                {
                    Console.WriteLine("                FULL NAME LENGTH MUST 4->20");
                    fullName = "-1";
                }
                else
                {
                    fullName = value;
                }

            }   
        }
        public int YearBorn
        {
            get { return yearBorn; }
            set
            {
                if ((value<1000) || (value>DateTime.Now.Year))
                {
                    Console.WriteLine("                YEAR BORN MUST >1000 AND NOT >"+DateTime.Now.Year);
                    yearBorn = -1;
                }
                else
                {
                    yearBorn = value;
                }
            }
        }
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        public virtual void Login()
        {
            Console.Write("YOU ARE ");
        }
    }


}

