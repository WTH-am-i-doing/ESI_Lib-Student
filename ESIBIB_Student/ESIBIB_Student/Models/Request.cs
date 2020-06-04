using System;
using System.Collections.Generic;
using System.Text;

namespace ESIBIB_Student.Models
{
    class Request
    {
        public string UserEmail { get; set; }
        public string BookTitle { get; set; }
        public string BookISBN { get; set; }
        public DateTime dateTime { get; set; }
        public bool isAccepted { get; set; }
    }
}
