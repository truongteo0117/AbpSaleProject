using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Acme.SaleProject.Customers;
using System.Collections.Generic;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;
using System;

namespace Acme.SaleProject.Web.Pages.Customers
{
    public class CreateModalModel : SaleProjectPageModel
    {
        [BindProperty]
        public CreateUpdateCustomerDto Customer { get; set; }

        private readonly CustomerAppService _customerAppService;
        public CreateModalModel(CustomerAppService bookAppService)
        {
            _customerAppService = bookAppService;
        }

        public void OnGet()
        {
            Customer = new CreateUpdateCustomerDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _customerAppService.CreateAsync(Customer);
            return NoContent();
        }
    }
}
