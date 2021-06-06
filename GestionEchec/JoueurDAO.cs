using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEchec
{
    class JoueurDAO : GenericDAO<JOUEUR>, IJoueurDAO
    {
        public JoueurDAO() : base(new Model1())
        {

        }

        public JoueurDAO(Model1 context) : base(context)
        {

        }

        /// <summary>
        /// Methode pour obtenir tous les joueurs d'un club
        /// </summary>
        /// <param name="club"></param>
        /// <returns></returns>
        public List<JOUEUR> GetAllJoueurByClub(CLUB club)
        {
            return _context.JOUEUR.Where(x => x.CLUB.idClub == club.idClub).ToList();
        }
    }
}
