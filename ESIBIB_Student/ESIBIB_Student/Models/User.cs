using System;
using System.Collections.Generic;
using System.Text;

namespace ESIBIB_Student.Models
{
    class User
    {
        public string email { get; set; }
        public string password { get; set; }
        public List<Request> requestHistory { get; set; }
    }
}
