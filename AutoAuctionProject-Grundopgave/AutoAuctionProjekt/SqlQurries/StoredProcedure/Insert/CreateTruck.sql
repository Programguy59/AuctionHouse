Create PROCEDURE CreateTruck
@carName varchar(255),
@km int,
@registrationNumber varchar(255),
@releaseYear int,
@newPrice Decimal,
@hasTowbar bit,
@engineSize Decimal,
@kmPerLiter Decimal,
@fuelTypeEnum varchar(255),

@height Decimal,
@weight Decimal,
@length Decimal,

@loadCapacity Decimal

AS
begin

EXEC CreateHeavyVehicle @carName, @km, @registrationNumber, @releaseYear, @newPrice, @hasTowbar, @engineSize, @kmPerLiter, @fuelTypeEnum, @height, @weight, @length;

DECLARE @currentID INT
SET @currentID = IDENT_CURRENT('HeavyVehicle');

Insert into Truck
(
	heavyVehicleId, loadCapacity
)
VALUES 
(
	@currentID, @loadCapacity
);
end
