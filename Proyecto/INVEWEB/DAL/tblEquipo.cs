namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("tblEquipo")]
    public partial class tblEquipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEquipo()
        {
            tblReunion = new HashSet<tblReunion>();
        }

        [Key]
        public int ID_Equipo { get; set; }

        [StringLength(100)]
        public string NOM_EQUIPO { get; set; }

        [StringLength(50)]
        public string CODIGO_ACTIVO { get; set; }

        [Required]
        [StringLength(1)]
        public string ACTIVO { get; set; }

        public int? CANTIDAD { get; set; }

        [StringLength(100)]
        public string DISPOSITIVO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblReunion> tblReunion { get; set; }


        public List<tblEquipo> Listar()
        {
            try
            {
                using (var cn = new DBEquipo())
                {
                    return cn.tblEquipo.ToList();
                    //return cn.Database.SqlQuery<Curso>("Usp_ListarCurso").ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<tblEquipo> ListadoCmbEquipo()
        {
            //var equipo = new List<tblEquipo>();

            try
            {
                using (var cn = new DBEquipo())
                {

                    //equipo = cn.Database.SqlQuery<tblEquipo>("EXEC Usp_Sel_CmbEquipoPrestado @ID_Equipo", new SqlParameter("ID_Equipo", ID_Equipo)).ToList();
                    return cn.tblEquipo.ToList();
                    //return cn.Database.SqlQuery<tblPersonas>("EXEC Usp_Sel_CmbPersonas @IDPersona").ToList();
                    //return cn.Database.SqlQuery<tblPersonas>("Usp_Sel_CmbPersonas @IDPersona)", new SqlParameter("IDPersona", IDPersona)).ToList();

                }
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
            //return equipo;


        }


        public tblEquipo Obtener(int ID)
        {
            var Oequipo = new tblEquipo();

            try
            {
                using (var cn = new DBEquipo())
                {
                    //Oequipo = cn.tblEquipo.Where(x => x.ID_Equipo == ID).SingleOrDefault();
                    Oequipo = cn.tblEquipo.Where(x => x.ID_Equipo == ID).Single();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Oequipo;

        }

        public JsonModel Guardar()
        {

            var rm = new JsonModel();

            try
            {
                using (var cn = new DBEquipo())
                {
                    if (this.ID_Equipo > 0)
                    {
                        cn.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        cn.Entry(this).State = EntityState.Added;
                    }

                    rm.SetResponse(true);
                    cn.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return rm;
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


        public tblEquipo ObtenerEquipo(int id)
        {
            var Oequipo = new tblEquipo();

            try
            {
                using (var cn = new DBEquipo())
                {
                    Oequipo = cn.tblEquipo.Include("tblReunion").Include("tblReunion.tblEquipo").Where(x => x.ID_Equipo == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Oequipo;
        }
    }

}
