using Acme.SaleProject.Customers;
using AutoMapper;

namespace Acme.SaleProject.Web;

public class SaleProjectWebAutoMapperProfile : Profile
{
    public SaleProjectWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<CustomerDto, CreateUpdateCustomerDto>();
    }
}
