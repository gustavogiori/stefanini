using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Data
{
    public class DataBase<T> where T : class, new()
    {
        private SQLiteAsyncConnection _database;

        public DataBase()
        {
            SetConection(App.PathDataBase);
        }
        /// <summary>
        /// Set Conection com o banco.
        /// </summary>
        public void SetConection(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
        }

        /// <summary>
        /// Procura um dado no banco, de acordo com a condição passada.
        /// </summary>
        public Task<T> Find(Expression<Func<T, bool>> predicate) =>
                 _database.FindAsync<T>(predicate);

        /// <summary>
        /// Recupera todos os dados de uma tabela.
        /// </summary>
        public Task<List<T>> Get() =>
                 _database.Table<T>().ToListAsync();

        /// <summary>
        /// Deleta todos os dados de uma tabela.
        /// </summary>
        public async Task<int> DeleteAll() =>
              await _database.DeleteAllAsync<T>();

        /// <summary>
        /// Insere todos os dados em uma tabela.
        /// </summary>
        public async Task<int> Insert(T entity) =>
              await _database.InsertAsync(entity);

    }
}
