using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEchec
{
    interface IPaysDAO : IGenericDAO<PAYS>
    {
        PAYS CheckPaysDbByName(string name);
    }
}
