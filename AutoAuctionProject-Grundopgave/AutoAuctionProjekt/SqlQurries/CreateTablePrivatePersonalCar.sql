CREATE TABLE PrivateCar ( 
    id INT PRIMARY KEY not null,
	PersonalCarId INT FOREIGN KEY (PersonalCarId) REFERENCES PersonalCar(id) not null,
	hasIsoFixFittings bit,
)