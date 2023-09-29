use AuctionHouse
go

Create PROCEDURE CreateAuction 
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
END