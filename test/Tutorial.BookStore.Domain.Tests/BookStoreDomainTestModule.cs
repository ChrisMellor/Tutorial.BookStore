using Tutorial.BookStore.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Tutorial.BookStore;

[DependsOn(
    typeof(BookStoreEntityFrameworkCoreTestModule)
    )]
public class BookStoreDomainTestModule : AbpModule
{

}
