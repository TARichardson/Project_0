using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Entities
{
    public class LoanAccount : Account, ILoanAccount
    {
        private float _balances = 0;
        public bool LoanTransfered { get; set; }

        public override float Balances
        {
            get { return LoanAmount - _balances; }
            set {  }
        }
        public float LoanAmount { get; set; }
        public bool PayLoad(float sum)
        {
            _balances += sum;
            return true;
        }
        public override bool WithDraw(float sum)
        {
                return false;
        }
    }
}
