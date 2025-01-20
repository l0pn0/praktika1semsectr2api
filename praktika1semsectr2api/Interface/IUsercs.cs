using praktika1semsectr2api.Model;

namespace praktika1semsectr2api.Interface
{
    public interface IUsercs
    {
        Task<List<RegisterModel>> GetAllUsersAsync();
        Task<RegisterModel> GetUserByIdAsync(int id);
        Task<bool> CreateUserAsync(RegisterModel registerModel);
        Task<bool> UpdateUserAsync(RegisterModel registerModel);
        Task<bool> DeleteUserAsync(int id);
        Task<RegisterModel> AuthenticationAsync(string email, string password);
    }
}
