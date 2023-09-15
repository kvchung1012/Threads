namespace Threads.BuildingBlock.Application.Queries
{
    public class FilterModel
    {
        public string Field { get; set; } = default!;
        public Comparison Comparison { get; set; } = default!;
        public string? Value { get; set; }
    }
}
