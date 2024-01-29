using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Application.Common.Interfaces.GenericRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity, Guid id);
        void Delete(Guid id);
    }
}
