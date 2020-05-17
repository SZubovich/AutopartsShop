using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Interfaces;
using DLL.Context;
using DLL.DTO;

namespace BLL.Services
{
    public abstract class CRUDService<T> : ICRUDService<T>
    {
        public void Add(T t)
        {
            if (Validation(t))
            {

            }
            else
            {

            }
        }

        public IEnumerable<T> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //var result = db.UT.ToList();
                return null;
            }
        }

        public void Modify(T t)
        {
            throw new NotImplementedException();
        }

        public void Remove(T t)
        {
            throw new NotImplementedException();
        }

        abstract protected bool Validation(T t);
    }
}
