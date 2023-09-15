CREATE TABLE Bus ( 
    id INT PRIMARY KEY not null AUTO_INCREMENT,
	heavyVehicleId INT FOREIGN KEY (heavyVehicleId) REFERENCES HeavyVehicle(id) not null,
	numberOfSeats int not null,
	numberOfSleepingSpaces int not null,
	hasToilet bit not null,

)