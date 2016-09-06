using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public class ESolicitudActividad
    {
        public int IdSolicitudActividad { get; set; }
        public string Motivo { get; set; }

        public int Estado { get; set; }

        public string Tipo { get; set; }

        public EActividad EActividad { get; set; }
    }
}
