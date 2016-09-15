using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InnovaSchools.Models
{
    [Table("gsp.ConvocatoriaCandidato")]
    public class ConvocatoriaCandidato
    {
        [Key]
        [Required]
        [Column(Order = 1)]
        public int idConvocatoria { get; set; }

        [Key]
        [Required]
        [Column(Order = 2)]
        public int idCandidato { get; set; }
        
        [ForeignKey("idConvocatoria")]
        public virtual Convocatoria Convocatoria { get; set; }

        [ForeignKey("idCandidato")]
        public virtual Candidato Candidato { get; set; }
    }
}