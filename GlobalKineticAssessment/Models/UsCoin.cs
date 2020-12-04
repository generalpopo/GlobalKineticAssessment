using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalKineticAssessment.Models
{
    public class UsCoin : ICoin
    {
        const int STANDARD_VOLUME = 42;
        public UsCoin(decimal Amount)
        {
            Volume = Amount * STANDARD_VOLUME;
            this.Amount = Amount;
        }
        public decimal Amount { get; set; }
        public decimal Volume { get; set; }
    }
}
