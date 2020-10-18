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

        public Task<IEnumerable<UniEventDto>> Get(IEnumerable<int> ids)
        {
            return ExecuteFunc(qry => qry.QueryAsync<UniEventDto>(UniEventSql.GetByIds, new
            {
                Id = ids,
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
                EventLeader = newEvent.EventLeader.Length > 50 ? newEvent.EventLeader.PadRight(newEvent.EventLeader.Length).Substring(0, 49) : newEvent.EventLeader,
            }));
        }

        public async void PostBulk(List<NewUniEvent> newEvents)
        {
            await ExecuteFunc(qry => qry.ExecuteAsync(UniEventSql.InsertBulk(newEvents, false)));
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
