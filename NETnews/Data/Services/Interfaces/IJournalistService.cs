using NETnews.Models;
using System.Collections.Generic;

namespace NETnews.Data.Services.Interfaces {
    public interface IJournalistService {
        public List<Journalist> getJournalists();
        public List<News> getNewsBySource(string source);
        public List<News> getNewsByJournalist(int id);
    }
}
