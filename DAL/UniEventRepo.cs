using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Dapper;
using House.DAL.DataTransferObjects;
using House.DAL.Interfaces;
using House.DAL.SQL;

namespace House.DAL
{
    public class UniEventRepo : BaseRepository, IUniEventRepo
    {

        public UniEventRepo(IOptions<DbConnections> connectionStrings)
            : base(connectionStrings.Value.HouseSql)
        {
        }

        public Task<IEnumerable<UniEventDto>> Get()
        {
            return ExecuteFunc(qry => qry.QueryAsync<UniEventDto>(UniEventSql.Get));
        }

        public Task<IEnumerable<UniEventDto>> Get(int id)
        {
            return ExecuteFunc(qry => qry.QueryAsync<UniEventDto>(UniEventSql.GetById, new
            {
                Id = id,
            }));
        }

        public void Post(NewUniEvent newEvent)
        {
            var result = ExecuteFunc(qry => qry.ExecuteAsync(UniEventSql.Insert(), new
            {
                StartTime = newEvent.StartTime,
                EndTime = newEvent.EndTime,
                Unit = (int)newEvent.Unit,
                EventType = (int)newEvent.EventType,
                EventLeader = newEvent.EventLeader,
            }));
        }

        public void Put(int id, NewUniEvent newEvent)
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
