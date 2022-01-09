﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Data
{
    public class WebContext : DbContext
    {
        public WebContext (DbContextOptions<WebContext> options)
            : base(options)
        {
        }

        public DbSet<Web.Models.Client> Client { get; set; }

        public DbSet<Web.Models.Antrenor> Antrenor { get; set; }

        public DbSet<Web.Models.Categorie> Categorie { get; set; }
    }
}
