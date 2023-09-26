use AuctionHouse;

CREATE TABLE PrivateUsers ( 
    CPR varchar(10) PRIMARY KEY not null,
	username varchar(128) FOREIGN KEY (userName) REFERENCES Users(userName) ON DELETE CASCADE not null,
)