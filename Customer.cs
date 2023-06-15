using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Customer:Account
    {
        double balance;
        List<Transaction> transactions;
        public Customer(string username, string password, string fullname, int yearborn, string role,double balance)
      : base(username, password, fullname, yearborn, role)
        {
            Balance = balance;
            transactions = new List<Transaction>();
        }
        public double Balance
        {
            get { return balance; }
            set {
                if (value <= 0)
                {
                    Console.WriteLine("                BALANCE MUST BE >0");
                    balance = -1;
                }
                else
                {
                    balance = value;
                }
            
            }

        }
        public void viewInformation()
        {
            string ousername = Name.PadRight(20);
            string opassword = PassWord.PadRight(20);
            string ofullname = FullName.PadRight(20);
            string oyearborn = YearBorn.ToString().PadRight(10);
            string obalance = (Balance.ToString()+"$").PadRight(10);
            string orole = Role.PadRight(10);
            //fullname year born balanmce
            Console.WriteLine("╔════════════════════╦════════════════════╦════════════════════╦══════════╦══════════╦══════════╗");
            Console.WriteLine("║" + ousername + "║" + opassword + "║" + ofullname + "║" + oyearborn + "║" + obalance + "║"
                + orole + "║"
                );
         


            Console.WriteLine("╚════════════════════╩════════════════════╩════════════════════╩══════════╩══════════╩══════════╝");
        }
        public void viewAllTransaction()
        {

            string ofromAccount = "From Account".PadRight(20);
            string otoAccount = "Receive Account".PadRight(20);
            string ovalue = "Value($)".PadRight(20);
            string odatetime = "Date".PadRight(30);
            Console.WriteLine("\n\n");
            Console.WriteLine("╔════════════════════╦════════════════════╦════════════════════╦══════════════════════════════╗");
            Console.WriteLine("║" + ofromAccount + "║" + otoAccount + "║" + ovalue + "║" + odatetime+ "║");
            Console.WriteLine("╠════════════════════╬════════════════════╣════════════════════╣══════════════════════════════╣");
           
            
            foreach (Transaction transac in transactions)
            {
                
                transac.Display(Name);
            }
            Console.WriteLine("╚════════════════════╩════════════════════╩════════════════════╩══════════════════════════════╝");

            Console.WriteLine("\n\n");

        }
        public void addTransaction(Transaction tran)
        {
           
            transactions.Add(tran);
        }
        public List<Customer> Send(List<Customer> list)
        {
            Console.Write("                    Enter Receive Username: ");
            string username = Console.ReadLine();
            if (validCustomer(username, list) == -1)
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
                if(this.Balance-value>=0){
        cus.Balance +=  value;
                this.Balance -= value;
                //receive account
                Transaction tran = new Transaction(this.Name, cus.Name, value);
                cus.addTransaction(tran);
                //this account
                this.transactions.Add(tran);
                Console.WriteLine("                    TRANSFER SUCCESSFUL");

                }
                else{
          Console.WriteLine("                    Account DON\"T HAVE ENOUGH MONEY");

                }
        


            }
            return list;

        }
        private int validCustomer(string username, List<Customer> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name.Equals(username))
                {
                    return i;
                }
            }
            return -1;
        }
        public void Display()
        {
            string ousername = Name.PadRight(20);
            string opassword =PassWord.PadRight(20);
            string ofullname = FullName.PadRight(20);
            string oyearborn = YearBorn.ToString().PadRight(10);
            string obalance = (Balance.ToString() + "$").PadRight(10);
            string orole=Role.PadRight(10);
            //fullname year born balanmce
            Console.WriteLine("║" + ousername + "║" + opassword + "║" + ofullname + "║" + oyearborn + "║" + obalance + "║"
                + orole+ "║"
                );
        }
        public override void Login()
        {
            Console.Write("====================");
            base.Login();
            Console.Write(" USER");
            Console.WriteLine("====================");

        }


    }
}
