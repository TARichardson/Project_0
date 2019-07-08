using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface ILoanAccount
    {
        float LoanAmount { get; set; }
        bool LoanTransfered { get; set; }
        bool PayLoan(float sum);
        float Transfer();
    }
}
