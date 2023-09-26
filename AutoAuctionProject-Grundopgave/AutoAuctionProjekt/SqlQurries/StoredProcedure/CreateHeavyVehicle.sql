Create PROCEDURE CreateHeavyVehicle
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
@length Decimal

AS
begin

EXEC CreateVehicle @carName, @km, @registrationNumber, @releaseYear, @newPrice, @hasTowbar, @engineSize, @kmPerLiter, @fuelTypeEnum;

DECLARE @currentID INT
SET @currentID = IDENT_CURRENT('vehicle');

Insert into HeavyVehicle
(
	vehicleid, height, weight, length
)
VALUES 
(
	@currentID, @height, @weight, @length
);
end
