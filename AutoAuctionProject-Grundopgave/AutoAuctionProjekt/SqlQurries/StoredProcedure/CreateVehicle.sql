Create PROCEDURE CreateVehicle
@carName varchar(255),
@km int,
@registrationNumber varchar(255),
@releaseYear int,
@newPrice Decimal,
@hasTowbar bit,
@engineSize Decimal,
@kmPerLiter Decimal,
@fuelTypeEnum varchar(255)
AS
begin
Insert into Vehicle 
(
	carName, km, registrationNumber, releaseYear, newPrice, hasTowbar, engineSize, kmPerLiter, fuelTypeEnum
)
VALUES 
(
	@carName, @km, @registrationNumber, @releaseYear, @newPrice, @hasTowbar, @engineSize, @kmPerLiter, @fuelTypeEnum
);
end
