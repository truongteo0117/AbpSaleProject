using Acme.SaleProject.Customers;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.SaleProject;
    public class HistoryDataSeederContributor 
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<History, Guid> _bookRepository;

    public HistoryDataSeederContributor(IRepository<History, Guid> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _bookRepository.GetCountAsync() <= 0)
        {
            await _bookRepository.InsertAsync(
                new History
                {
                    Name = "Data 1",
                    NumberPhone = "+841231231",
                    Status = CustomerStatus.Cancel,
                    ProcessBy = "Admin",
                    ProcessDate = new DateTime(1949, 6, 8),
                    Description = "None",
                    ProductName = "asdf",
                    Price = 1.20f,


                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new History
                {
                    Name = "Data 2",
                    NumberPhone = "+841231232",
                    Status = CustomerStatus.Cancel,
                    ProcessBy = "Admin",
                    ProcessDate = new DateTime(1995, 9, 27),
                    Description = "None",
                    ProductName = "asdf",
                    Price = 1.20f,
                },
                autoSave: true
            );
        }
    }
}
