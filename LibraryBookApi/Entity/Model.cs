using LibraryBookApi.Entity.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBookApi.Entity
{
    public class Model:DbContext
    {
        public DbSet<InquiryClass> Inquiries { get; set; }
        public Model(DbContextOptions<Model> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
