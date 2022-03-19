using System.Threading.Tasks;

namespace Tutorial.BookStore.Data;

public interface IBookStoreDbSchemaMigrator
{
    Task MigrateAsync();
}
