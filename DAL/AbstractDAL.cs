using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DAO;
using DAL.Mapper;

namespace DAL
{
    public abstract class AbstractDAL<T>:ICrud<T>
    {
        //Binder.
        public EntityBinder binder = new EntityBinder();

        //Acesso a manejador de datos.
        public SqlParser getParser()
        {
            return new SqlParser();
        }
        public QuerySelect getSelect()
        {
            return new QuerySelect();
        }
        public QueryInsert getInsert()
        {
            return new QueryInsert();
        }
        public QueryUpdate getUpdate()
        {
            return new QueryUpdate();
        }
        public QueryDelete getDelete()
        {
            return new QueryDelete();
        }

        //Metodos de entidadedes.
        public AbstractDAL() {}

        public T findById(int id) { return (new List<T>())[0]; }

        public List<T> findAll() { return new List<T>(); }

        public int delete(int id) { return 0; }

        public int save(T entity) { return 0; }

        public int update(T entity) { return 0; }

        public QueryBuilder buildSelect()
        {
            return new QuerySelect();
        }
    }
}
