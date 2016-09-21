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

        ////********** DISTRIBUCION ******************************************************************//        
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<NivelEstudio> NivelEstudio { get; set; }
        public DbSet<Banco> Banco { get; set; }        
        public DbSet<EstadoEmpleado> EstadoEmpleado { get; set; }
        public DbSet<FondoPensiones> FondoPensiones { get; set; }
        public DbSet<Seguro> Seguro { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }

        public DbSet<Area> Area { get; set; }
        public DbSet<TipoPuesto> TipoPuesto { get; set; }
        public DbSet<Puesto> Puesto { get; set; }
        public DbSet<Desarrollo> Desarrollo { get; set; }
        public DbSet<Nacionalidad> Nacionalidad { get; set; }
        public DbSet<DocumentoIdentidad> DocumentoIdentidad { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<EstadoCandidato> EstadoCandidato { get; set; }
        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Convocatoria> Convocatoria { get; set; }
        public DbSet<TipoContrato> TipoContrato { get; set; }
        public DbSet<Empleado> Empleado { get; set; }

        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<ConvocatoriaCandidato> ConvocatoriaCandidato { get; set; }
                
        ////*****************************************************************************************//



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here
            base.OnModelCreating(modelBuilder);
            
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}