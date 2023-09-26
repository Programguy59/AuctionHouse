use AuctionHouse;

CREATE TABLE PrivatePersonalCar ( 
    id INT PRIMARY KEY IDENTITY not null,
	PersonalCarId INT FOREIGN KEY (PersonalCarId) REFERENCES PersonalCar(id) ON DELETE CASCADE not null,
	hasIsoFixFittings bit,
)