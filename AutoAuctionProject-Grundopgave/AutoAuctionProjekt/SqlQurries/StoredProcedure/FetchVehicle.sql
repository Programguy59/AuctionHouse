CREATE PROCEDURE FetchVehicle @vehicleId INT 
AS
BEGIN

	SELECT (pro.id) as proCarId, (ppc.id) as perCarId, (tr.id) as truckId, (bu.id) as busId FROM Vehicle as V
		LEFT JOIN HeavyVehicle AS hv
			ON hv.vehicleid = v.id
		LEFT JOIN Truck AS tr
			ON tr.heavyVehicleId = hv.id
		LEFT JOIN Bus AS bu
			ON bu.heavyVehicleId = hv.id
		LEFT JOIN PersonalCar AS pc
			ON pc.vehicleid = v.id
		LEFT JOIN PrivatePersonalCar AS ppc
			ON ppc.PersonalCarId = pc.id
		LEFT JOIN ProfessionalPersonalCar AS pro
			ON pro.PersonalCarId = pc.id
		WHERE v.id = @vehicleId;
		
				
END