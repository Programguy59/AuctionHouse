use AuctionHouse
go

Create PROCEDURE CreateBidHistory 
@date datetime,
@bidAmount decimal,
@userName varchar(128),
@auctionId int

AS
begin
Insert into bidHistory
(
	date, bidAmount, userName,auctionId
)
VALUES 
(
	@date, @bidAmount, @userName,@auctionId
);
END