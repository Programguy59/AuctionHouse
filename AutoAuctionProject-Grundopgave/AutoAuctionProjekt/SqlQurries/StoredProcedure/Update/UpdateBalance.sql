USE AuctionHouse
GO

Create PROCEDURE UpdateBalance 
@userName varchar(128), 
@balance decimal

AS
BEGIN
UPDATE Users
SET balance = @balance
WHERE userName = @userName;
END
