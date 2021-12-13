namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("tblReunion")]
    public partial class tblReunion
    {
        [Key]
        public int IDReunion { get; set; }

        public int? Persona_Id { get; set; }

        [StringLength(200)]
        [DisplayName("Reunion/Evento")]

        public string NOM_REUNION { get; set; }

        //[Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha Realizada")]

        public DateTime? fecharealizada { get; set; }

        [StringLength(10)]
        [DisplayName("Hora")]

        public string hora { get; set; }

        [StringLength(100)]
        [DisplayName("Concepto Reunion")]

        public string TipoReunion { get; set; }

        public int? Equipo_Id { get; set; }

        public virtual tblEquipo tblEquipo { get; set; }

        public virtual tblPersonas tblPersonas { get; set; }

        public List<tblReunion> Listar()
        {
            try
            {
                using (var cn = new DBEquipo())
                {
                    return cn.tblReunion.ToList();
                    //return cn.Database.SqlQuery<Curso>("Usp_ListarCurso").ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<tblReunion> Listar(int Equipo_Id)
        {
            var Oreunion = new List<tblReunion>();
            try
            {
                using (var cn = new DBEquipo())
                {
                    Oreunion = cn.tblReunion.Include("tblEquipo").Where(x => x.Equipo_Id == Equipo_Id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Oreunion;
        }



        public tblReunion Obtener(int ID)
        {
            var Oreunion = new tblReunion();

            try
            {
                using (var cn = new DBEquipo())
                {
                    //Oequipo = cn.tblEquipo.Where(x => x.ID_Equipo == ID).SingleOrDefault();
                    Oreunion = cn.tblReunion.Where(x => x.IDReunion == ID).Single();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Oreunion;

        }



        public JsonModel Guardar()
        {

            var rm = new JsonModel();

            try
            {
                using (var cn = new DBEquipo())
                {
                    if (this.IDReunion > 0)
                    {
                        cn.Entry(this).State = EntityState.Modified;
                        // cn.SaveChanges();
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


    }
}
