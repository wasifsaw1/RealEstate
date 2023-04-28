using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model.Helper
{
    public class HttpException :Exception
    {
        public HttpStatusCode Status { get; set; }
        public HttpException(HttpStatusCode code,string message) : base(message)
        {
            Status = code;
        }
    }
}
