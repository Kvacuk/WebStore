using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class WebStoreContext : DbContext
    {
        DbSet<Product> Products { get; set; }

        public WebStoreContext(DbContextOptions options): base(options)
        {

        }
    }
}
