using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public class EDetalleActividad
    {
        public int IdDetalleActividad { get; set; }
        public int IdActividad { get; set; }
        public int IdAmbiente { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraTermino { get; set; }
        public string Direccion { get; set; }        
    }
}
