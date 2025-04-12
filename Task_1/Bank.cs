using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace Task_1

{
    internal class Bank
    {
        private static Bank? instance;
        private string name;
        private decimal insertRate;
        private decimal amount;
        public List<Deposit> deposits = new List<Deposit>();

        public decimal GetAmount()
        {
            return amount;
        }

        public void SetAmount(decimal newAmount)
        {
            amount = newAmount;
            return;
        }

        private Bank(string inname, decimal ininsertRate)
        {
            name = inname;
            insertRate = ininsertRate;
            amount = 0;

        }
        public static Bank GetInstance(string inname, decimal ininsertRate)
        {
            if (instance == null)
            {
                instance = new Bank(inname, ininsertRate);
            }
            return instance;
        }

        public decimal CalculateInterestPayment(Deposit deposit, int monthAmount)
        {
            decimal payment = 0;
            decimal newsize = deposit.GetSize();
            while (monthAmount > 0)
            {
                payment += newsize * insertRate;
                newsize += payment;
                monthAmount--;
            }
            return payment;
        }
        
    }
}
