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
        public User getUserById(int idUser) {
            string query = "SELECT * FROM PERSONS p WHERE p.discriminator = 'User' AND p.id = " + idUser;
            var dataFromDB = _context.Persons.FromSqlRaw(query, "id").ToList();
            if (dataFromDB.Any())
                return (User)dataFromDB.First();
            else
                return null;
        }

        public bool usernameExists(string username) {
            string query = "SELECT * FROM PERSONS p WHERE p.discriminator = 'User' AND p.username = '" + username + "'";
            var dataFromDB = _context.Persons.FromSqlRaw(query, "id").ToList();
            if (dataFromDB.Any())
                return true;
            return false;
        }

        public void addUser(User user) {
            if (!usernameExists(user.username)) { 
                _context.Persons.Add(user);
                _context.SaveChanges();
            }
            else
                throw new UserExistsException(user.username + " already exists");
        }



        public void writeComment(int idUser, News news, string comment) {
            if (getUserById(idUser) != null) {
                if (comment.Length != 0) {
                    Comment cmt = new Comment() {
                        userId = idUser,
                        text = comment,
                        idNews = news.Id
                    };
                    _context.NewsComments.Add(cmt);
                    _context.SaveChanges();
                }
                else {
                    throw new EmptyCommentException("comment has to have at least one character");
                }
                
            }
            else
                throw new UserNotExistsException("Users with id " + idUser + " not exists");
        }
    }
}
