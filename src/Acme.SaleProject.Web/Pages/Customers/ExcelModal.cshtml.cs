using Acme.SaleProject.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Volo.Abp.Domain.Repositories;
using ClosedXML.Excel;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Acme.SaleProject.Web.Pages.Customers
{
    public class ExcelModalModel : SaleProjectPageModel
    {
        private readonly IRepository<Customer> _myEntityRepository;
        public CreateUpdateCustomerDto Customer { get; set; }
        public ExcelModalModel(IRepository<Customer> myEntityRepository)
        {
            _myEntityRepository = myEntityRepository;
        }
        public void OnGet()
        {
            Customer = new CreateUpdateCustomerDto();
        }
        public CustomerStatus GetStatusbyName(string name)
        {
            //Default is NotContactedYet
            CustomerStatus status = CustomerStatus.NotContactedYet;
            foreach (CustomerStatus item in Enum.GetValues(typeof(CustomerStatus)))
            {
                if (item.ToString() == name)
                {
                    status = item;
                }
            }
            return status; 
        }
        public Task<IActionResult> OnPostImportAsync(IFormFile excel)
        {
            List<Customer> list = new List<Customer>();

            using (var workbook = new XLWorkbook(excel.OpenReadStream()))
            {
                var worksheet = workbook.Worksheet("Sheet1");

                var count = 0;
                foreach (var row in worksheet.Rows())
                {
                    count += 1;
                    if (count > 1 && (row.Cell(1).Value.ToString() != null || row.Cell(1).Value.ToString() != string.Empty))
                    {
                        list.Add(new Customer
                        {
                            Name = row.Cell(1).Value.ToString(),
                            NumberPhone = row.Cell(2).Value.ToString(),
                            Address = row.Cell(3).Value.ToString(),
                            Status = GetStatusbyName(row.Cell(4).Value.ToString()),
                        });
                    }
                }
                UpdateDB(list);
            }
            return Task.FromResult<IActionResult>(Page());
        }
        public async Task<IActionResult> UpdateDB(List<Customer> customer)
        {
            await _myEntityRepository.InsertManyAsync(customer);
            return NoContent();
        }
    }
}
