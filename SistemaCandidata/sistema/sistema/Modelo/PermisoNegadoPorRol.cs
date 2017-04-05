using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistema.Modelo
{
    [Table("PermisosNegadosPorRoles")]
     public class PermisoNegadoPorRol
    {
        [Key]
        public int pkPermisosNegadosPorRoles { get; set; }

        public virtual Rol Roles { get; set; }

        public virtual Permiso Permisos { get; set; }
    }
}
