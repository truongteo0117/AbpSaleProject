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
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using DocumentFormat.OpenXml.Bibliography;


namespace Acme.SaleProject.Web.Pages.Customers
{
    public class OrderModel : SaleProjectPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        public int SelectedItemId { get; set; }
        public string TextSelect { get; set; }
        public List<SelectListItem> DropdownList { get; set; }
        public string CustomerName { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Price { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public string TotalAmout { get; set; }

        private readonly CustomerAppService _customerAppService;
        private readonly IRepository<History> _myEntityRepository;
        public OrderModel(CustomerAppService customerAppService, IRepository<History> myEntityRepository)
        {
            _customerAppService = customerAppService;
            _myEntityRepository = myEntityRepository;
        }
        public async Task OnGetAsync()
        {
            DropdownList = new List<SelectListItem>()
            {
                new SelectListItem() { Value = "10.9", Text = "Shoe" },
                new SelectListItem() { Value = "9.5", Text = "Hat" },
                new SelectListItem() { Value = "6.99", Text = "Jeans" }
            };

            var customerDto = await _customerAppService.GetAsync(Id);
            CustomerName = customerDto.Name;
        }
        public async Task<IActionResult> OnPostHandleDataAsync()
        {
            var customerDto = await _customerAppService.GetAsync(Id);

            //initialization new History
            History history = new History();

            history.Name = customerDto.Name;
            history.NumberPhone = customerDto.NumberPhone;
            history.ProcessDate = DateTime.Now;
            history.ProcessBy = CurrentUser.UserName; //current user is changing status
            history.Status = customerDto.Status;
            history.ProductName = Request.Form["TextSelect"].ToString();
            history.Description = Request.Form["Description"].ToString();
            history.Price = float.Parse(Request.Form["Price"].ToString());
            history.Quantity = int.Parse(Request.Form["Quantity"].ToString());
            history.TotalAmount = float.Parse(Request.Form["TotalAmount"].ToString());
            //Insert into history db
            await _myEntityRepository.InsertAsync(history);
            return NoContent();
            return NoContent();
        }
        //public async Task OnGetAsync()
        //{
        //    var customerDto = await _customerAppService.GetAsync(Id);
        //    OrderDto = new CreateOrderDto();

        //    MyOptions = new List<SelectListItem>
        //    {
        //        new SelectListItem { Value = "Shoe - 10$", Text = "Shoe - 10$" },
        //        new SelectListItem { Value = "Nintendo - 5.5$", Text = "Nintendo - 5.5$" },
        //        new SelectListItem { Value = "Xbox One - 4.9$", Text = "Xbox One - 4.9$" }
        //    };
        //}

        //public async Task<IActionResult> OnPostAsync()
        //{          
        //    return NoContent();
        //}
        //public async Task<IActionResult> WriteToHistory()
        //{
        //    var customerDto = await _customerAppService.GetAsync(Id);
        //    //initialization new History
        //    History history = new History();

        //    history.Name = customerDto.Name;
        //    history.NumberPhone = customerDto.NumberPhone;
        //    history.ProcessDate = DateTime.Now;
        //    history.ProcessBy = CurrentUser.UserName; //current user is changing status
        //    history.Status = customerDto.Status;
        //    history.ProductName = Request.Form["SelectedItemId"].ToString();
        //    history.Description = Request.Form["Description"].ToString();
        //    history.Price = float.Parse(Request.Form["Price"].ToString());
        //    history.Quantity = int.Parse(Request.Form["Quantity"].ToString());
        //    history.TotalAmount = float.Parse(Request.Form["TotalAmount"].ToString()); 
        //    //Insert into history db
        //    await _myEntityRepository.InsertAsync(history);
        //    return NoContent();
        //}
    }
}
