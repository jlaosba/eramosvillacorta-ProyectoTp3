using InnovaSchool.DAL;
using InnovaSchool.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.BL
{
    public class BSolicitudActividad
    {
        DSolicitudActividad DSolicitudActividad = new DSolicitudActividad();

        public int RegistrarSolicitudActividad(ESolicitudActividad ESolicitudActividad, EUsuario EUsuario, ECalendario ECalendario, ref int IdSolicitudActividad)
        {
            return DSolicitudActividad.RegistrarSolicitudActividad(ESolicitudActividad, EUsuario, ECalendario, ref IdSolicitudActividad);
        }

        public int EnviarSolicitudActividad(ESolicitudActividad ESolicitudActividad)
        {
            return DSolicitudActividad.EnviarSolicitudActividad(ESolicitudActividad);
        }       

        public List<ESolicitudActividad> ListarSolicitudesAgenda(EAgenda EAgenda, EUsuario EUsuario)
        {
            return DSolicitudActividad.ListarSolicitudesAgenda(EAgenda, EUsuario);
        }
    }
}
