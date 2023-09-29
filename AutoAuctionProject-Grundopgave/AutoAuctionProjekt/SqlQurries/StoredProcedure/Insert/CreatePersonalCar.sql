Create PROCEDURE CreatePersonalCar
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
@depth Decimal

AS
begin

EXEC CreateVehicle @carName, @km, @registrationNumber, @releaseYear, @newPrice, @hasTowbar, @engineSize, @kmPerLiter, @fuelTypeEnum;

DECLARE @currentID INT
SET @currentID = IDENT_CURRENT('vehicle');

Insert into PersonalCar
(
	vehicleid, numberOfSeats, height, width, depth
)
VALUES 
(
	@currentID, @currentID, @height, @width, @depth
);
end
