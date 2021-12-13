namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblUsuarios
    {
        [Key]
        public int IdUsuario { get; set; }

        public int? IdSql { get; set; }

        [StringLength(50)]
        public string ULogin { get; set; }

        [StringLength(256)]
        public string UNombre { get; set; }

        [StringLength(256)]
        public string Correro { get; set; }

        public int? IdRol { get; set; }

        public bool? Activo { get; set; }

        public bool Admin { get; set; }
    }
}
