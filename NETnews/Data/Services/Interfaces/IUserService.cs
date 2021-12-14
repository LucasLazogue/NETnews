using NETnews.Models;
using System.Collections.Generic;

namespace NETnews.Data.Services.Interfaces {
    public interface IUserService {
        public List<User> getUsers();
        public void addUser(User user);
        public void writeComment(string idUser, News news, string comment);
        public User getUserById(string idUser);
        public bool usernameExists(string username);
        public List<Comment> getUserComments(string idUser);

    }
}
