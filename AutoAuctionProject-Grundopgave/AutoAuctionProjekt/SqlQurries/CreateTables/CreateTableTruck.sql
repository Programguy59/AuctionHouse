CREATE TABLE Truck ( 
    id INT PRIMARY KEY identity not null,
	heavyVehicleId INT FOREIGN KEY (heavyVehicleId) REFERENCES HeavyVehicle(id) ON DELETE CASCADE not null,
	loadCapacity Decimal not null 

)