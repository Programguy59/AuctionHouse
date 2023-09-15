use AuctionHouse;

CREATE TABLE Vehicle ( 
    id int primary key not null,
	carName int not null,
	km int not null,
	registrationNumber text not null,
	releaseYear int not null,
	newPrice Decimal not null,
	hasTowbar bit not null,
	engineSize Decimal not null,
	kmPerLiter Decimal not null,
	fuelTypeEnum Text not null
)