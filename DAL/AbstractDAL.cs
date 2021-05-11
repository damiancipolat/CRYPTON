﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DAO;

namespace DAL
{
    public abstract class AbstractDAL<T>:ICrud<T>
    {
        public AbstractDAL() {}

        public T findById(int id) { return (new List<T>())[0]; }

        public List<T> findAll() { return new List<T>(); }

        public int delete(int id) { return 0; }

        public int save(T entity) { return 0; }

        public int update(T entity) { return 0; }
    
    }
}