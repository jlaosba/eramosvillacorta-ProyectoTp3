using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovaSchool.Entity;
using InnovaSchool.DAL;

namespace InnovaSchool.BL
{
    public class BAgenda
    {
        DAgenda DAgenda = new DAgenda();

        public int RegistrarAperturaAgenda(EAgenda EAgenda, EUsuario EUsuario)
        {
            return DAgenda.RegistrarAperturaAgenda(EAgenda, EUsuario);
        }

        public EAgenda VerificarAperturaAgenda()
        {
            return DAgenda.VerificarAperturaAgenda();
        }

        public List<EAgenda> AniosAgenda()
        {
            return DAgenda.AniosAgenda();
        }

        public EAgenda ConsultarAgenda(EAgenda EAgenda)
        {
            return DAgenda.ConsultarAgenda(EAgenda);
        }
        
        public int GenerarAgenda(EAgenda EAgenda)
        {
            return DAgenda.GenerarAgenda(EAgenda);
        }
    }
}
