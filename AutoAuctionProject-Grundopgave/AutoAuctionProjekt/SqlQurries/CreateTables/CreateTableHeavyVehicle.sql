use AuctionHouse;

CREATE TABLE HeavyVehicle ( 
    id INT PRIMARY KEY IDENTITY not null,
	vehicleid INT FOREIGN KEY (vehicleid) REFERENCES Vehicle(id) ON DELETE CASCADE not null,
	height Decimal not null,
	weight Decimal not null,
	length Decimal not null,
)