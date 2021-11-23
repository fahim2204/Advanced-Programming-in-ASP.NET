using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class NewsRepo : IRepository<News, int>
    {
        readonly NewsDbContext db;

        public NewsRepo(NewsDbContext db)
        {
            this.db = db;
        }

        public bool Add(News news)
        {
            if (news != null)
            {
                db.News.Add(news);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var _news = db.News.FirstOrDefault(u => u.Id == id);
            if (_news != null)
            {
                db.News.Remove(_news);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Edit(int id, News news)
        {
            var _news = db.News.FirstOrDefault(u => u.Id == id);
            if (_news != null)
            {
                db.Entry(_news).CurrentValues.SetValues(news);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public News Get(int id) => db.News.FirstOrDefault(u => u.Id == id);

        public IEnumerable<News> Get() => db.News;
    }
}
