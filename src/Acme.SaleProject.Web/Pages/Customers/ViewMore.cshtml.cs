using Acme.SaleProject.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;
using Volo.Abp.Domain.Repositories;

namespace Acme.SaleProject.Web.Pages.Customers
{
    public class ViewMoreModel : SaleProjectPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public HistoryDto historyDto { get; set; }
        private readonly HistoryAppService _customerAppService;
        public ViewMoreModel(HistoryAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }
        public async Task OnGetAsync()
        {
            historyDto = await _customerAppService.GetAsync(Id);
        }
    }
}
