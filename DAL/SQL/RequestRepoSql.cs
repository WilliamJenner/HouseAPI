namespace House.DAL.SQL
{
    public static class RequestRepoSql
    {
        public const string SaveRequestItem = @"
USE [Dashboard]

INSERT INTO [dbo].[Requests]
           ([Requester]
           ,[RequestedAmount])
     VALUES
           (@Requester
           ,@Amount)";

        public const string GetCurrentAmount = @"
USE [Dashboard]

SELECT COALESCE(SUM(r.RequestedAmount), 0)
FROM Requests r
WHERE r.Expired IS NULL";

        public const string ExpireRequestItems = @"
USE [Dashboard]

UPDATE Requests SET Expired = 1
";
    }
}
