namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDispositivo")]
    public partial class tblDispositivo
    {
        [Key]
        public int ID_dispo { get; set; }

        [Required]
        [StringLength(75)]
        public string Dispositivo { get; set; }
    }
}
