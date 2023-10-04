USE AuctionHouse
GO

Create PROCEDURE UpdateIsDone 
@auctionId int, 
@isDone bit

AS
BEGIN
UPDATE Auctions
SET isDone = @isDone
WHERE id = @auctionId;
END
