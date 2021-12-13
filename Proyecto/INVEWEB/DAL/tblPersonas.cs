namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    public partial class tblPersonas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPersonas()
        {
            tblReunion = new HashSet<tblReunion>();
        }

        [Key]
        public int IDPersona { get; set; }

        [StringLength(100)]
        [DisplayName("Nombre")]

        public string Nombre { get; set; }

        [StringLength(100)]
        [DisplayName("Apellido")]

        public string Apellido { get; set; }

        [StringLength(100)]
        [DisplayName("Cargo")]

        public string Cargo { get; set; }

        [StringLength(100)]
        [DisplayName("Area")]

        public string Area { get; set; }

        [StringLength(1)]
        [DisplayName("Estado")]

        public string ACTIVO { get; set; }

        [Column(TypeName = "date")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha de Prestamo")]

        public DateTime? Fechaprestamo { get; set; }

        [Column(TypeName = "date")]
        //[DataType(DataType.Date)]
        [DisplayName("Fecha de Entrega")]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEntrega { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblReunion> tblReunion { get; set; }


        public List<tblPersonas> Listar()
        {
            try
            {
                using (var cn = new DBEquipo())
                {
                    return cn.tblPersonas.ToList();
                    //return cn.Database.SqlQuery<Curso>("Usp_ListarCurso").ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<tblPersonas> ListadoCmbPersonas()
        {
            var persona = new List<tblPersonas>();

            try
            {
                using (var cn = new DBEquipo())
                {

                    persona = cn.Database.SqlQuery<tblPersonas>("EXEC Usp_Sel_CmbPersonas @IDPersona", new SqlParameter("IDPersona", IDPersona)).ToList();
                    //return cn.tblPersonas.ToList();
                    //return cn.Database.SqlQuery<tblPersonas>("EXEC Usp_Sel_CmbPersonas @IDPersona").ToList();
                    //return cn.Database.SqlQuery<tblPersonas>("Usp_Sel_CmbPersonas @IDPersona)", new SqlParameter("IDPersona", IDPersona)).ToList();

                }
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
            return persona;


        }

        public tblPersonas Obtener(int ID)
        {
            var Opersona = new tblPersonas();

            try
            {
                using (var cn = new DBEquipo())
                {
                    Opersona = cn.tblPersonas.Where(x => x.IDPersona == ID).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Opersona;

        }

        public void Eliminar()
        {

            try
            {
                using (var cn = new DBEquipo())
                {
                    cn.Entry(this).State = EntityState.Deleted;
                    cn.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public JsonModel Guardar()
        {
            var rm = new JsonModel();
            try
            {
                using (var cn = new DBEquipo())
                {
                    if (this.IDPersona > 0)
                    {
                        cn.Entry(this).State = EntityState.Modified;
                        cn.SaveChanges();
                    }
                    else
                    {
                        cn.Entry(this).State = EntityState.Added;
                        cn.SaveChanges();
                    }

                    rm.SetResponse(true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return rm;
        }

    }
}
