using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ling.Data
{
    public class LingDbContext : DbContext
    {
        public LingDbContext(DbContextOptions<LingDbContext> options) : base(options)
        {

        }
    }
}
