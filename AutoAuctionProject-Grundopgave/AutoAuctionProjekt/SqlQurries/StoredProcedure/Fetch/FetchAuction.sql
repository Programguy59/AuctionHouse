USE AuctionHouse
GO

ALTER PROCEDURE FetchAuction 
@auctionId int 
AS
BEGIN
select * from Auctions where id = @auctionId
END