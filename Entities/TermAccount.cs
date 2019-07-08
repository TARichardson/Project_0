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
        public bool Maturity { get; set; }
        public DateTime DateOfMaturity { get; set; }


        public override bool WithDraw(float sum)
        {
            float newBal = base.Balances - sum;
            if (newBal >= 0 && Maturity)
            {
                base.Balances = newBal;
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void AccountUpdate()
        {
            base.AccountUpdate();
            DateTime current = DateTime.Now;
            if( current >= DateOfMaturity)
            {
                Maturity = true;
            }
        }


    }
}
