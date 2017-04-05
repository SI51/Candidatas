using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistema.Modelo
{
    [Table("Usuarios")]
    public class usuario
    {
        [Key]
        public int pkUsuario { get; set; }

        [Required(ErrorMessage = "Se requiere nombre")]
        [StringLength(150)]
        public String sNombreCompleto { get; set; }

        [Required(ErrorMessage = "Se requiere cuenta")]
        [StringLength(150)]
        public String Cuenta { get; set; }

        [Required(ErrorMessage = "Se requiere contraseña")]
        [StringLength(150)]
        public String sContrasena { get; set; }

        public Boolean bStatus { get; set; }

        public virtual Rol Roles { get; set; }

        public ICollection<Candidata> Candidatas { get; set; }


    }
}
