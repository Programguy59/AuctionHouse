CREATE PROCEDURE FetchVehicle @vehicleId INT 
AS
BEGIN

DECLARE @fullCarId INT;
DECLARE @nextStepTable NVARCHAR(255);
DECLARE @fullCarTable NVARCHAR(255);

DECLARE @proCarId INT;
DECLARE @perCarId INT;
DECLARE @truckId INT;
DECLARE @busId INT;

DECLARE @sql NVARCHAR(1023);

SELECT @proCarId = compass.proCarId,
       @perCarId = compass.perCarId,
       @truckId = compass.truckId,
       @busId = compass.busId
FROM (
    SELECT pro.id as proCarId, ppc.id as perCarId, tr.id as truckId, bu.id as busId
    FROM Vehicle as V
    LEFT JOIN HeavyVehicle AS hv ON hv.vehicleid = v.id
    LEFT JOIN Truck AS tr ON tr.heavyVehicleId = hv.id
    LEFT JOIN Bus AS bu ON bu.heavyVehicleId = hv.id
    LEFT JOIN PersonalCar AS pc ON pc.vehicleid = v.id
    LEFT JOIN PrivatePersonalCar AS ppc ON ppc.PersonalCarId = pc.id
    LEFT JOIN ProfessionalPersonalCar AS pro ON pro.PersonalCarId = pc.id
    WHERE v.id = @vehicleId
) AS compass;

IF @proCarId IS NOT NULL
BEGIN
    SET @fullCarId = @proCarId;
	SET @nextStepTable = 'PersonalCar';
    SET @fullCarTable = 'ProfessionalPersonalCar';
END
ELSE IF @perCarId IS NOT NULL
BEGIN
    SET @fullCarId = @perCarId;
	SET @nextStepTable = 'PersonalCar';
    SET @fullCarTable = 'PrivatePersonalCar';
END
ELSE IF @truckId IS NOT NULL
BEGIN
    SET @fullCarId = @truckId;
	SET @nextStepTable = 'HeavyVehicle';
    SET @fullCarTable = 'Truck';
END
ELSE IF @busId IS NOT NULL
BEGIN
    SET @fullCarId = @busId;
	SET @nextStepTable = 'HeavyVehicle';
    SET @fullCarTable = 'Bus';
END

-- Construct the dynamic SQL query
SET @sql = N'
SELECT ''' + @fullCarTable + ''' AS TableName, V.*, nst.*, fct.*
FROM Vehicle AS V
LEFT JOIN ' + QUOTENAME(@nextStepTable) + ' AS nst ON V.id = nst.vehicleid
LEFT JOIN ' + QUOTENAME(@fullCarTable) + ' AS fct ON nst.id = fct.' + @nextStepTable + 'Id
WHERE fct.id = @fullCarId';

-- Execute the dynamic SQL query
EXEC sp_executesql @sql, N'@fullCarId INT', @fullCarId;
		
				
END