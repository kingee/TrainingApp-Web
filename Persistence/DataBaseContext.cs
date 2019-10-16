﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Training> Traings{ get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Email> MyProperty { get; set; }
        public DbSet<Runner> Runners { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
    }
}
