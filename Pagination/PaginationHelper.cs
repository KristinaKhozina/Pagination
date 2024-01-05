
namespace Pagination
{
    public static class PaginationHelper
    {
        /// <summary>
        /// Creates the list of page numbers to display in pagination.
        /// </summary>
        /// <param name="current">Current page number. </param>
        /// <param name="total">Total number of pages.</param>
        /// <param name="range">Number of pages displayed in sequence.</param>
        /// <returns>
        /// A list of page numbers to display. The list may contain a '0' marker to indicate truncation.
        /// </returns>
        public static IEnumerable<int> CreatePageNumberList(int current, int total, int range)
        {
            range = Math.Min(range, total) - 1;
            int first = Math.Max(current - range / 2, 1);
            int last = first + range;

            if (last > total)
            {
                first = total - range;
                last = total;
            }

            var pages = new List<int>();

            if (first > 1)
            {
                pages.Add(1);
                pages.Add(0);
            }

            for (int i = first; i <= last; i++)
            {
                pages.Add(i);
            }

            if (last < total)
            {
                pages.Add(0);
                pages.Add(total);
            }

            return pages;
        }
    }
}
