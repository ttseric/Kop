using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kop.Core
{
    public class Comment
    {
        public string Detail { get; set; }
        public string From { get; set; }
        public User CommentBy { get; set; }
    }
}
