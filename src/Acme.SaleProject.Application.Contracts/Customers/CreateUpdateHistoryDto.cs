using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.SaleProject.Customers
{
    public class CreateUpdateHistoryDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        public string NumberPhone { get; set; }
        [Required]
        public CustomerStatus Status { get; set; } = CustomerStatus.Cancel;
        [Required]
        public string ProcessBy { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ProcessDate { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public float TotalAmount { get; set; }
    }
}
