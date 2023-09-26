use AuctionHouse;

CREATE TABLE Bus ( 
    id INT PRIMARY KEY IDENTITY not null,
	heavyVehicleId INT FOREIGN KEY (heavyVehicleId) REFERENCES HeavyVehicle(id) not null,
	numberOfSeats int not null,
	numberOfSleepingSpaces int not null,
	hasToilet bit not null,

)