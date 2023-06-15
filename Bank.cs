using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using BankApp;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;

namespace BankApp
{
    public class Bank
    {
        List<Admin> listAdmin;
        List<Customer> listCustomer;
        public Bank()
        {
            listAdmin = new List<Admin>();
            listCustomer = new List<Customer>();
            //sample data
            Admin admin = new Admin("hoangtran", "12345", "Tran Huy Hoang", 2003, "Super admin");
            listAdmin.Add(admin);
            Customer cus1 = new Customer("hoangtran123", "12345", "Tran Huy Hoang", 2003, "user",100);
            Customer cus2 = new Customer("hoangtran12345", "12345", "Tran Huy Hoang", 2003, "user",200);
            Customer cus3 = new Customer("hoangtran12367", "12345", "Tran Huy Hoang", 2003, "user",300);
            listCustomer.Add(cus1);
            listCustomer.Add(cus2);
            listCustomer.Add(cus3);
            //transact sample   
            Transaction tran = new Transaction("Bank", "hoangtran123", 100);
            cus1.addTransaction(tran);
        }
        public Boolean Exit()
        {
            Console.WriteLine("1-Login\n2-Exit");
            string input = Console.ReadLine();
            if (input.Equals("1"))
            {
                Login();
            }
            else
            {
                return false;
            }
            return true;

        }
       public void Login()
        {
            Console.Write("    Enter Username: ");
            string inputUsername = Console.ReadLine();
            Console.Write("    Enter password: ");
            string inputPassword = Console.ReadLine();
            
           if(checkLogin(inputUsername,inputPassword) is Admin )
            {
                
                Admin admin = (Admin)checkLogin(inputUsername, inputPassword);
                adminAction(admin);
            }
            else if (checkLogin(inputUsername, inputPassword) is Customer)
            {
                Customer customer = (Customer)checkLogin(inputUsername, inputPassword);
                customerAction(customer);
            }
            else
            {
                Console.WriteLine("\n                    ACCOUNT NOT EXIST\n");
            }

        }
        //check any account valid in list
        private Account checkLogin(string username,string password)
        {
            foreach (Admin admin in listAdmin)
            {
                if((username.Equals(admin.Name))&&(password.Equals(admin.PassWord)))
                    { return admin; }
            }
            foreach (Customer customer in listCustomer)
            {
                if ((username.Equals(customer.Name)) && (password.Equals(customer.PassWord)))
                { return customer; }
            }
            return null;
        }

        static void Main()
        {

            Boolean loop = true;
            Bank bank = new Bank();
            do
            {
                loop = bank.Exit();

            } while (loop);
        }
        private void adminAction(Admin admin)
        {
            string option = " ";
            do
            {
                admin.Login();

                Console.WriteLine("                    1-View All Users");
                Console.WriteLine("                    2-Add New User");
                Console.WriteLine("                    3-Update User");
                Console.WriteLine("                    4-Delete User");
                Console.WriteLine("                    5-Send Money");
                Console.WriteLine("                    6-View All Transactions");
                Console.WriteLine("                    Enter-Exit");

                Console.Write("\n                   Choose Your Option: ");
                 option = Console.ReadLine();
                if(option.Equals("1"))
                {
                    admin.viewAllCustomer(listCustomer);
                }
                //
                else if(option.Equals("2")) {
               
                       
                    listCustomer.Add(admin.addNewCustomer());
                        Console.WriteLine("\n                    ADD SUCCESSFUL\n");


                }
                //
                else if(option.Equals("3")) {
                    
                    listCustomer= admin.updateCustomer(listCustomer);
                }
                //
                else if(option.Equals("4")) {

                    listCustomer = admin.deleteCustomer(listCustomer);


                }
                //
                else if(option.Equals("5")) {
                    listCustomer = admin.Send(listCustomer);

                }
                else if(option.Equals("6"))
                {
                    admin.viewAllTransactions(listCustomer);

                }



            } while (!option.Equals(""));
        }
   private void customerAction(Customer customer)
        {
            string option = " ";
            do
            {
                customer.Login();
                Console.WriteLine("                    1-View Information");
                Console.WriteLine("                    2-View Transaction");
                Console.WriteLine("                    3-Transfer");
                Console.WriteLine("                    Enter-Exit");
                Console.Write("                    Choose Your Option: ");
                option = Console.ReadLine();
                if(option.Equals("1"))
                {
                    customer.viewInformation();
                }
                else if(option.Equals("2"))
                {
                    customer.viewAllTransaction();
                }
                else if(option.Equals("3"))
                {
                    listCustomer= customer.Send(listCustomer);
                }
            } while (!option.Equals(""));
    }


    }
}
