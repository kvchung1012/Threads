namespace Threads.BuildingBlock.Application.Errors
{
    public class ErrorDetail
    {
        public string Code { get; set; }
        public IEnumerable<string> Messages { get; set; }

        public ErrorDetail(string code, IEnumerable<string> messages)
        {
            Code = code;
            Messages = messages;
        }
    }
}
