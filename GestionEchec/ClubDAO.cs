using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEchec
{
    class ClubDAO : GenericDAO<CLUB>, IClubDAO
    {
        public ClubDAO() : base(new Model1())
        {

        }

        public ClubDAO(Model1 context) : base(context)
        {

        }

        /// <summary>
        /// Methode afin d'obtenir tous les clubs d'une ville
        /// </summary>
        /// <param name="pays"></param>
        /// <returns></returns>
        public List<CLUB> GetAllClubByCity(VILLE ville)
        {
            return _context.CLUB.Where(x => x.VILLE.idVille == ville.idVille).ToList();
        }
    }
}
