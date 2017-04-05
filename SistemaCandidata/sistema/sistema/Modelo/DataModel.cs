using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace sistema.Modelo
{
    public class DataModel : DbContext
    {
        public virtual DbSet<usuario> usuarios { get; set; }
        public virtual DbSet<Candidata> candidatas { get; set; }
        public virtual DbSet<Rol> roles { get; set; }
        public virtual DbSet<Permiso> permisos { get; set; }
        public virtual DbSet<PermisoNegadoPorRol> permisosNegadosPorRoles { get; set; }
        public virtual DbSet<Municipio> municipios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);
        }

        public DataModel() : base("DataModel")
        {

        }
    }
}
