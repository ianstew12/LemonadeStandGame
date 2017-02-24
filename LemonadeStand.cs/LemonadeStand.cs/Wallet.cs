using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.cs
{
    public class Wallet       //rather than a strictly physical wallet, this basically represents "funds" 
    {
        public decimal balance;

        public Wallet()
        {

        }
        public void DisplayBalance()
        {
            Console.Write("\nYour current balance: $" + balance/100+"\n");
        }

    }
}