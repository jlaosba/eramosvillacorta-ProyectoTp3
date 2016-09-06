using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovaSchool.DAL;
using InnovaSchool.Entity;

namespace InnovaSchool.BL
{
    public class BParametro
    {
        DParametro DParametro = new DParametro();

        public string ConsultarParametro(int IdPadre, int ValNumerico, string ValTextual)
        {
            return DParametro.ConsultarParametro(IdPadre, ValNumerico, ValTextual);
        }

        public List<EParametro> ConsultarParametrosLista(int IdPadre)
        {
            return DParametro.ConsultarParametrosLista(IdPadre);
        }
    }
}
