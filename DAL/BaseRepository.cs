namespace UserService.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading.Tasks;

    public class BaseRepository
    {
        private readonly string _connectionString = "Server=tcp:weeklydigest.database.windows.net,1433;Initial Catalog=weeklydigest;Persist Security Info=False;User ID=jeremy;Password=yqcSjQYrV0pY8i85fmZZ;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        protected BaseRepository()
        {
            
        }

        protected async Task<T> QueryAsync<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    return await getData(connection);
                }
            } catch (TimeoutException ex)
            {
                throw new Exception($"{GetType().FullName}.WithConnection() experienced a SQL timeout", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception($"{GetType().FullName}.WithConnection() experienced a SQL exception", ex);
            }
        }
    }
}
