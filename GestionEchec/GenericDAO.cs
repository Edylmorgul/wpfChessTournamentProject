using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEchec
{
    abstract class GenericDAO<TEntity> : IGenericDAO<TEntity> where TEntity : class
    {
        protected readonly Model1 _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected GenericDAO()
        {

        }
        public GenericDAO(Model1 context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        /// <summary>
        /// Ajout d'une entité en base de donnée
        /// </summary>
        /// <param name="entityToCreate"></param>
        /// <returns></returns>
        public bool Create(TEntity entityToCreate)
        {
            try
            {
                _dbSet.Add(entityToCreate);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Methode pour supprimer un objet donné en base de donnée
        /// </summary>
        /// <param name="entityToDelete"></param>
        /// <returns></returns>
        public bool Delete(TEntity entityToDelete)
        {
            try
            {
                if (_context.Entry(entityToDelete).State == EntityState.Detached) //Si le contexte(état) de l'entité est détaché(Pas suivie par le contexte)
                {
                    _dbSet.Attach(entityToDelete); // ==> On l'attache
                }
                _dbSet.Remove(entityToDelete); // ==> On supprime                 
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Methode pour supprimer un objet  l'aide de son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(object id)
        {
            try
            {
                var entityToDelete = _dbSet.Find(id);
                Delete(entityToDelete);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteByEntitySimple(TEntity entityToDelete)
        {
            try
            {
                _dbSet.Remove(entityToDelete);
                _context.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Methode pour modifier un objet déjà présent en base de donnée
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Update(TEntity entityToUpdate)
        {
            try
            {
                _dbSet.Attach(entityToUpdate); // On attache l'entité au contexte(Elle existe déjà en bdd et des modifications peuvent avoir été apportées)
                _context.Entry(entityToUpdate).State = EntityState.Modified; //On change le statut de cette entité en modifié
                _context.SaveChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// Obtenir tous les éléments d'une table en base de donnée
        /// </summary>
        /// <returns></returns>
        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }      

        /// <summary>
        /// Obtenir une entité à l'aide de son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }
    }
}
