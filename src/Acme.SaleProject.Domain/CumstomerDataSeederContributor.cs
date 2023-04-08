using Acme.SaleProject.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.SaleProject
{
    public class CumstomerDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Customer, Guid> _bookRepository;
        public CumstomerDataSeederContributor(IRepository<Customer, Guid> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _bookRepository.GetCountAsync() <= 0)
            {
                await _bookRepository.InsertAsync(
                    new Customer
                    {
                        Name = "John",
                        NumberPhone = "+841239123",
                        Address = "New York",
                        Status = CustomerStatus.NotContactedYet
                    },
                    autoSave: true
                );

                await _bookRepository.InsertAsync(
                    new Customer
                    {
                        Name = "Malshell",
                        NumberPhone = "+841231223",
                        Address = "VietName",
                        Status = CustomerStatus.Processing
                    },
                    autoSave: true
                );
            }
        }
    }
}
