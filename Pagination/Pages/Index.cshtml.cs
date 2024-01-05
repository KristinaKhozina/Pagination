using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pagination.Pages
{
    public class IndexModel : PageModel
    {
        public int PageIndex { get; set; } = 1;
        public int Count { get; set; } = 20;
        public int Range { get; set; } = 3;
        public IEnumerable<int> PageNumbers { get; set; } = Enumerable.Empty<int>();

        public int NextPageIndex => PageIndex < Count ? PageIndex + 1 : PageIndex;
        public int PreviousPageIndex => PageIndex > 1 ? PageIndex - 1 : PageIndex;

        public void OnGet(int pageIndex = 1, int range = 3)
        {
            PageIndex = pageIndex;
            Range = range;
            PageNumbers = PaginationHelper
                .CreatePageNumberList(PageIndex, Count, Range);
        }
    }
}
