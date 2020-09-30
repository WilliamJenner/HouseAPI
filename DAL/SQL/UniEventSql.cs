namespace House.DAL.SQL
{
    public static class UniEventSql
    {
        public const string UsingTable = "USE [UniEvent]";

        public static string Get = $@"
        {UsingTable}
        
        SELECT [Id]
        ,[StartTime]
        ,[EndTime]
        ,[Unit]
        ,[EventType]
        ,[EventLeader]
        ,[DateCreated]
        ,[Expired]
        FROM [UniEvent].[dbo].[UniEvent]
        WHERE Expired = 0
        ";

        public static string GetById = $"{Get} AND Id = @Id";

        public static string Update = $"{Delete} {Insert(true)}";

        public static string Delete = $@"
        {UsingTable}
        UPDATE dbo.[UniEvent]
        SET Expired = 1
        WHERE Id = @Id
        ";

        public static string Insert(bool isUpdate = false)
        {
            return $@"
        {(isUpdate ? string.Empty : UsingTable)}
               
        INSERT INTO [dbo].[UniEvent]
                   ([StartTime]
                   ,[EndTime]
                   ,[Unit]
                   ,[EventType]
                   ,[EventLeader])
             VALUES
                   (@StartTime,
        		   @EndTime,
        		   @Unit,
        		   @EventType,
        		   @EventLeader)
        ";
        }
    }
}