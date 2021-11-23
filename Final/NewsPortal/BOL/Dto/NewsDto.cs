using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Dto
{
    public class NewsDto
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Text { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public int Fk_User_Id { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<React> Reacts { get; set; }
    }
}
