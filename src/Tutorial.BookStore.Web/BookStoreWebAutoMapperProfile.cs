using AutoMapper;
using Tutorial.BookStore.Books;

namespace Tutorial.BookStore.Web;

public class BookStoreWebAutoMapperProfile : Profile
{
    public BookStoreWebAutoMapperProfile()
    {
        CreateMap<BookDto, CreateUpdateBookDto>();
    }
}
