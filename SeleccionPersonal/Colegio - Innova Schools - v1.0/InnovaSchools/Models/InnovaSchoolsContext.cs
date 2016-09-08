using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace InnovaSchools.Models
{
    public class InnovaSchoolsContext : DbContext
    {
        public InnovaSchoolsContext()
            : base("InnovaSchools")
        {
        }


        public DbSet<Puesto> Puesto { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Convocatoria> Convocatoria { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here
            base.OnModelCreating(modelBuilder);
            
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}