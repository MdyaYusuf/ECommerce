using ECommerce.Models.Dtos.Users.Requests;

namespace ECommerce.Service.Abstracts;

public interface IRoleService
{
  Task<string> AddRoleToUser(AddRoleToUserRequest request);

  Task<List<string>> GetAllRolesByUserId(string userId);

  Task<string> AddRoleAsync(string name);
}