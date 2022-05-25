using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }

        public Decimal Rate { get; set; }
        //TODO 
        //public virtual List<Picture> Images { get; set; }
        //public virtual List<Comments> Comments {get;set;}

    }
}
