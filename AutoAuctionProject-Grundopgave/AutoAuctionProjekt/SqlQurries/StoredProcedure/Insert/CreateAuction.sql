use AuctionHouse
go

Create PROCEDURE CreateAuction 
@vehicleId int,
@userName varchar(128),
@minimumPrice decimal,
@isDone bit

AS
begin
Insert into Auctions
(
	vehicleId, UserName, minimumPrice, isDone
)
VALUES 
(
	@vehicleId, @userName, @minimumPrice, @isDone
);



declare @auctionId int
SET @auctionId = IDENT_CURRENT('Auctions');

Insert into bidHistory
(
	date, bidAmount, userName,auctionId
)
VALUES 
(
	GETDATE(), @minimumPrice, @userName,@auctionId
);

SELECT @auctionId AS id

END

