use AuctionHouse;

CREATE TABLE Users ( 
    userName varchar(128) PRIMARY KEY not null,
	corporateUser bit not null,
	balance decimal not null,
)