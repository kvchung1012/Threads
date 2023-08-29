namespace Threads.BuildingBlock.Application.Abstractions.Authentication
{
    public interface IUserManager
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
