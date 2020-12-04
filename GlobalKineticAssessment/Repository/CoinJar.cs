using GlobalKineticAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalKineticAssessment.Repository
{
    public class CoinJar : ICoinJar
    {
        private decimal TotalAmount;
        private List<ICoin> Coins;

        public CoinJar()
        {
            Coins = new List<ICoin>();
            TotalAmount = 0;
        }


        public void AddCoin(ICoin coin)
        {
            if (coin != null)
            {
                Coins.Add(coin);
                TotalAmount += coin.Amount;
            }
        }

        public decimal GetTotalAmount()
        {
            return TotalAmount;
        }

        public void Reset()
        {
            TotalAmount = 0;
            Coins.Clear();
        }
    }
}
