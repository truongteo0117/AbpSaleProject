using Acme.SaleProject.Customers;
using AutoMapper;

namespace Acme.SaleProject;

public class SaleProjectApplicationAutoMapperProfile : Profile
{
    public SaleProjectApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Customer, CustomerDto>();
        CreateMap<CreateUpdateCustomerDto, Customer>();
        CreateMap<History, HistoryDto>();
        CreateMap<CreateUpdateHistoryDto, History>();
    }
}
