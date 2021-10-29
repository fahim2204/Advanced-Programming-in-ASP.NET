using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabTask_Product_CRUD_Operation.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required][DataType(DataType.Currency)]
        public double Price { get; set; }
        public string Desc { get; set; }













    }
}