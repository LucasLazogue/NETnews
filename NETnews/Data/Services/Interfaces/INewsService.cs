using NETnews.Models;
using System.Collections.Generic;

namespace NETnews.Data.Services {
    public interface INewsService {
        public IEnumerable<News> getAll();
        public Journalist getJournalist(string name);
        public void loadNews();
        public void deleteNews(int id);
        public News getNewsById(int newsId);
    }
}
