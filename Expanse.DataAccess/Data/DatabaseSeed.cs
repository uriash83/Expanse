using Expanse.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanse.DataAccess.Data
{
    public class DatabaseSeed()
    {
        public static void Seed(ExpanseDbContext context)
        {
            if(!context.CryptoCurrencies.Any())
            {
                var cc1 = new CryptoCurrency { Ticker = "BTC", Name = "Bitcoin", IsFiduciary = false };
                var cc2 = new CryptoCurrency { Ticker = "ETH", Name = "Etherum", IsFiduciary = false };
                var cc3 = new CryptoCurrency { Ticker = "DOT", Name = "Polka", IsFiduciary = false };
                var cc4 = new CryptoCurrency { Ticker = "USDT", Name = "Theter", IsFiduciary = false };

                var cryptoCurrencies = new CryptoCurrency[]
                {
                    cc1, cc2, cc3, cc4


                };
                foreach (var cryptoCurrency in cryptoCurrencies)
                {
                    context.CryptoCurrencies.Add(cryptoCurrency);
                }

                context.SaveChanges();
            }
            
        }
    }
}
