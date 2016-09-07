using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovaSchool.Entity;
using InnovaSchool.DAL;

namespace InnovaSchool.BL
{
    public class BPersona
    {
        DPersona DPersona = new DPersona();

        public List<EPersona> ListarPersona()
        {
            return DPersona.ListarPersona();
        }
    }
}
