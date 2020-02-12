using System.Collections.Generic;

namespace Task7.Data_Access
{
    interface IDataGateway<T>
    {
        IEnumerable<T> SelectAll();
        T SelectById(int id);
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
    }
}
