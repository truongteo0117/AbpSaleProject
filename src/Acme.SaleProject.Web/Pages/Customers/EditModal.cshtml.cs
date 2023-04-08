using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;
using Acme.SaleProject.Customers;
using Volo.Abp.Users;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System.Collections.Generic;
using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Acme.SaleProject.Web.Pages.Customers
{
    public class EditModalModel : SaleProjectPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateCustomerDto Customer { get; set; }
        private readonly CustomerAppService _customerAppService;
        private readonly IRepository<History> _myEntityRepository;
        public EditModalModel(CustomerAppService customerAppService, IRepository<History> myEntityRepository)
        {
            _customerAppService = customerAppService;
            _myEntityRepository = myEntityRepository;
        }
        public async Task OnGetAsync()
        {
            var customerDto = await _customerAppService.GetAsync(Id);
            Customer = ObjectMapper.Map<CustomerDto, CreateUpdateCustomerDto>(customerDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var customerDto = await _customerAppService.GetAsync(Id);
            await _customerAppService.UpdateAsync(Id, Customer);

            if (customerDto.Status != Customer.Status)
                WriteToHistory();
            
            return NoContent();
        }
        public async Task<IActionResult> WriteToHistory()
        {
            //initialization new History
            History history = new History();

            history.Name = Customer.Name;
            history.NumberPhone = Customer.NumberPhone;
            history.ProcessDate = DateTime.Now;
            history.ProcessBy = CurrentUser.UserName; //current user is changing status
            history.Status = Customer.Status;
            //Insert into history db
            await _myEntityRepository.InsertAsync(history);
            return NoContent();
        }
    }
}
