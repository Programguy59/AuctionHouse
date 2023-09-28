use AuctionHouse;

CREATE TABLE BidHistory ( 
    id int PRIMARY KEY IDENTITY not null,
	date datetime not null,
	bidAmount decimal not null,
	userName varchar(128) FOREIGN KEY (userName) REFERENCES Users(userName) not null,
	auctionId int  FOREIGN KEY (auctionId) REFERENCES Auctions(id) not null,
)