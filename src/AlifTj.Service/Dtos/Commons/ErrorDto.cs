using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Service.Dtos.Commons
{
    public class ErrorDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
