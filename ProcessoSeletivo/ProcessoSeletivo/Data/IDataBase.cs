using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Data
{
    public interface IDataBase<T>
    {
        Task<T> Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Recupera todos os dados de uma tabela.
        /// </summary>
        Task<List<T>> Get();

        /// <summary>
        /// Deleta todos os dados de uma tabela.
        /// </summary>
        Task<int> DeleteAll();

        /// <summary>
        /// Insere todos os dados em uma tabela.
        /// </summary>
        Task<int> Insert(T entity);
    }
}
