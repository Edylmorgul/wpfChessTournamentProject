using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEchec
{
    class PaysDAO : GenericDAO<PAYS>, IPaysDAO
    {
        public PaysDAO() : base(new Model1())
        {

        }

        public PaysDAO(Model1 context) : base(context)
        {

        }       

        /// <summary>
        /// Methode pour vérifier si un pays existe déjà en base de donnée via son nom
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PAYS CheckPaysDbByName(string name)
        {
            return _context.PAYS.FirstOrDefault(x => x.nomPays == name);
        }
    }
}
// Création d'un référentiel non-générique mais dédié à une classe en particulier disposant de ses propres méthodes
