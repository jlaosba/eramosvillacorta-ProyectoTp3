using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovaSchool.DAL;
using InnovaSchool.Entity;

namespace InnovaSchool.BL
{
    public class BAmbiente
    {
        DAmbiente DAmbiente = new DAmbiente();

        public List<EAmbiente> ListarAmbientes()
        {
            return DAmbiente.ListarAmbientes();
        }
    }
}
