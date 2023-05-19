using AlifTj.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Domain.Entities.Users
{
    public class User:Auditable
    {
        public string UserName { get; set; }=String.Empty;

        public string PhoneNumber { get; set; }=String.Empty;

    }
}
