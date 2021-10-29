using LabTask_Product_CRUD_Operation.Models.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LabTask_Product_CRUD_Operation.Models
{
    public class Database
    {
        SqlConnection conn;
        public Products Products { get; set; }
        public Database()
        {
            string conString = @"Server=FAHIM-PC\SQLEXPRESS; Database=asp; Integrated Security = true";
            conn = new SqlConnection(conString);
            Products = new Products(conn);
        }
        //Database ts = new Database();

    }
}