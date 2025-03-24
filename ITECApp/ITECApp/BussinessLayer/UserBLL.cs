using ITECApp.DataAccess;
using ITECApp.Entities;
using ITECApp.Utilities;
using System.ComponentModel.DataAnnotations;

namespace ITECApp.BusinessLayer
{
    public class UserBLL
    {
        private readonly UserDAL _userDAL = new UserDAL();

        public Response<User> AuthenticateUser(string credential, string password)
        {
            try
            {
                var response = _userDAL.GetUserByCredential(credential);
                if (!response.IsSuccess || response.Data == null)
                    return response;

                var user = response.Data;
                if (user == null)
                    return new Response<User> { IsSuccess = false, Message = "User data is invalid" };

                bool validPassword = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
                if (validPassword)
                {
                    UserSession.CurrentUser = user; // Set the current user session
                    return new Response<User> { IsSuccess = true, Data = user };
                }
                else
                {
                    return new Response<User> { IsSuccess = false, Message = "Invalid password" };
                }
            }
            catch (Exception ex)
            {
                return new Response<User>
                {
                    IsSuccess = false,
                    Message = $"Authentication Error: {ex.Message}"
                };
            }
        }

        public Response<User> ValidateAndRegister(User user, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
                return new Response<User> { IsSuccess = false, Message = "Username required" };

            if (!new EmailAddressAttribute().IsValid(user.Email))
                return new Response<User> { IsSuccess = false, Message = "Invalid email format" };

            if (user.PasswordHash != confirmPassword)
                return new Response<User> { IsSuccess = false, Message = "Passwords do not match" };

            if (user.PasswordHash.Length < 8)
                return new Response<User> { IsSuccess = false, Message = "Password must be 8+ characters" };

            if (user.RoleId <= 0)
                return new Response<User> { IsSuccess = false, Message = "Invalid role selection" };

            var existingCheck = _userDAL.GetUserByCredential(user.Username);
            if (existingCheck.IsSuccess && existingCheck.Data != null)
                return new Response<User> { IsSuccess = false, Message = "Username already exists" };

            existingCheck = _userDAL.GetUserByCredential(user.Email);
            if (existingCheck.IsSuccess && existingCheck.Data != null)
                return new Response<User> { IsSuccess = false, Message = "Email already registered" };

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            return _userDAL.CreateUser(user);
        }
    }
}

