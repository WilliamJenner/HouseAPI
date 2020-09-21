namespace House.DAL
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Serilog;

    public abstract class BaseRepository
    {
        private readonly string _connectionString;

        protected BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected async Task<T> ExecuteFunc<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                return await getData(connection);
            }
            catch (Exception ex)
            {
                var exceptionMsg = $"{GetType().FullName}.ExecuteFunc experienced a {ex.GetType()}";
                Log.Error(ex, exceptionMsg);
                throw new Exception(exceptionMsg, ex);
            }
        }
    }
}