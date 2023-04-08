using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.SaleProject.Customers;
public class HistoryAppService :
    CrudAppService<
        History, //The Book entity
        HistoryDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateHistoryDto>, //Used to create/update a book
    IHistoryAppService //implement the IBookAppService
{
    public HistoryAppService(IRepository<History, Guid> repository)
        : base(repository)
    {

    }
}