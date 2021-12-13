using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACADEMICO.Models
{
    public class Docente

    {
        public int DocenteID { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "El nombre debe de tener de 3 a 50 Caracteres")]
        public string NombreDocente { get; set; }

        [Column(TypeName = "date")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ?FechaNacimiento { get; set; }

        public int Edad { get; set; }

        public Boolean Estado { get; set; }


    }
}
