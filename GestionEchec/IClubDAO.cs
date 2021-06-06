using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEchec
{
    interface IClubDAO : IGenericDAO<CLUB>
    {
        List<CLUB> GetAllClubByCity(VILLE ville);
    }
}
