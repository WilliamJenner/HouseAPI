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

SELECT SUM(r.RequestedAmount)
FROM Requests r
WHERE r.Expired = 0";

        public const string ExpireRequestItems = @"
USE [Dashboard]

UPDATE Requests SET Expired = 1
";
    }
}
