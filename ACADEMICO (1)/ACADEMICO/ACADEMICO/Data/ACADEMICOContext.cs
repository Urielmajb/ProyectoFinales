using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ACADEMICO.Models;
namespace ACADEMICO.Data
{
    public class ACADEMICOContext : DbContext
    {
        public ACADEMICOContext(DbContextOptions<ACADEMICOContext> options)
            : base(options)
        {
        }
        public DbSet<ACADEMICO.Models.Categoria> Categoria { get; set; }

        public DbSet<ACADEMICO.Models.Docente> Docente { get; set; }

    }
}
