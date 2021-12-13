using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACADEMICO.Models;

namespace ACADEMICO.Data
{
    public class DbInitializer
    {

        public static void Initialize(ACADEMICOContext context)
        {
            context.Database.EnsureCreated();


            if  (context.Categoria.Any())
            {
                return;
            }

            var categorias = new Categoria[]
            {
                new Categoria {Nombre="Programación", Descripcion="Curso de Programación",Estado=true},
                new Categoria {Nombre="Diseño Gráfico", Descripcion="Diseño Gráfico",Estado=true},
                new Categoria {Nombre="Administracion Sql Server 2019", Descripcion="Administracion de Sql",Estado=true}
            };



            //agregar la categoria

            foreach (Categoria c in categorias)
            {

                context.Categoria.Add(c);
            }

            context.SaveChanges();



            if (context.Docente.Any())
            {
                return;
            }

            var docente = new Docente[]
            {
                new Docente {NombreDocente="Juan Perez", FechaNacimiento=DateTime.Parse("10/10/1989"), Edad=32,Estado=true},
                new Docente {NombreDocente="Denis Moncada", FechaNacimiento=DateTime.Parse("28/11/1949"),Edad=79,Estado=true},
                new Docente {NombreDocente="Arlette Marenco", FechaNacimiento=DateTime.Parse("03/02/1981"),Edad=40,Estado=true},
                new Docente {NombreDocente="Jessica Padilla", FechaNacimiento=DateTime.Parse("12/05/1994"),Edad=27,Estado=true},
                new Docente {NombreDocente="Sonia Castro", FechaNacimiento=DateTime.Parse("11/11/1971"),Edad=50,Estado=true},
                new Docente {NombreDocente="Ivan Lara", FechaNacimiento=DateTime.Parse("10/10/1989"),Edad=11,Estado=true},
                new Docente {NombreDocente="Ivan Acosta", FechaNacimiento=DateTime.Parse("10/10/1989"),Edad=32,Estado=true},
                new Docente {NombreDocente="Sidartha Marin", FechaNacimiento=DateTime.Parse("10/10/1989"),Edad=32,Estado=true},
                new Docente {NombreDocente="Idania Castillo", FechaNacimiento=DateTime.Parse("10/10/1989"),Edad=32,Estado=true},
                new Docente {NombreDocente="Michael Campbell", FechaNacimiento=DateTime.Parse("10/10/1989"),Edad=32,Estado=true}

            };



            //agregar la categoria

            foreach (Docente c in docente)
            {

                context.Docente.Add(c);
            }

            context.SaveChanges();

        }


    }
}
