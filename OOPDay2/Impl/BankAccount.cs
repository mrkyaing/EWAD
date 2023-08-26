using OOPDay2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDay2.Impl {
    public class BankAccount :ICreditCard,IShowDetail {
        public string AccountNumber { get; set; }
        public decimal OpeningBalance { get; set; }

        public void DisplayInfo() {
            Console.WriteLine("Account Information");
            Console.WriteLine($"Account Number:{AccountNumber}");
            Console.WriteLine($"Available balance :{OpeningBalance}");
        }

        public decimal GetJapaneseYanExchangeRate(decimal amount) {
            return amount * 20;
        }

        public decimal GetSGDollorExchangeRate(decimal amount) {
            return amount * 1541.59m;
        }
        public decimal GetUSDollorExchangeRate(decimal amount) {
            return amount * 2950;
        }
    }
}
