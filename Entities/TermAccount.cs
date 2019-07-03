using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Entities
{
    public class TermAccount : Account, ITermAccount
    {
        public bool Matrity { get; set; }

        public override bool WithDraw(float sum)
        {
            float newBal = base.Balances - sum;
            if (newBal > 0 && Matrity)
            {
                base.Balances = newBal;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
