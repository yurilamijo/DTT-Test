using System;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

namespace DTT_Test.Models
{
    public class DTTContext : DbContext
    {
        public DTTContext()
        {
        }

        public DTTContext( DbContextOptions<DTTContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
