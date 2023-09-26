use AuctionHouse;

CREATE TABLE Auctions ( 
    id int PRIMARY KEY not null,
	vehicleId int  FOREIGN KEY (vehicleId) REFERENCES Vehicle(id), 
	userName varchar(128) FOREIGN KEY (userName) REFERENCES Users(userName),
	minimumPrice decimal not null
)