using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.SaleProject.Customers
{
    public class Customer: AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string NumberPhone { get; set; }
        public string Address { get; set; }
        public CustomerStatus Status { get; set; }
    }
}
