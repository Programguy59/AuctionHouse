use AuctionHouse;

CREATE TABLE PersonalCar ( 
    id INT PRIMARY KEY IDENTITY not null,
	vehicleid INT FOREIGN KEY (vehicleid) REFERENCES Vehicle(id) ON DELETE CASCADE not null,
	numberOfSeats int not null,
	height Decimal not null,
	width decimal not null,
	depth decimal not null,

)