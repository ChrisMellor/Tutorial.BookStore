using Tutorial.BookStore.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Tutorial.BookStore.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class BookStorePageModel : AbpPageModel
{
    protected BookStorePageModel()
    {
        LocalizationResourceType = typeof(BookStoreResource);
    }
}
