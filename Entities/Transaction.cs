using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public string Type { get; set; }
        public string Log { get; set; }
        public DateTime Date { get; set; }
        public string Print { get; }
    }
}
