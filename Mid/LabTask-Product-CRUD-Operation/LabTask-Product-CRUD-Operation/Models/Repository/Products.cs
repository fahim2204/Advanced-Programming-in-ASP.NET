using LabTask_Product_CRUD_Operation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LabTask_Product_CRUD_Operation.Models.Repository
{
    public class Products
    {
        SqlConnection conn;
        public Products(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void Create(Product p)
        {
            conn.Open();
            string query = String.Format("insert into [dbo].[Products] ([name],[qty],[price],[desc]) values ('{0}','{1}','{2}','{3}')", p.Name, p.Qty, p.Price, p.Desc);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<Product> Get()
        {
            conn.Open();
            string query = "select * from Products";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product p = new Product()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader.GetString(reader.GetOrdinal("name")),
                    Qty = Convert.ToInt32(reader["qty"]),
                    Price = Convert.ToDouble(reader["qty"]),
                    Desc = reader.GetString(reader.GetOrdinal("desc"))
                };
                products.Add(p);
            }

            conn.Close();
            return products;
        }
        public Product Get(int id)
        {
            conn.Open();
            string query = String.Format("Select * from Products where id={0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Product product = null;

            while (reader.Read())
            {
                product = new Product()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader.GetString(reader.GetOrdinal("name")),
                    Qty = Convert.ToInt32(reader["qty"]),
                    Price = Convert.ToDouble(reader["qty"]),
                    Desc = reader.GetString(reader.GetOrdinal("desc"))

                };

            }
            conn.Close();
            return product;
        }
        public void Update(Product p)
        {
            conn.Open();
            string query = String.Format("UPDATE [dbo].[Products] SET [name]='{0}',[qty]={1},[price]='{2}',[desc]='{3}' WHERE [id]='{4}'", p.Name, p.Qty, p.Price, p.Desc, p.Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Delete(int id)
        {
            conn.Open();
            string query = String.Format("DELETE FROM [dbo].[Products] WHERE [id]='{0}'", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}