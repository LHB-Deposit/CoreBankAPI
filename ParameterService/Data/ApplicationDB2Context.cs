using Microsoft.EntityFrameworkCore;
using ParameterAPIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParameterAPIService.Data
{
    public class ApplicationDB2Context : DbContext
    {
        public ApplicationDB2Context(DbContextOptions options) : base(options) { }

        public DbSet<BTPARB> BTPARBs { get; set; }
    }
}
