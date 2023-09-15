CREATE TABLE Bus ( 
    id INT PRIMARY KEY not null identity,
	heavyVehicleId INT FOREIGN KEY (heavyVehicleId) REFERENCES HeavyVehicle(id) not null,
	numberOfSeats int not null,
	numberOfSleepingSpaces int not null,
	hasToilet bit not null,

)