using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public class EFeriado
    {
        public int IdFeriado { get; set; }
        public DateTime? Fecha { get; set; }
        public string Motivo { get; set; }
	    public string UsuCreacion { get; set; }
        public DateTime? FecCreacion { get; set; }
	    public string UsuModificación { get; set; }
        public DateTime? FecModificacion { get; set; }
    }
}
