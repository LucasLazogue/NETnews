using Microsoft.EntityFrameworkCore;
using NETnews.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NETnews.Data.Services {
    public class NewsService : INewsService {

        public readonly AppDbContext _context;

        public NewsService(AppDbContext context) {
            _context = context;
        }

        public IEnumerable<News> getAll() {
            return _context.News.Include(n => n.journalist).ToList();
        }

        public Journalist getJournalist(string _name) {
            string query = "SELECT * FROM JOURNALISTS p WHERE p.name = '" + _name + "'";
            var dataFromDB = _context.Journalists.FromSqlRaw(query, "id").ToList();
            //return _context.Persons.First(c => c.id == dataFromDB.First());
            if (!dataFromDB.Any()) {
                Journalist journalist = new Journalist() {
                    name = _name,
                };
                _context.Journalists.Add(journalist);
                _context.SaveChanges();
                return journalist;
            }
            return (Journalist)dataFromDB.First();

        }

        public void loadNews() {
            if (getAll().Count() <= 10) {
                var client = new RestClient("http://api.mediastack.com");
                var request = new RestRequest("v1/news");
                request.AddParameter("access_key", "ffa7e8b20be60473dded84d522c48738");
                request.AddParameter("languages", "en");
                var response = client.Get(request);
                var content = response.Content; // Raw content as string
                dynamic json = Newtonsoft.Json.Linq.JObject.Parse(response.Content);

                foreach (var item in json.data) {
                    Journalist journalist;
                    if (item.author == null)
                        journalist = getJournalist("John Doe");
                    else {
                        //string nombre = item.author.ToString()();
                        journalist = getJournalist(item.author.ToString());
                    }
                    string _img;
                    if (item.img == null)
                        _img = "https://www.spearsandcorealestate.com/wp-content/themes/spears/images/no-image.png";
                    else
                        _img = item.img.ToString();


                    News news = new News() {
                        title = item.title.ToString(),
                        img = _img,
                        description = item.description.ToString(),
                        url = item.url.ToString(),
                        source = item.source.ToString(),
                        date = Convert.ToDateTime(item.published_at.ToString()),
                        //date = item.published_at.ToString(),
                        //date = DateTime.Parse(item.published_at),
                        journalistId = journalist.id,
                    };

                    _context.News.Add(news);

                }
                _context.SaveChanges();
            }
        }

        public void deleteNews(int id) {
            throw new System.NotImplementedException();
        }
        public News getNewsById(int newsId) {
            string query = "SELECT * FROM NEWS n WHERE n.id = " + newsId;
            var dataFromDB = _context.News.FromSqlRaw(query, "id").Include(n => n.journalist).ToList();
            if (dataFromDB.Any()) 
                return dataFromDB.First();
            else
                throw new NewsNotExistsException("News with Id " + newsId + " does not exists");
        }
    }
}