using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ACADEMICO.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        [Required (ErrorMessage ="Campo Requerido")]
        [StringLength(50,MinimumLength =5,ErrorMessage ="El nombre debe de tener de 3 a 50 Caracteres")]
        public string Nombre { get; set; }
        [StringLength(255, ErrorMessage = "La descripción no debe de exceder los 255 caracteres")]
        public string Descripcion { get; set; }
        public Boolean Estado { get; set; }

    }
}
