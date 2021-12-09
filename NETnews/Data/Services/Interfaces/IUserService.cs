using NETnews.Models;

namespace NETnews.Data.Services.Interfaces {
    public interface IUserService {
        public void addUser(User user);
        public void writeComment(string idUser, News news, string comment);
        public User getUserById(string idUser);
        public bool usernameExists(string username);

    }
}
