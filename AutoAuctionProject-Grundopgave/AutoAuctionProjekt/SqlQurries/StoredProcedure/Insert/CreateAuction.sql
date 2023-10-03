use AuctionHouse
go

CREATE PROCEDURE CreateAuction 
@vehicleId int,
@userName varchar(128),
@minimumPrice decimal

AS
begin
Insert into Auctions
(
	vehicleId, UserName, minimumPrice
)
VALUES 
(
	@vehicleId, @userName, @minimumPrice 
);

declare @auctionId int
SET @auctionId = IDENT_CURRENT('Auctions');

SELECT @auctionId AS id

END

