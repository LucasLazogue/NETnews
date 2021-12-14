using Microsoft.EntityFrameworkCore;
using NETnews.Data.Services.Interfaces;
using NETnews.Models;
using System.Collections.Generic;
using System.Linq;

namespace NETnews.Data.Services {

    public class JournalistService : IJournalistService {

        public readonly AppDbContext _context;

        public JournalistService(AppDbContext context) {
            _context = context;
        }

        public List<Journalist> getJournalists() {
            string query = "SELECT * FROM JOURNALISTS";
            var dataFromDB = _context.Journalists.FromSqlRaw(query, "id").ToList();
            return dataFromDB;
        }

        public List<News> getNewsBySource(string source) {
            string query = "SELECT * FROM NEWS n WHERE n.SOURCE = '" + source + "'";
            var dataFromDB = _context.News.FromSqlRaw(query, "id").ToList();
            return dataFromDB;
        }

        public List<News> getNewsByJournalist(int id) {
            string query = "SELECT * FROM NEWS n WHERE n.JOURNALISTID = " + id;
            var dataFromDB = _context.News.FromSqlRaw(query, "id").ToList();
            return dataFromDB;
        }
    }
}
