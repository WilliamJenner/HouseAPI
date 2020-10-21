namespace House.DAL.SQL
{
    using System.Collections.Generic;
    using System.Text;
    using House.DAL.DataTransferObjects;

    public static class AlertSql
    {
        public const string UsingTable = "USE [Dashboard]";

        public static readonly string GenericGet = $@"
        {UsingTable}
        SELECT TOP 1000
        [Id]
        ,[Message]
        ,[DateCreated]
        ,[CreatedBy]
        ,[Expired]
        FROM [Dashboard].[dbo].[Alert]
        WHERE Expired = 0
        ";

        public static string Get = $@"
        {GenericGet}
        ORDER BY [DateCreated] DESC
        ";

        public static string GetById = $"{GenericGet} AND Id = @Id";

        public static string GetByIds = $"{GenericGet} AND Id IN @Id";

        public static string Update = $"{Delete} {Insert}";

        public static string Delete = $@"
        {UsingTable}
        UPDATE dbo.[Alert]
        SET Expired = 1
        WHERE Id = @Id
        ";

        public static string Insert = 
        $@"
        USE [Dashboard]

        INSERT INTO [dbo].[Alert]
           ([Message]
           ,[CreatedBy])
        VALUES
           (@Message
           ,@CreatedBy)
        ";
    }
}