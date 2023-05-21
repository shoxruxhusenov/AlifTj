using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Service.ViewModels
{
    public class ProductViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }=string.Empty;

        public double Price { get; set; }

        public long Percent { get; set; }

        public string TypeName { get; set; } = string.Empty;


    }
}
