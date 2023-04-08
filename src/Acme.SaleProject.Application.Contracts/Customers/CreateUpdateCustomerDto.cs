using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.SaleProject.Customers
{
    public class CreateUpdateCustomerDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public string NumberPhone { get; set; }

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public CustomerStatus Status { get; set; } = CustomerStatus.NotContactedYet;
    }
}
