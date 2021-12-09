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
        public User getUserById(string idUser) {
            string query = "SELECT * FROM ASPNETUSERS u WHERE u.userId = " + idUser;
            var dataFromDB = _context.Users.FromSqlRaw(query, "id").ToList();
            if (dataFromDB.Any())
                return dataFromDB.First();
            else
                return null;
        }

        public bool usernameExists(string username) {
            string query = "SELECT * FROM ASPNETUSERS p WHERE p.username = '" + username + "'";
            var dataFromDB = _context.Users.FromSqlRaw(query, "id").ToList();
            if (dataFromDB.Any())
                return true;
            return false;
        }

        public void addUser(User user) {
            if (!usernameExists(user.UserName)) { 
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            else
                throw new UserExistsException(user.UserName + " already exists");
        }



        public void writeComment(string idUser, News news, string comment) {
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
