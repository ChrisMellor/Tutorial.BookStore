using Volo.Abp.Application.Dtos;

namespace Tutorial.BookStore.Authors
{
    public class GetAuthorListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
