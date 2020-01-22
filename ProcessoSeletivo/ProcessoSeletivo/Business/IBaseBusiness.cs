using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Business
{
    public interface IBaseBusiness<T>
    {
        Task Insert(T entity);
        Task<List<T>> Get();
        Task<T> Find(Expression<Func<T, bool>> predicate);
    }
}
