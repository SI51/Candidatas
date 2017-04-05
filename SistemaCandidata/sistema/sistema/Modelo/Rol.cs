using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistema.Modelo
{
    [Table("Roles")]
    public class Rol
    {
        [Key]
        public int pkRol { get; set; }

        [Required(ErrorMessage = "Se requiere el Nombre")]
        [StringLength(150)]
        public String sNombreRol { get; set; }

        [Required(ErrorMessage = "Se requiere descripcion")]
        [StringLength(150)]
        public String sDescripcion { get; set; }

        public ICollection<PermisoNegadoPorRol> PermisosNegadosPorRoles { get; set; }
        public ICollection<usuario> Usuarios { get; set; }
    }
}
