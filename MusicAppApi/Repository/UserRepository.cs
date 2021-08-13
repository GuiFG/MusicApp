using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicAppApi.Services;
using MusicAppApi.Model;
using MusicAppApi.Contracts;

namespace MusicAppApi.Repository 
{
    public class UserRepository : IUserRepository 
    {
        private readonly MusicAppContext _context;
        public UserRepository(MusicAppContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            try
            {
                var users = await Task.Run(() => 
                    _context.Users
                    .OrderBy(u => u.Id)
                    .ToList()
                );

                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetById(int id) {
            try
            {
                var user = await _context.Users.FindAsync(id);

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<User> GetByCredentials(string username, string password)
        {
            try
            {
                User user = new User();
                password = GenerateHash(password);
                await Task.Run(() => 
                    {
                            user = _context.Users.Where(u => 
                                u.Username.ToLower() == username.ToLower() &&
                                u.Password == password
                            ).FirstOrDefault();
                    }    
                );

                if (user == null)
                    return null;

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> Add(User user)
        {
            try 
            {
                await _context.AddAsync(user);

                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GenerateHash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}