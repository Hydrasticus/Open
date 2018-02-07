using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Open.Core {
    public interface IObjectsRepository<T> {
        Task<T> GetObject(int id);

        Task<IEnumerable<T>> GetObjectsList();

        Task<T> AddObject(T o);

        void UpdateObject(T o);

        void DeleteObject(T o);
    }
}
