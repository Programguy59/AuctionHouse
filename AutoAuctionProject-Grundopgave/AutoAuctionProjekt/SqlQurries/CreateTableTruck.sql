CREATE TABLE Truck ( 
    id INT PRIMARY KEY not null,
	heavyVehicleId INT FOREIGN KEY (heavyVehicleId) REFERENCES HeavyVehicle(id) not null,
	loadCapacity Decimal not null 

)