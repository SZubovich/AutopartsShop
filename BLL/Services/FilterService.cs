using System;
using DLL.Context;
using DLL.DTO;

namespace BLL.Services
{
    public abstract class FilterService<T>
    {
        public IEquatable<T> GetOneByPredicate(Predicate<T> predicate)
        {
            using (ApplicationContext context = new ApplicationContext())
            {

            }

            return null;
        }

        public void GetAllByPredicate(Predicate<T> predicate)
        {

        }
    }
}
