using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp
{
    public class Client
    {
        public string Name { get; set; }
        public string IdNumber { get; set; }
        public Account Account { get; set; }

        public Client(string name, string idNumber)
        {
            Name = name;
            IdNumber = idNumber;
            Account = new Account();
        }
    }
}
