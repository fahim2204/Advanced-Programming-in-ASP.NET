using LabTask_Product_CRUD_Operation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LabTask_Product_CRUD_Operation.Models.Repository
{
    public class Users
    {
        SqlConnection conn;
        public Users(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void Create(User p)
        {
            conn.Open();
            string query = String.Format("insert into [dbo].[Users] ([Username],[Password],[Type]) values ('{0}','{1}','{2}')", p.Username, p.Password, p.Type);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<User> Get()
        {
            conn.Open();
            string query = "select * from Users";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                User p = new User()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Username = reader.GetString(reader.GetOrdinal("Username")),
                    Password = reader.GetString(reader.GetOrdinal("Password")),
                    Type = reader.GetString(reader.GetOrdinal("Type"))
                };
                users.Add(p);
            }

            conn.Close();
            return users;
        }

        internal string Authenticate(User p)
        {
            conn.Open();
            string query = String.Format("select * from Users where [Username]='{0}' and [Password]='{1}'",p.Username,p.Password); 
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> users = new List<User>();
            if(reader.Read())
            {
                var temp = reader.GetString(reader.GetOrdinal("Type"));
                conn.Close();
                return temp;
            }
            conn.Close();
            return null;
        }
    }
}