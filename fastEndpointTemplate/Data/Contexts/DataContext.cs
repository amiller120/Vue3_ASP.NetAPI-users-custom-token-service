﻿using fastEndpointTemplate.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace fastEndpointTemplate.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}