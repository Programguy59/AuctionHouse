use AuctionHouse;

CREATE TABLE ProfessionalPersonalCar ( 
    id INT PRIMARY KEY IDENTITY not null,
	PersonalCarId INT FOREIGN KEY (PersonalCarId) REFERENCES PersonalCar(id) ON DELETE CASCADE not null,
	hasSafetyBar bit,
	loadCapacity decimal
)