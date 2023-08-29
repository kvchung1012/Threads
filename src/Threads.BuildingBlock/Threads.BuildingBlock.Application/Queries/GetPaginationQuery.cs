namespace Threads.BuildingBlock.Application.Queries
{
    public class GetPaginationQuery
    {
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        public string? SortedFieldName { get; set; }
        public SortedDirection? SortedDirection { get; set; }

        public int? GetSkip() => (PageIndex, PageSize) switch
        {
            ({ } pageIndex, { } pageSize) => (pageIndex - 1) * pageSize,
            _ => null
        };

        public int? GetTake() => PageSize;
    }
}
