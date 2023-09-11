CREATE TABLE ProfessionalPersonalCar ( 
    id INT PRIMARY KEY not null,
	PersonalCarId INT FOREIGN KEY (PersonalCarId) REFERENCES PersonalCar(id) not null,
	hasSafetyBar bit not null,
	loadCapacity decimal not null,
)