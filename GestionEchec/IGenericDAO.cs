using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEchec
{
    interface IGenericDAO<TEntity> where TEntity : class
    {
        bool Create(TEntity entityToCreate);
        bool Delete(TEntity entityToDelete);
        bool DeleteById(object id);
        bool DeleteByEntitySimple(TEntity entityToDelete);
        bool Update(TEntity entityToUpdate);     
        List<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
// Création du référenciel générique ==> Des methodes communes disponibles pour toutes les autres classes du projet