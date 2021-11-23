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
    public class CommentService
    {
        //public static UserDto GetUserById(int id)
        //{
        //    var _User = DataAccessFactory.CommentDataAccess().Get(id);
        //    if (_User != null)
        //    {
        //        return Mapper.Map<User, UserDto>(_User);
        //    }
        //    else
        //    {
        //        return null;

        //    }
        //}

        //public static bool AddComment(UserDto user)
        //{
        //    return DataAccessFactory.CommentDataAccess().Add(Mapper.Map<UserDto, User>(user));
        //}

        //public static bool DeleteUserById(int id)
        //{
        //    return DataAccessFactory.CommentDataAccess().Delete(id);
        //}

        //public static bool EditUser(int id, UserDto user)
        //{
        //    return DataAccessFactory.CommentDataAccess().Edit(id, Mapper.Map<UserDto, User>(user));
        //}
    }
}
