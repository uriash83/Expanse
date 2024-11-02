using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanse.Models.Models
{
    public class CryptoCurrency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }

        public bool IsFiduciary { get; set; }
        public string? Info { get; set; }


        //public virtual List<CryptoWalletCurrency> CurrenciesWallet { get; set; } = new List<CryptoWalletCurrency>();// mniej zajmuje miejsca

        //public virtual List<CryptoTransaction> CryptoTransactionsBuy { get; set; } = new List<CryptoTransaction>();
        //public virtual List<CryptoTransaction> CryptoTransactionsSell { get; set; } = new List<CryptoTransaction>();
    }
}
