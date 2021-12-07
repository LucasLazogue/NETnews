using Microsoft.EntityFrameworkCore;
using NETnews.Data.Services.Interfaces;
using NETnews.Models;
using System.Linq;

namespace NETnews.Data.Services {
    public class UserService : IUserService {

        public readonly AppDbContext _context;

        public UserService(AppDbContext context) {
            _context = context;
        }
        public void addUser(User user) {
            string query = "SELECT * FROM PERSONS p WHERE p.discriminator = 'User' AND p.username = '" + user.username + "'";
            var dataFromDB = _context.Persons.FromSqlRaw(query, "id").ToList();
            //return _context.Persons.First(c => c.id == dataFromDB.First());
            if (!dataFromDB.Any()) {
                _context.Persons.Add(user);
                _context.SaveChanges();
            }
            else
                throw new UserExistsException(user.username + " already exists");
        }
    }
}
