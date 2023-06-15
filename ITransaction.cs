using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal interface ITransaction
    {
        List<Customer> Send(List<Customer> list);
    }
}
