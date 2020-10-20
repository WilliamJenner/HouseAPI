namespace House.DAL
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using House.DAL.DataTransferObjects;
    using House.DAL.Interfaces;
    using House.DAL.SQL;
    using Microsoft.Extensions.Options;

    public class AlertRepo : BaseRepository, IAlertRepo
    {
        public AlertRepo(IOptions<DbConnections> connectionStrings)
            : base(connectionStrings.Value.HouseSql)
        {
        }

        public Task<IEnumerable<AlertDto>> Get()
        {
            return ExecuteFunc(qry => qry.QueryAsync<UniEventDto>(AlertSql.Get));
        }

        public Task<IEnumerable<AlertDto>> Get(int id)
        {
            return ExecuteFunc(qry => qry.QueryAsync<UniEventDto>(AlertSql.GetById, new
            {
                Id = id,
            }));
        }

        public Task<IEnumerable<AlertDto>> Get(IEnumerable<int> ids)
        {
            return ExecuteFunc(qry => qry.QueryAsync<UniEventDto>(AlertSql.GetByIds, new
            {
                Id = ids,
            }));
        }

        public void Post(NewAlert newEvent)
        {
            var result = ExecuteFunc(qry => qry.ExecuteAsync(AlertSql.Insert(), new
            {
                StartTime = newEvent.StartTime,
                EndTime = newEvent.EndTime,
                Unit = (int)newEvent.Unit,
                EventType = (int)newEvent.EventType,
                EventLeader = newEvent.EventLeader.Length > 50 ? newEvent.EventLeader.PadRight(newEvent.EventLeader.Length).Substring(0, 49) : newEvent.EventLeader,
            }));
        }

        public void PostBulk(List<NewAlert> newEvents)
        {
             ExecuteFunc(qry => qry.ExecuteAsync(AlertSql.InsertBulk(newEvents, false)));
        }

        public void Put(int id, NewAlert newEvent)
        {
            var result = ExecuteFunc(qry => qry.ExecuteAsync(UniEventSql.Update, new
            {
                StartTime = newEvent.StartTime,
                EndTime = newEvent.EndTime,
                Unit = (int)newEvent.Unit,
                EventType = (int)newEvent.EventType,
                EventLeader = newEvent.EventLeader,
                Id = id,
            }));
        }

        public void Delete(int id)
        {
            var result = ExecuteFunc(qry => qry.ExecuteAsync(UniEventSql.Delete, new
            {
                Id = id,
            }));
        }
    }
}
