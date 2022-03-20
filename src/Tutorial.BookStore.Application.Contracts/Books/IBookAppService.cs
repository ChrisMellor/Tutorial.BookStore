using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Tutorial.BookStore.Books
{
    public interface IBookAppService : ICrudAppService<BookDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookDto> { }
}
