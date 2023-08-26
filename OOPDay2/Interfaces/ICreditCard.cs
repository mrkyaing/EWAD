using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDay2.Interfaces {
    public interface ICreditCard {
        decimal GetSGDollorExchangeRate(decimal amount);
        decimal GetUSDollorExchangeRate(decimal amount);
        decimal GetJapaneseYanExchangeRate(decimal amount);
    }
}
