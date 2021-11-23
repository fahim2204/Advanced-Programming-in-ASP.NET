using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static NewsDbContext db;
        static DataAccessFactory()
        {
            db = new NewsDbContext();
        }
        public static IRepository<User,int> UserDataAccess()
        {
            return new UserRepo(db);
        }
        public static IRepository<News, int> NewsDataAccess()
        {
            return new NewsRepo(db);
        }
        public static IRepository<Comment, int> CommentDataAccess()
        {
            return new CommentRepo(db);
        }
    }
}
