using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BOL;
using BOL.Dto;

namespace API.App_Start
{
    public class MappingProfile: AutoMapper.Profile
    {
        public MappingProfile()
        {

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<News, NewsDto>();
            CreateMap<NewsDto, News>();
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();


        }
    }
}