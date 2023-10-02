Create PROCEDURE CreateBus
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

@numberOfSeats int,
@numberOfSleepingSpaces int,
@hasToilet bit

AS
begin

DECLARE @VehicleId int
DECLARE @BusId int

EXEC CreateHeavyVehicle @carName, @km, @registrationNumber, @releaseYear, @newPrice, @hasTowbar, @engineSize, @kmPerLiter, @fuelTypeEnum, @height, @weight, @length;

DECLARE @currentID INT
SET @currentID = IDENT_CURRENT('HeavyVehicle');

Insert into Bus
(
	heavyVehicleId, numberOfSeats, numberOfSleepingSpaces, hasToilet
)
VALUES 
(
	@currentID, @numberOfSeats, @numberOfSleepingSpaces, @hasToilet
);

SET @VehicleId = IDENT_CURRENT('Vehicle');
SET @BusId = IDENT_CURRENT('Bus');

SELECT @VehicleId AS VehicleId, @currentID AS HeavyVehicleId, @BusId;

end
