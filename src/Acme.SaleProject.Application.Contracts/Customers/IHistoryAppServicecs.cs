using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.SaleProject.Customers;
public interface IHistoryAppService :
    ICrudAppService< //Defines CRUD methods
        HistoryDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateHistoryDto> //Used to create/update a book
{

}
