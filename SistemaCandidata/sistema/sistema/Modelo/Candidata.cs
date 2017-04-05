using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistema.Modelo
{
    [Table("Candidatas")]
    public class Candidata
    {
        [Key]
        public int pkCandidata { get; set; }

        [Required(ErrorMessage = "Se requiere el Nombre")]
        [StringLength(150)]
        public String sNombreCompleto { get; set; }

        [Required(ErrorMessage = "Se requiere fecha de nacimiento")]
        public DateTime dFechaNacimiento { get; set; }

        [Required(ErrorMessage = "Se requiere descripcion")]
        [StringLength(150)]
        public String sDescripcion { get; set; }

        [Required(ErrorMessage = "Se requiere correo electronico")]
        [StringLength(150)]
        public String sCorreoElectronico { get; set; }

        [Required(ErrorMessage = "Se requiere curp")]
        [StringLength(150)]
        public String sCurp { get; set; }

        [Required(ErrorMessage = "Se requiere nivel estudios")]
        [StringLength(150)]
        public String sNivelEstudios { get; set; }

        [Required(ErrorMessage = "Se requiere año de convocatoria")]
        public DateTime dAnioConvocatoria { get; set; }

        [Required(ErrorMessage = "Se requiere foto de candidata")]        
        public String sFotoCandidata { get; set; }
        
        public int iRanking { get; set; }
        
        public Boolean bStatus { get; set; }

        public virtual Municipio Municipios { get; set; }
        public virtual usuario Usuarios { get; set; }

        public Candidata()
        {
            this.bStatus = true;
        }

    }
}
