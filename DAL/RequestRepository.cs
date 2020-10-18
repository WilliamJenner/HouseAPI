namespace House.DAL
{
    using System;
    using System.Threading.Tasks;
    using Dapper;
    using House.DAL.SQL;
    using Microsoft.Extensions.Options;
    using Serilog;

    public class RequestRepository : BaseRepository, IRequestRepository
    {
        public RequestRepository(IOptions<DbConnections> connectionStrings)
            : base(connectionStrings.Value.HouseSql)
        {
        }

        public async Task<bool> SaveRequestItem(SaveItemRequest request)
        {
            try
            {
                var result = await ExecuteFunc(qry => qry.ExecuteAsync(RequestRepoSql.SaveRequestItem, new { request.Amount, request.Requester }));
                return result > 0;
            }
            catch (Exception e)
            {
                Log.Error(e, "Failed to save item");
                return false;
            }
            
        }

        public async Task<decimal> GetAmountRequired()
        {
            try
            {
                return await ExecuteFunc(qry => qry.QuerySingleAsync<decimal>(RequestRepoSql.GetCurrentAmount));
            }
            catch (Exception e)
            {
                Log.Error(e, "Failed to get amount");
                throw;
            }
        }

        public async Task<bool> ExpireRequestItems()
        {
            try
            {
                var result = await ExecuteFunc(qry => qry.ExecuteAsync(RequestRepoSql.ExpireRequestItems));
                return result > 0;
            }
            catch (Exception e)
            {
                Log.Error(e, "Failed to expire items");
                return false;
            }
        }
    }

    public class SaveItemRequest
    {
        public decimal Amount { get; set; }

        public string Requester { get; set; }
    }
}
