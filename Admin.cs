using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Admin:Account, ITransaction
    {
       public Admin(string username,string password,string fullname,int yearborn,string role) 
            : base(username,password,fullname,yearborn,role)    
        {
           
        }
        public void viewAllCustomer(List<Customer> list)
        {
            string ousername = "Username".PadRight(20);
            string opassword = "Password".PadRight(20);
            string ofullname = "Full Name".PadRight(20);
            string oyearborn = "Year Born".PadRight(10);
            string obalance = "Balance".PadRight(10);
            string orole = "Role".PadRight(10);

            //fullname year born balanmce
            Console.WriteLine("\n\n");
            Console.WriteLine("╔════════════════════╦════════════════════╦════════════════════╦══════════╦══════════╦══════════╗");
            Console.WriteLine("║" + ousername + "║" + opassword + "║" + ofullname + "║" + oyearborn + "║"+obalance+ "║"
                + orole + "║"
                );
            Console.WriteLine("╠════════════════════╬════════════════════╣════════════════════╣══════════╣══════════╣══════════╣");


            foreach (Customer cus in list)
            {
                cus.Display();
            }
            Console.WriteLine("╚════════════════════╩════════════════════╩════════════════════╩══════════╩══════════╩══════════╝");

        }
        public Customer addNewCustomer()
        {
            do
            {
                Console.Write("          Username: ");
                string username = Console.ReadLine();
                Console.Write("          Password: ");
                string password = Console.ReadLine();
                Console.Write("          Fullname: ");
                string fullname = Console.ReadLine();
                Console.Write("          Year Born: ");
                int yearborn = Int32.Parse(Console.ReadLine());
                Console.Write("          Balance: ");
                double balance = Double.Parse(Console.ReadLine());
                Customer cus = new Customer(username, password, fullname, yearborn, "user", balance);

                if ((cus.Name.Equals("-1")) || (cus.PassWord.Equals("-1")) || (cus.FullName.Equals("-1")) ||
                    (cus.YearBorn == -1) || (cus.Balance == -1)
                    )
                {

                    Console.WriteLine("\n                    ADD NOT SUCCESSFUL\n");

                }
                else
                {
                    return cus;
                }
            } while (true);




        }
        public List<Customer> updateCustomer(List<Customer> list)
        {
            Console.Write("                    Enter username of user to update: ");
            string username = Console.ReadLine();
           for(int i=0;i<list.Count;i++)
            {
                if (list[i].Name.Equals(username))
                {
                    

                         list[i] = addNewCustomer();

                        Console.WriteLine("\n                    UPDATE SUCCESSFUL\n");

                    return list;

                }
            }
            Console.WriteLine("\n                    USERNAME NOT EXIST\n");
            return list;


        }
        public List<Customer> deleteCustomer(List<Customer> list)
        {
            Console.Write("                    Enter username of user to delete: ");
            string username = Console.ReadLine();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name.Equals(username))
                {
                    list.RemoveAt(i);
                    Console.WriteLine("\n                    DELETE SUCCESSFUL\n");
                    return list;

                }
            }
            Console.WriteLine("\n                    USERNAME NOT EXIST\n");
            return list;
        }

        //implement interface
        public List<Customer> Send(List<Customer> list)
        {
            Console.Write("                    Enter Receive Username: ");
            string username = Console.ReadLine();
            if(validCustomer(username, list)==-1)
            {
                Console.WriteLine("                    RECEIVE ACCOUNT NOT EXIST");
            }
            else
            {
                int index = validCustomer(username, list);
                Customer cus = list[index];
                double value = 0;
                do
                {
                    Console.Write("                    Enter value: ");
                    value = Double.Parse(Console.ReadLine());
                    if (value <= 0)
                    {
                        Console.WriteLine("                    VALUE MUST BE  >= 0");
                    }
                    //Balance-=value;

                } while (value <= 0);
                cus.Balance = cus.Balance+ value;
                Transaction tran = new Transaction("Bank", cus.Name, value);
                cus.addTransaction(tran);
                Console.WriteLine("                    TRANSFER SUCCESSFUL");

            }
            return list;


        }
        //view all transaction:
        public void viewAllTransactions(List<Customer> list)
        {
            foreach(Customer cus in list)
            {
                Console.WriteLine(cus.Name);
                cus.viewAllTransaction();
            }
        }

        //find a customer inlisst return index
        private int validCustomer(string username, List<Customer> list)
        {
            for(int i=0;i< list.Count;i++)
            {
                if(list[i].Name.Equals(username))
                {
                    return i;
                }
            }
            return -1;
        }
        
        //overide
        public override void Login()
        {
            Console.Write("====================");
            base.Login();
            Console.Write(" ADMIN");
            Console.WriteLine("====================");

        }


    }
}
