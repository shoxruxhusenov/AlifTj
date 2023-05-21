using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Service.ViewModels
{
    public class OrderViewModel
    {
        public long Id { get; set; }

        public string ProductName { get; set; }=string.Empty;

        public string PhoneNumber { get ; set; }=string.Empty;

        public double ProductPrice { get; set; }

        public long Month { get; set;}

    }
}
