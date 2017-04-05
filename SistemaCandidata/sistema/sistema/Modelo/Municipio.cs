using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistema.Modelo
{
    [Table("Municipios")]
    public  class Municipio
    {
        [Key]
        public int pkMunicipio { get; set; }

        [Required(ErrorMessage = "Se requiere el Nombre")]
        [StringLength(150)]
        public String sNombreMunicipio { get; set; }

        [Required(ErrorMessage = "Se requiere descripcion")]
        [StringLength(150)]
        public String sDescripcion { get; set; }

        public String sLogotipo { get; set; }

        public Boolean bStatus { get; set; }

        //public ICollection<Candidata> Candidatas { get; set; }

        public Municipio()
        {
            this.bStatus = true;
        }
    }
}
