using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Service.ViewModels
{
    public class UserViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }=string.Empty;

        public string PhoneNumber { get; set; }=string.Empty;
    }
}
