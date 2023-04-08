using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.SaleProject.Customers
{
    public class HistoryDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string NumberPhone { get; set; }
        public CustomerStatus Status { get; set; }
        public string ProcessBy { get; set; }
        public DateTime ProcessDate { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public float TotalAmount { get; set; }
    }
}
