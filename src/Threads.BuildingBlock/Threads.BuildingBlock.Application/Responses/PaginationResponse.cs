namespace Threads.BuildingBlock.Application.Responses
{
    public sealed class PaginationResponse<T>
    {
        public List<T> Items { get; set; }
        public long TotalRecord { get; set; }

        public PaginationResponse(List<T> items, long totalRecord)
            => (Items, TotalRecord) = (items, totalRecord);
    }
}
