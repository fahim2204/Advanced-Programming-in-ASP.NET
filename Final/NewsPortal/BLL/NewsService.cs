using AutoMapper;
using BOL;
using BOL.Dto;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NewsService
    {
        public static IEnumerable<NewsDto> GetAllNews()
        {
            return DataAccessFactory.NewsDataAccess().Get().Select(Mapper.Map<News, NewsDto>);
        }
        public static IEnumerable<NewsDto> GetAllNewsByCategory(string cat)
        {
            return DataAccessFactory.NewsDataAccess().Get().Select(Mapper.Map<News, NewsDto>).Where(n => n.Category == cat);
        }
        public static IEnumerable<NewsDto> GetAllNewsByDate(DateTime date)
        {
            return DataAccessFactory.NewsDataAccess().Get().Select(Mapper.Map<News, NewsDto>).Where(n => n.CreatedAt == date);
        }
        public static IEnumerable<NewsDto> GetAllNewsByCategoryByDate(string cat, DateTime date)
        {
            return DataAccessFactory.NewsDataAccess().Get().Select(Mapper.Map<News, NewsDto>).Where(n => n.CreatedAt == date && n.Category == cat);
        }

        public static NewsDto GetNewsById(int id)
        {

            return Mapper.Map<News, NewsDto>(DataAccessFactory.NewsDataAccess().Get(id));
          
        }
        public static bool AddNews(NewsDto News)
        {
            return DataAccessFactory.NewsDataAccess().Add(Mapper.Map<NewsDto, News>(News));
        }
        public static bool DeleteNewsById(int id)
        {
            return DataAccessFactory.NewsDataAccess().Delete(id);
        }
        public static bool EditNews(int id, NewsDto News)
        {
            return DataAccessFactory.NewsDataAccess().Edit(id, Mapper.Map<NewsDto, News>(News));
        }
    }
}
