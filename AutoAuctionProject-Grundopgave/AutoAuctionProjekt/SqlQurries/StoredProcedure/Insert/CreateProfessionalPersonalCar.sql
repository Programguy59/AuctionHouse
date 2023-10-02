ALTER PROCEDURE CreateProfessionalPersonalCar
@carName varchar(255),
@km int,
@registrationNumber varchar(255),
@releaseYear int,
@newPrice Decimal,
@hasTowbar bit,
@engineSize Decimal,
@kmPerLiter Decimal,
@fuelTypeEnum varchar(255),

@numberOfSeats int,
@height Decimal,
@width Decimal,
@depth Decimal,

@hasSafetyBar bit,
@loadCapacity Decimal

AS
begin

DECLARE @VehicleId int
DECLARE @ProPerCarId int

EXEC CreatePersonalCar @carName, @km, @registrationNumber, @releaseYear, @newPrice, @hasTowbar, @engineSize, @kmPerLiter, @fuelTypeEnum, @numberOfSeats, @height, @width, @depth;

DECLARE @currentID INT
SET @currentID = IDENT_CURRENT('PersonalCar');

Insert into ProfessionalPersonalCar
(
	PersonalCarId, hasSafetyBar, loadCapacity
)
VALUES 
(
	@currentID, @hasSafetyBar, @loadCapacity
);

SET @VehicleId = IDENT_CURRENT('Vehicle');
SET @ProPerCarId = IDENT_CURRENT('ProfessionalPersonalCar');

SELECT @VehicleId AS VehicleId, @currentID AS HeavyVehicleId, @ProPerCarId;

end
