using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ICRUDService<T>
    {
        void Add(T t);

        void Modify(T t);

        void Remove(T t);

        IEnumerable<T> GetAll();
    }
}
