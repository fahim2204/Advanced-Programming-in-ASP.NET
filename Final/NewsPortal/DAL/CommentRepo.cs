using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class CommentRepo : IRepository<Comment, int>
    {
        readonly NewsDbContext db;

        public CommentRepo(NewsDbContext db)
        {
            this.db = db;
        }

        public bool Add(Comment comment)
        {
            if (comment != null)
            {
                db.Comments.Add(comment);
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
            var _news = db.Comments.FirstOrDefault(u => u.Id == id);
            if (_news != null)
            {
                db.Comments.Remove(_news);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Edit(int id, Comment comment)
        {
            var _comment = db.Comments.FirstOrDefault(u => u.Id == id);
            if (_comment != null)
            {
                db.Entry(_comment).CurrentValues.SetValues(comment);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public Comment Get(int id) => db.Comments.FirstOrDefault(u => u.Id == id);

        public IEnumerable<Comment> Get() => db.Comments;
    }
}
