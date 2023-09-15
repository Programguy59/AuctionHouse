create PROCEDURE CreatePrivatePersonalCar
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

@hasIsoFixFittings bit

AS
begin

EXEC CreatePersonalCar @carName, @km, @registrationNumber, @releaseYear, @newPrice, @hasTowbar, @engineSize, @kmPerLiter, @fuelTypeEnum, @numberOfSeats, @height, @width, @depth;

DECLARE @currentID INT
SET @currentID = IDENT_CURRENT('PersonalCar');

Insert into PrivatePersonalCar
(
	PersonalCarId, hasIsoFixFittings
)
VALUES 
(
	@currentID, @hasIsoFixFittings
);
end
