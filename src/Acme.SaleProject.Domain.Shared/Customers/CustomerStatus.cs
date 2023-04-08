using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SaleProject.Customers
{
    public enum CustomerStatus
    {
        NotContactedYet,
        Block,
        Contacted,
        Processing,
        Cancel
    }
}
