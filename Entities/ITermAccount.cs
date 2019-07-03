using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface ITermAccount : IAccount
    {
        bool Matrity { get; set; }
    }
}
