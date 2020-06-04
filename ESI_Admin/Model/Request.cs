using System;
using System.Collections.Generic;
using System.Text;

namespace ESI_Admin
{
    class Request
    {
        public string ReqKey { get; set; }
        public string UserEmail { get; set; }
        public string BookTitle { get; set; }
        public string BookISBN { get; set; }
        public DateTime dateTime { get; set; }
        public bool isAccepted { get; set; }
    }
}
