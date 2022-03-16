using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiClients.Models;

namespace ApiClients.Data
{
    public class ApiClientsContext : DbContext
    {
        public ApiClientsContext (DbContextOptions<ApiClientsContext> options)
            : base(options)
        {
        }

        public DbSet<ApiClients.Models.customers> customers { get; set; }

        public DbSet<ApiClients.Models.document_type> document_type { get; set; }

        public DbSet<ApiClients.Models.providers> providers { get; set; }
    }
}
