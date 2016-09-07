using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovaSchool.Entity;
using InnovaSchool.DAL;

namespace InnovaSchool.BL
{
    public class BCalendario
    {
        DCalendario DCalendario = new DCalendario();

        public List<ECalendario> ConsultarCalendariosAgenda(ECalendario ECalendario)
        {
            return DCalendario.ConsultarCalendariosAgenda(ECalendario);
        }

        public ECalendario VerificarAperturaCalendario(ECalendario ECalendario)
        {
            return DCalendario.VerificarAperturaCalendario(ECalendario);
        }

        public List<ECalendario> AniosCalendario(ECalendario ECalendario)
        {
            return DCalendario.AniosCalendario(ECalendario);
        }

        public List<ECalendario> ConsultarCalendario(ECalendario ECalendario)
        {
            return DCalendario.ConsultarCalendario(ECalendario);
        }

        public int RegistrarAperturaCalendario(EUsuario EUsuario)
        {
            return DCalendario.RegistrarAperturaCalendario(EUsuario);
        }
        
    }
        
}
