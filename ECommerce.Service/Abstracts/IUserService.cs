using ECommerce.Models.Dtos.Users.Requests;
using ECommerce.Models.Entities;

namespace ECommerce.Service.Abstracts;

public interface IUserService
{
  Task<User> GetByUsernameAsync(string username);

  Task<User> GetByEmailAsync(string email);

  Task<User> RegisterAsync(RegisterRequest request);

  Task<User> LoginAsync(LoginRequest request);

  Task<User> ChangePasswordAsync(string id, ChangePasswordRequest request);

  Task<User> UpdateAsync(string id, UserUpdateRequest request);

  Task<string> DeleteAsync(string id);
}