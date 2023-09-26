use AuctionHouse;

CREATE TABLE Vehicle ( 
    id int primary key IDENTITY not null ,
	carName varchar(255) not null,
	km int not null,
	registrationNumber varchar(255) not null,
	releaseYear int not null,
	newPrice Decimal not null,
	hasTowbar bit not null,
	engineSize Decimal not null,
	kmPerLiter Decimal not null,
	fuelTypeEnum varchar(255) not null
)