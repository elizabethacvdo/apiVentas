using _2019AM606.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2019AM606
{
    public class ventasContext : DbContext
    {

        public ventasContext(DbContextOptions<ventasContext> options) : base(options)
        {

        }

        public DbSet<Departamentos> Departamentos { get; set; }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Productos> Productos{ get; set; }
        public DbSet<Pedidos> Pedidos{ get; set; }

        public DbSet<DetallePedidos> detallePedidos { get; set; }

    }
}
