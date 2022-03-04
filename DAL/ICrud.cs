using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICrud<T>
    {
        T findById(int id);

        List<T> findAll();

        int delete(long id);

        int save(T entity);

        int update(T entity);
    }

}
