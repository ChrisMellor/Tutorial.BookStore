using AutoMapper;
using Tutorial.BookStore.Authors;
using Tutorial.BookStore.Books;

namespace Tutorial.BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();

        CreateMap<Author, AuthorDto>();
    }
}
