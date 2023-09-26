use AuctionHouse;

CREATE TABLE Truck ( 
    id INT PRIMARY KEY IDENTITY not null,
	heavyVehicleId INT FOREIGN KEY (heavyVehicleId) REFERENCES HeavyVehicle(id) ON DELETE CASCADE not null,
	loadCapacity Decimal not null 

)