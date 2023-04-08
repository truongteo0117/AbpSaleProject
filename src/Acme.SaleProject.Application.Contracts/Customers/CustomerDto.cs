using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.SaleProject.Customers
{
    public class CustomerDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string NumberPhone { get; set; }
        public string Address { get; set; }
        public CustomerStatus Status { get; set; }
    }
}
