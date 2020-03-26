﻿using Microsoft.EntityFrameworkCore;

namespace DOPAAPIService.Data
{
    public class ApplicationSQLContext : DbContext
    {
        public ApplicationSQLContext(DbContextOptions<ApplicationSQLContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);



    }
}
