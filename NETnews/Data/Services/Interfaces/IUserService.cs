using NETnews.Models;

namespace NETnews.Data.Services.Interfaces {
    public interface IUserService {
        public void addUser(User user);
        public void writeComment(int idUser, News news, string comment);
        public User getUserById(int idUser);
        public bool usernameExists(string username);

    }
}
