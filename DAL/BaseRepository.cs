namespace House.DAL
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class BaseRepository
    {
        private readonly string _connectionString;
        protected BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected async Task<T> QueryAsync<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using var connection = new SqlConnection(this._connectionString);
                await connection.OpenAsync();
                return await getData(connection);
            }
            catch (TimeoutException ex)
            {
                throw new Exception($"{this.GetType().FullName}.WithConnection() experienced a SQL timeout", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception($"{this.GetType().FullName}.WithConnection() experienced a SQL exception", ex);
            }
        }
    }
}
