using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using House.DAL.DataTransferObjects;
using House.DAL.Interfaces;
using House.DAL.SQL;
using Microsoft.Extensions.Options;

namespace House.DAL.Repositories
{
    public class AlertRepo : BaseRepository, IAlertRepo
    {
        public AlertRepo(IOptions<DbConnections> connectionStrings)
            : base(connectionStrings.Value.HouseSql)
        {
        }

        public Task<IEnumerable<AlertDto>> Get()
        {
            return ExecuteFunc(qry => qry.QueryAsync<AlertDto>(AlertSql.Get));
        }

        public Task<IEnumerable<AlertDto>> GetLatest()
        {
            return ExecuteFunc(qry => qry.QueryAsync<AlertDto>(AlertSql.GetLatest));
        }

        public Task<IEnumerable<AlertDto>> Get(int id)
        {
            return ExecuteFunc(qry => qry.QueryAsync<AlertDto>(AlertSql.GetById, new
            {
                Id = id,
            }));
        }

        public Task<IEnumerable<AlertDto>> Get(IEnumerable<int> ids)
        {
            return ExecuteFunc(qry => qry.QueryAsync<AlertDto>(AlertSql.GetByIds, new
            {
                Id = ids,
            }));
        }

        public void Post(NewAlert newAlert)
        {
            var result = ExecuteFunc(qry => qry.ExecuteAsync(AlertSql.Insert, new
            {
                Message = newAlert.Message,
                CreatedBy = newAlert.CreatedBy,
            }));
        }

        public void Put(int id, NewAlert newAlert)
        {
            var result = ExecuteFunc(qry => qry.ExecuteAsync(AlertSql.Update, new
            {
                Id = id,
                Message = newAlert.Message,
                CreatedBy = newAlert.CreatedBy,
            }));
        }

        public void Delete(int id)
        {
            var result = ExecuteFunc(qry => qry.ExecuteAsync(AlertSql.Delete, new
            {
                Id = id,
            }));
        }
    }
}
