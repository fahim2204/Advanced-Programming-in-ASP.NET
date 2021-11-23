using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string CText { get; set; }
        public int Fk_User_Id { get; set; }
        public int Fk_News_Id { get; set; }
    }
}
