namespace House.DAL.SQL
{
    public static class RequestRepoSql
    {
        public const string SaveRequestItem = @"
USE [Dashboard]
GO

INSERT INTO [dbo].[Requests]
           ([Requester]
           ,[RequestedAmount])
     VALUES
           (@Amount
           ,@Requester)
GO";

        public const string GetCurrentAmount = @"
USE [Dashboard]
GO

SELECT SUM(r.RequestedAmount)
FROM Requests r
WHERE r.Expired = 0";

        public const string ExpireRequestItems = @"
USE [Dashboard]
GO

UPDATE Requests SET Expired = 1

GO";
    }
}
