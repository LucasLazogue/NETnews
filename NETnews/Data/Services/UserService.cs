using Microsoft.EntityFrameworkCore;
using NETnews.Data.Services.Interfaces;
using NETnews.Models;
using System.Collections.Generic;
using System.Linq;

namespace NETnews.Data.Services {
    public class UserService : IUserService {

        public readonly AppDbContext _context;

        public UserService(AppDbContext context) {
            _context = context;
        }

        public List<User> getUsers() {
            string query = "SELECT * FROM ASPNETUSERS";
            var dataFromDB = _context.Users.FromSqlRaw(query, "id").ToList();
            return dataFromDB;
        }

        public User getUserById(string idUser) {
            string query = "SELECT * FROM ASPNETUSERS u WHERE u.id = '" + idUser + "'";
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

        public List<Comment> getUserComments(string idUser) {
            string query = "SELECT nc.id, nc.userId, nc.text, nc.idNews FROM ASPNETUSERS u, NEWSCOMMENTS nc WHERE u.id = '" + idUser + "'" + " AND nc.USERID = u.id";
            var dataFromDB = _context.NewsComments.FromSqlRaw(query, "id, userId, text, idNews").ToList();
            return dataFromDB;
        }
    }
}
