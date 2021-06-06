using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEchec
{
    class VilleDAO : GenericDAO<VILLE>, IVilleDAO
    {
        public VilleDAO() : base(new Model1())
        {

        }

        public VilleDAO(Model1 context) : base(context)
        {

        }

        /// <summary>
        /// Methode afin d'obtenir toutes les villes appartenant à un pays
        /// </summary>
        /// <param name="pays"></param>
        /// <returns></returns>
        public List<VILLE> GetAllCityByCountry(PAYS pays)
        {
            return _context.VILLE.Where(x => x.PAYS.idPays == pays.idPays).ToList();
        }

        /// <summary>
        /// Methode pour vérifier si une ville existe déjà en base de donnée
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public VILLE CheckVilleDbByname(string name)
        {
            return _context.VILLE.FirstOrDefault(x => x.nomVille == name);
        }
    }
}
