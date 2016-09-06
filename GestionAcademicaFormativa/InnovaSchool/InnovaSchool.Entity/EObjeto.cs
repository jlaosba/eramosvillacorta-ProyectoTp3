using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public class EObjeto
    {
        public int IdObjeto { get; set; }
        public string Pagina { get; set; }
        public string Descripcion { get; set; }
        public string RutaPagina { get; set; }
        public int Estado { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FecCreacion { get; set; }
        public string UsuModificación { get; set; }
        public DateTime? FecModificacion { get; set; }
    }
}
