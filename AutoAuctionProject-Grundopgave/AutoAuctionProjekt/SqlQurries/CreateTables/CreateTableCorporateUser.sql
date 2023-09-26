use AuctionHouse;

CREATE TABLE CorporateUsers ( 
    CVR varchar(8) PRIMARY KEY not null,
	credit decimal not null,
	username varchar(128) FOREIGN KEY (userName) REFERENCES Users(userName) ON DELETE CASCADE not null,
)