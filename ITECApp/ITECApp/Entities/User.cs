namespace ITECApp.Entities
{
    public class User
    {
        public User() { } // Required for ORM

        public User(string username, string email, string passwordHash, int roleId)
        {
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            RoleId = roleId;
        }

        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int RoleId { get; set; }
    }
}