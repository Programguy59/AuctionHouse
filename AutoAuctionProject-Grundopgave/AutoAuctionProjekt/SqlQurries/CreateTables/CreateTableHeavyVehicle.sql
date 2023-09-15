CREATE TABLE HeavyVehicle ( 
    id INT PRIMARY KEY not null,
	vehicleid INT FOREIGN KEY (vehicleid) REFERENCES Vehicle(id) not null,
	height Decimal not null,
	weight Decimal not null,
	length Decimal not null,
)