using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tutorial.BookStore.Books;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Tutorial.BookStore
{
    public class BookStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _repository;

        public BookStoreDataSeederContributor(IRepository<Book, Guid> repository)
        {
            _repository = repository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            var booksExist = await _repository.GetCountAsync() > 0;

            if (!booksExist)
            {
                var books = new List<Book>()
                {
                    new()
                    {
                        Name = "1984",
                        Type = BookType.Dystopia,
                        PublishDate = new DateTime(1949, 6, 8),
                        Price = 19.84f
                    },
                    new()
                    {
                        Name = "The Hitchhiker's Guide to the Galaxy",
                        Type = BookType.ScienceFiction,
                        PublishDate = new DateTime(1995, 9, 27),
                        Price = 42.0f
                    }
                };
                
                await _repository.InsertManyAsync(books, true);
            }
        }
    }
}