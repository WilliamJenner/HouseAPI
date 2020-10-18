using System.Threading.Tasks;
using Dapper;
using House.DAL.SQL;
using Microsoft.Extensions.Options;

namespace House.DAL
{
    public class RequestRepository : BaseRepository, IRequestRepository
    {
        public RequestRepository(IOptions<DbConnections> connectionStrings)
            : base(connectionStrings.Value.HouseSql)
        {
        }

        public async Task<bool> SaveRequestItem(SaveItemRequest request)
        {
            var result = await ExecuteFunc(qry => qry.ExecuteAsync(RequestRepoSql.SaveRequestItem, new { request.Amount, request.Requester }));
            return result > 0;
        }

        public async Task<decimal> GetAmountRequired()
        {
            return await ExecuteFunc(qry => qry.QuerySingleAsync<decimal>(RequestRepoSql.GetCurrentAmount));
        }

        public async Task<bool> ExpireRequestItems()
        {
            var result = await ExecuteFunc(qry => qry.ExecuteAsync(RequestRepoSql.ExpireRequestItems));
            return result > 0;
        }
    }

    public class SaveItemRequest
    { 
        public SaveItemRequest()
        {

        }

        public decimal Amount { get; set; }

        public string Requester { get; set; }
    }
}
