namespace Threads.IdentityService.Domain.Model
{
    public class PaginationResult<TResult>
    {
        public PaginationResult(IEnumerable<TResult> items, long totalRecords)
        {
            TotalRecords = totalRecords;
            Items = items;
        }

        public IEnumerable<TResult>? Items { get; set; }
        public long TotalRecords { get; set; }
    }
}
