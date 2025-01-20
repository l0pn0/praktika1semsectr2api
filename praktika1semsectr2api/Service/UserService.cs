using Microsoft.EntityFrameworkCore;
using praktika1semsectr2api.DataBaseContext;
using praktika1semsectr2api.Interface;
using praktika1semsectr2api.Model;

namespace praktika1semsectr2api.Service
{
    public class UserService : IUsercs
    {
        private readonly ContextDb _context;

        public UserService(ContextDb context)
        {
            _context = context;
        }

        public async Task<List<RegisterModel>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<RegisterModel> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> CreateUserAsync(RegisterModel registerModel)
        {
            if (await _context.Users.AnyAsync(u => u.Email == registerModel.Email))
                return false;

            _context.Users.Add(registerModel);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateUserAsync(RegisterModel registerModel)
        {
            var existingUser = await _context.Users.FindAsync(registerModel.id_User);
            if (existingUser == null)
                return false;

            existingUser.Name = registerModel.Name;
            existingUser.Email = registerModel.Email;
            existingUser.Discription = registerModel.Discription;
            existingUser.Role = registerModel.Role;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<RegisterModel> AuthenticationAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            return user;
        }
    }
}
