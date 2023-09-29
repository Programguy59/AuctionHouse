Create PROCEDURE CreateProfessionalPersonalCar
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
end
