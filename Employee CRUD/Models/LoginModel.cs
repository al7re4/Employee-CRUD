namespace Employee_CRUD.Models
{
    public class LoginModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public class AuthenticatedResponse
        {
            public string? Token { get; set; }
        }
    }
}
