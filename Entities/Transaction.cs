using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Entities
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public TransactionType Type { get; set; }
        public string Log { get; set; }
        public DateTime Date { get; set; }
        public string PrintDetails { get => $"ID: {TransactionID} Type: {Type} Date: {Date}"; }
    }
}
