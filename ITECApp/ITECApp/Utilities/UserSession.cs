using ITECApp.Entities;  // Add this line

namespace ITECApp.Utilities
{
    public static class UserSession
    {
        public static User? CurrentUser { get; set; }
    }
}