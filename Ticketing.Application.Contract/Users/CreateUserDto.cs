namespace Ticketing.Application.Contract.Users
{
    public class CreateUserDto   
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
