using Persistence.Models.ReadModels;
using Persistence.Models.WriteModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly ISqlClient _sqlClient;
        private const string TableName = "coffee";

        public CoffeeRepository(ISqlClient sqlClient)
        {
            _sqlClient = sqlClient;
        }

        public Task<IEnumerable<CoffeeReadModel>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {TableName}";

            return _sqlClient.QueryAsync<CoffeeReadModel>(sql);
        }

        public Task<int> SaveAsync(CoffeeWriteModel model)
        {
            var sql = @$"INSERT INTO {TableName} (Id, Name, Price, Image) 
                        VALUES (@Id, @Name, @Price, @Image)";

            return _sqlClient.ExecuteAsync(sql, model);
        }

        public Task<int> DeleteAsync(Guid id)
        {
            var sql = $"DELETE FROM {TableName} WHERE Id = @Id;";

            return _sqlClient.ExecuteAsync(sql, new { Id = id });
        }
    }
}
