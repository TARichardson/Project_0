using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Entities
{
    public class BusinessAccount : Account
    {
        public override bool WithDraw(float sum)
        {
                base.Balances -= sum;
                return true;
        }
    }
}
