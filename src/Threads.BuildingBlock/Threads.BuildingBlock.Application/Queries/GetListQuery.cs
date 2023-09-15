namespace Threads.BuildingBlock.Application.Queries
{
    public class GetListQuery
    {
        public string? SearchKey { get; set; }
        public List<SortedByModel>? Sorts { get; set; }
        public List<FilterModel>? Filters { get; set; }
    }
}
