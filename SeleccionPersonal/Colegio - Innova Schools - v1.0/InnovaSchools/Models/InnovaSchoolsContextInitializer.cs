using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;

namespace InnovaSchools.Models
{
    public class InnovaSchoolsContextInitializer : DropCreateDatabaseIfModelChanges<InnovaSchoolsContext>
    {
        protected override void Seed(InnovaSchoolsContext context)
        {

           }
    }
}