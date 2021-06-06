using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEchec
{
    interface IJoueurDAO : IGenericDAO<JOUEUR>
    {
        List<JOUEUR> GetAllJoueurByClub(CLUB club);
    }
}
