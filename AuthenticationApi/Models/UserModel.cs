namespace AuthenticationApi.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public UserRole Role { get; set; }
    }
}