﻿using CmsServices.Models;
using Microsoft.EntityFrameworkCore;

namespace CmsServices.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Factura> Facturas { get; set; }
    }
}
