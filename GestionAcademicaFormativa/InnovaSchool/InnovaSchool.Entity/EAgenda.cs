using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public class EAgenda
    {
        public string IdAgenda { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FecApertura { get; set; }
        public DateTime? FecCierre { get; set; }
        public DateTime? FecIniEscolar { get; set; }
        public DateTime? FecFinEscolar { get; set; }
        public int Estado { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FecCreacion { get; set; }
        public string UsuModificación { get; set; }
        public DateTime? FecModificacion { get; set; }
    }
}
