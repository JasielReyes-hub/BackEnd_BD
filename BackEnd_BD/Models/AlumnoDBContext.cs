using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BackEnd_BD.Models
{
    public class AlumnoDBContext : DbContext
    {
        private static string connection1 = "DefaultConnection";
        public AlumnoDBContext() : base(connection1)
    {

    }

    public DbSet<Alumnos> Alumnos { get; set; }
    public DbSet<Maestros> Maestros { get; set; }

    }
}