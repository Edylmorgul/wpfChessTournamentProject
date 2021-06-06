using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEchec
{
    interface IVilleDAO : IGenericDAO<VILLE>
    {
        List<VILLE> GetAllCityByCountry(PAYS pays);
        VILLE CheckVilleDbByname(string name);
    }
}
