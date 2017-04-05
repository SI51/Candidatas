using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistema.Modelo
{
    [Table("Permisos")]
    public class Permiso
    {
        [Key]
        public int pkPermiso { get; set; }

        [Required(ErrorMessage = "Se requiere el Nombre")]
        [StringLength(150)]
        public String sNombre { get; set; }

        [Required(ErrorMessage = "Se requiere descripcion")]
        [StringLength(150)]
        public String sDescripcion { get; set; }

        public ICollection<PermisoNegadoPorRol> PermisosNegadosPorRoles { get; set; }
    }
}
