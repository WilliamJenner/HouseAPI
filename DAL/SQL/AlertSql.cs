namespace House.DAL.SQL
{
    using System.Collections.Generic;
    using System.Text;
    using House.DAL.DataTransferObjects;

    public static class AlertSql
    {
        public const string UsingTable = "USE [Alert]";

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

        public static string GetByIds = $"{Get} AND Id IN @Id";

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

        public static string InsertBulk(List<NewUniEvent> newEvents, bool isUpdate = false)
        {
            var newInsert = new StringBuilder();

            if (!isUpdate)
            {
                newInsert.Append(UsingTable);
            }

            newInsert.Append(@" INSERT INTO [dbo].[UniEvent]
                                ([StartTime]
                                ,[EndTime]
                                ,[Unit]
                                ,[EventType]
                                ,[EventLeader]) VALUES ");
            foreach (var newEvent in newEvents)
            {
                newInsert.Append(
                    $@"('{newEvent.StartTime:yyyy-MM-dd HH:mm:ss}',
                    '{newEvent.EndTime:yyyy-MM-dd HH:mm:ss}', 
                    {newEvent.Unit}, {newEvent.EventType}, 
                    '{(newEvent.EventLeader.Length > 50 ? newEvent.EventLeader.PadRight(newEvent.EventLeader.Length).Substring(0,49) : newEvent.EventLeader)}'),");
            }

            return newInsert.ToString().TrimEnd(',');
        }
    }
}