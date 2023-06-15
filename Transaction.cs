using BankApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Transaction
    {
        string fromAccount;
        string toAccount;
        double value;
        DateTime date;
        public Transaction(string fromAccount, string toAccount, double value)
        {
            this.fromAccount = fromAccount;
            this.toAccount = toAccount;
            this.value = value;
            date= DateTime.Now;
        }
        public string FromAccount
        {
            get { return fromAccount; }
            set { fromAccount = value; }
        }

        public string ToAccount
        {
            get { return toAccount; }
            set { toAccount = value; }
        }
        public double Value
        {
            get { return this.value; }
            set { this.value = value; }

        }
        public DateTime Date
        {
            get
            {
                return date;
            }
        }
        public void Display(string username)
        {
            //o ->output
            string ofromAccount = FromAccount.PadRight(20);
            string otoAccount = ToAccount.PadRight(20);
            string ovalue = "";
            if(toAccount.Equals(username))
            {
                 ovalue = ("+"+Value.ToString() + "$").PadRight(20);

            }
            else
            {
                ovalue = ("-" + Value.ToString() + "$").PadRight(20);

            }
            string odatetime = Date.ToString().PadRight(30);
            Console.WriteLine("║" + ofromAccount + "║" + otoAccount + "║" + ovalue + "║" + odatetime+ "║");


          
        }
                 



    }
}

