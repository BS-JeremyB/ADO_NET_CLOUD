using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO_TOOLBOX.Entities;

namespace ADO_TOOLBOX.Mappers
{
    public class SectionMapper
    {

        public static Section Map(IDataRecord record)
        {

            int id = (int)record["Id"];
            string sectionName = record["SectionName"].ToString();

            return new Section() { Id = id, SectionName = sectionName };
        }

    }
}
