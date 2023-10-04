using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using AutoAuctionProjekt.Classes;
using AutoAuctionProjekt.Classes.Vehicles;
using AutoAuctionProjekt.Classes.Vehicles.Database;
using static AutoAuctionProjekt.Classes.Vehicle;
using static AutoAuctionProjekt.Classes.HeavyVehicle;
using static AutoAuctionProjekt.Classes.PersonalCar;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Reflection.Emit;

namespace AutoAuctionProjekt.Util;

/// <summary>
///     The database server manager, used to connect to the database and execute queries.
/// </summary>

public static class DatabaseServer
{
	/// <summary>
	///     The connection to the database.
	/// </summary>
	private static SqlConnection? _connection;

	/// <summary>
	///     Load all data from the database and insert it into local lists.
	/// </summary>
	/// <param name="attempts">The number of attempts to connect to the database.</param>
	public static void Initialize(int attempts)
	{
		// Clear all local lists.


		// Attempt database connection and insert data into local lists.
		try
		{
			Console.WriteLine("Connecting to the database... (" + ++attempts + ")");
			FetchBidHistory();
            InitializeAuctions();


		}
		catch (SqlException e)
		{
			Console.WriteLine("Failed to connect to the database!");
			Console.WriteLine("Cause: " + e.Message);

			Console.WriteLine("Press any key to retry...");
			Console.WriteLine();

			// Retry connecting to the database.
			Initialize(attempts);
		}
	}

	/// <summary>
	///     Get the connection to the database, or create a new one if it doesn't exist.
	/// </summary>
	/// <returns>The connection to the database.</returns>
	private static SqlConnection GetConnection()
	{
		SqlConnectionStringBuilder sb = new()
		{
			DataSource = Constants.Sql.Host,
			InitialCatalog = Constants.Sql.Database,
			UserID = Constants.Sql.User,
			Password = Constants.Sql.Password
		};

		var connectionString = sb.ToString();

		_connection = new SqlConnection(connectionString);
		_connection.Open();

		return _connection;
	}

	/// <summary>
	///     Execute a query and return the results.
	/// </summary>
	/// <param name="query">The query to execute.</param>
	/// <returns>The results of the query.</returns>
	public static SqlDataReader ExecuteQuery(string query)
	{
		var connection = GetConnection();
		var command = new SqlCommand(query, connection);

		try
		{
			// Get the results of the query.
			return command.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch
		{
			// Dispose of the connection and command objects before re-throwing the exception.
			connection.Dispose();
			command.Dispose();

			throw;
		}
	}

	/// <summary>
	///     Execute a query that doesn't return any results.
	/// </summary>
	/// <param name="query">The query to execute.</param>
	/// <returns>True if the query effected any rows, false otherwise.</returns>
	private static bool ExecuteNonQuery(string query)
	{
		using var connection = GetConnection();
		using var command = new SqlCommand(query, connection);

		// Return true if the query effected any rows.
		return command.ExecuteNonQuery() > 0;
	}


	public static Vehicle FetchVehicle(int vechicleID)
	{
		string query = $"EXEC FetchVehicle {vechicleID}";

		using var reader = ExecuteQuery(query);



		while (reader.Read())
		{
			Vehicle vehicle;

			var TableName = reader.GetString(0);
			var id = reader.GetInt32(1);

			var carName = reader.GetString(2);
			var km = reader.GetInt32(3);
			var registrationNumber = reader.GetString(4);
			var releaseYear = reader.GetInt32(5);
			var newPrice = reader.GetDecimal(6);
			var hasTowbar = reader.GetBoolean(7);
			var engineSize = reader.GetDecimal(8);
			var kmPerLiter = reader.GetDecimal(9);

			var fuelTypeEnum = reader.GetString(10);
			;
			Enum.TryParse(fuelTypeEnum, out FuelTypeEnum fuelType);

			if (TableName == "Bus" || TableName == "Truck")
			{
				//HeavyVehicle
				var heavyId = reader.GetInt32(11);

				var height = reader.GetDecimal(13);
				var weight = reader.GetDecimal(14);
				var length = reader.GetDecimal(15);
				VehicleDimensionsStruct vehicleDimensions = new VehicleDimensionsStruct(height, weight, length);

				if (TableName == "Bus")
				{
					//Bus
					var busId = reader.GetInt32(16);
					var numberOfSeats = reader.GetInt32(18);
					var numberOfSleepingSpaces = reader.GetInt32(19);
					var hasToilet = reader.GetBoolean(20);


					Bus bus = new(carName,
								km,
								registrationNumber,
								Convert.ToUInt16(releaseYear),
								newPrice,
								hasTowbar,
								Convert.ToDouble(engineSize),
								Convert.ToUInt16(kmPerLiter),
								fuelType,
								vehicleDimensions,
								Convert.ToUInt16(numberOfSeats),
								Convert.ToUInt16(numberOfSleepingSpaces),
								hasToilet, id, heavyId, busId
								);
					
					Database.Buses.Add(bus);

                    vehicle = bus;
					return vehicle;
				}
				else
				{
					//Trucks
					var truckId = reader.GetInt32(16);
					var loadCapacity = reader.GetDecimal(18);

					Truck truck = new(carName,
								km,
								registrationNumber,
								Convert.ToUInt16(releaseYear),
								newPrice,
								hasTowbar,
								Convert.ToDouble(engineSize),
								Convert.ToUInt16(kmPerLiter),
								fuelType,
								vehicleDimensions,
								loadCapacity, id, heavyId, truckId);
					vehicle = truck;
					Database.Trucks.Add(truck);
					return vehicle;
				}
			}
			else
			{
				//PersonalCar
				var personalCarId = reader.GetInt32(11);
				var numberOfSeats = reader.GetInt32(13);
				var height = reader.GetDecimal(14);
				var width = reader.GetDecimal(15);
				var depth = reader.GetDecimal(16);
				TrunkDimentionsStruct trunkDimentionsStruct = new TrunkDimentionsStruct(height, width, depth);




				if (TableName == "ProfessionalPersonalCar")
				{
					//ProfessionalPersonalCar
					var professionalPersonalCarId = reader.GetInt32(17);
					var hasSafetyBar = reader.GetBoolean(19);
					var loadCapacity = reader.GetDecimal(20);

					ProfessionalPersonalCar professionalPersonalCar = new(carName,
								km,
								registrationNumber,
								Convert.ToUInt16(releaseYear),
								newPrice,
								Convert.ToDouble(engineSize),
								Convert.ToUInt16(kmPerLiter),
								fuelType,
								Convert.ToUInt16(numberOfSeats),
								trunkDimentionsStruct,
								hasSafetyBar,
								loadCapacity, id, personalCarId, professionalPersonalCarId);
					Database.ProfessionalPersonalCars.Add(professionalPersonalCar);
					vehicle = professionalPersonalCar;
					return vehicle;

				}
				else
				{
					//PrivatePersonalCar
					var privatePersonalCarId = reader.GetInt32(17);
					var hasIsoFixFittings = reader.GetBoolean(19);

					PrivatePersonalCar privatePersonalCar = new(carName,
								km,
								registrationNumber,
								Convert.ToUInt16(releaseYear),
								newPrice,
								hasTowbar,
								Convert.ToDouble(engineSize),
								Convert.ToUInt16(kmPerLiter),
								fuelType,
								Convert.ToUInt16(numberOfSeats),
								trunkDimentionsStruct,
								hasIsoFixFittings, id, personalCarId, privatePersonalCarId);
					Database.PrivatePersonalCars.Add(privatePersonalCar);
					vehicle = privatePersonalCar;
					return vehicle;


				}
			}
		}

		reader.Close();

		return null;
	}

	public static void FetchUser (string userName)
	{
        string query = $"EXEC FetchUser {userName}";

        using var reader = ExecuteQuery(query);
		
		
        while (reader.Read())
        {
            var corporateUser = reader.GetBoolean(1);
            var balance = reader.GetDecimal(2);
            var zipCode = reader.GetString(3);
            var CRNumber = reader.GetString(4);


			if (corporateUser == true)
			{
				var credit = reader.GetDecimal(5);
				CorporateUser corporate = new(userName, corporateUser, balance, zipCode, CRNumber, credit);
				Database.CorporateUsers.Add(corporate);
            }
			else
			{
                PrivateUser Private = new(userName, corporateUser, balance, zipCode, CRNumber);
                Database.PrivateUsers.Add(Private);
            }

        }


        
        
        reader.Close();

       
    }

	public static void InitializeAuctions()
	{
		string query = $"SELECT id FROM Auctions";
		using var reader = ExecuteQuery(query);
		List<int> auctionIds = new List<int>();

		while (reader.Read())
		{
			var auctionId = reader.GetInt32(0);
			 auctionIds.Add(auctionId);
		}

        foreach (int auctionId in auctionIds)
        {
			Database.Auctions.Add(FetchAuction(auctionId));
        }

        reader.Close();
    }


	public static void FetchBidHistory()
	{
        string query = $"EXEC FetchBids";

        using var reader = ExecuteQuery(query);

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            DateTime date = reader.GetDateTime(1);
            decimal bidAmound = reader.GetDecimal(2);
            string userName = reader.GetString(3);
            int auctionId = reader.GetInt32(4);

			BidHistory bid = new(date, bidAmound, userName, auctionId);
			if (!Database.BidHistory.Contains(bid)) { Database.BidHistory.Add(bid); }
        }

        reader.Close();
    }
    public static Auction FetchAuction(int auctionId)
    {
        string query = $"EXEC FetchAuction {auctionId}";

        using var reader = ExecuteQuery(query);

		
        while (reader.Read())
        {

            var VehicleId = reader.GetInt32(1);
            var userName = reader.GetString(2);
            var MinimumPrice = reader.GetDecimal(3);
			var isDone = reader.GetBoolean(4);
			var vehicle = FetchVehicle(VehicleId);

			FetchUser(userName);
			PrivateUser privateUser = Database.GetPrivateUserByUserName(userName);
			CorporateUser corporateUser = Database.GetCorporateUserByUserName(userName);



            if (privateUser != null)
			{
                Auction auction = new(auctionId,vehicle, privateUser, MinimumPrice);
				auction.isDone = isDone;
                return auction;
            }
            if (corporateUser != null)
            {
                Auction auction = new(auctionId,vehicle, corporateUser, MinimumPrice);
                auction.isDone = isDone;
                return auction;
            }


        }

		 
		
        reader.Close();

        return null;
    }







    /// <summary>
    ///     Inserts an bus into the database.
    /// </summary>
    /// <param name="bus">The bus to insert.</param>
    public static void InsertBus(Bus bus)
    {
        var query =
            "EXEC CreateBus '" + bus.Name
            + "', " + bus.Km
            + ", " + bus.RegistrationNumber
            + ", " + bus.Year
            + ", " + bus.NewPrice
            + ", " + bus.HasTowbar
            + ", " + bus.EngineSize
            + ", " + bus.KmPerLiter
            + ", " + bus.FuelType
            + ", " + bus.VehicleDimensions.Height
            + ", " + bus.VehicleDimensions.Weight
            + ", " + bus.VehicleDimensions.Length
            + ", " + bus.NumberOfSeats
            + ", " + bus.NumberOfSleepingSpaces
            + ", " + bus.HasToilet;

        var reader = ExecuteQuery(query);
        while (reader.Read())
        {
            var VehicleId = reader.GetInt32(0);
            var HeavyVehicleId = reader.GetInt32(1);
            var BusId = reader.GetInt32(2);
            bus.VehicleID = VehicleId;
            bus.HeavyVehicleID = HeavyVehicleId;
            bus.BusID = BusId;
            // Update the local cache.
            Database.Buses.Add(bus);
        }
        reader.Close();


    }

    public static void InsertTruck(Truck truck)
    {
		var query =
			"EXEC CreateTruck '" + truck.Name
			+ "', " + truck.Km
			+ ", " + truck.RegistrationNumber
			+ ", " + truck.Year
			+ ", " + truck.NewPrice
			+ ", " + truck.HasTowbar
			+ ", " + truck.EngineSize
			+ ", " + truck.KmPerLiter
			+ ", " + truck.FuelType
			+ ", " + truck.VehicleDimensions.Height
			+ ", " + truck.VehicleDimensions.Weight
			+ ", " + truck.VehicleDimensions.Length
			+ ", " + truck.LoadCapacity;

        var reader = ExecuteQuery(query);
        while (reader.Read())
        {
            var VehicleId = reader.GetInt32(0);
            var HeavyVehicleId = reader.GetInt32(1);
            var TruckId = reader.GetInt32(2);
            truck.VehicleID = VehicleId;
            truck.HeavyVehicleID = HeavyVehicleId;
            truck.TruckID = TruckId;
            // Update the local cache.
            Database.Trucks.Add(truck);
        }

        reader.Close();


    }

    public static void InsertPrivatePersonalCar(PrivatePersonalCar privatePersonalCar)
    {
        var query =
            "EXEC CreatePrivatePersonalCar '" + privatePersonalCar.Name
            + "', " + privatePersonalCar.Km
            + ", " + privatePersonalCar.RegistrationNumber
            + ", " + privatePersonalCar.Year
            + ", " + privatePersonalCar.NewPrice
            + ", " + privatePersonalCar.HasTowbar
            + ", " + privatePersonalCar.EngineSize
            + ", " + privatePersonalCar.KmPerLiter
            + ", " + privatePersonalCar.FuelType
            + ", " + privatePersonalCar.NumberOfSeat
            + ", " + privatePersonalCar.TrunkDimentions.Height
            + ", " + privatePersonalCar.TrunkDimentions.Width
            + ", " + privatePersonalCar.TrunkDimentions.Depth
            + ", " + privatePersonalCar.HasIsofixFittings;

        var reader = ExecuteQuery(query);
        while (reader.Read())
        {
            var VehicleId = reader.GetInt32(0);
            var PersonalCarId = reader.GetInt32(1);
            var PrivatePersonalCarId = reader.GetInt32(2);
            privatePersonalCar.VehicleID = VehicleId;
            privatePersonalCar.PersonalCarID = PersonalCarId;
            privatePersonalCar.PrivatePersonalCarID = PrivatePersonalCarId;
            // Update the local cache.
            Database.PrivatePersonalCars.Add(privatePersonalCar);
        }

		reader.Close();

    }


	public static void InsertProfessionalPersonalCar(ProfessionalPersonalCar professionalPersonalCar)
    {
        var query =
            "EXEC CreateProfessionalPersonalCar '" + professionalPersonalCar.Name
            + "', " + professionalPersonalCar.Km
            + ", " + professionalPersonalCar.RegistrationNumber
            + ", " + professionalPersonalCar.Year
            + ", " + professionalPersonalCar.NewPrice
            + ", " + professionalPersonalCar.HasTowbar
            + ", " + professionalPersonalCar.EngineSize
            + ", " + professionalPersonalCar.KmPerLiter
            + ", " + professionalPersonalCar.FuelType
            + ", " + professionalPersonalCar.NumberOfSeat
            + ", " + professionalPersonalCar.TrunkDimentions.Height
            + ", " + professionalPersonalCar.TrunkDimentions.Width
            + ", " + professionalPersonalCar.TrunkDimentions.Depth
            + ", " + professionalPersonalCar.HasSafetyBar
            + ", " + professionalPersonalCar.LoadCapacity;

        var reader = ExecuteQuery(query);
        while (reader.Read())
        {
            var VehicleId = reader.GetInt32(0);
            var PersonalCarId = reader.GetInt32(1);
            var ProfessionalPersonalCarId = reader.GetInt32(2);
            professionalPersonalCar.VehicleID = VehicleId;
            professionalPersonalCar.PersonalCarID = PersonalCarId;
            professionalPersonalCar.ProfessionalPersonalCarID = ProfessionalPersonalCarId;
            // Update the local cache.
            Database.ProfessionalPersonalCars.Add(professionalPersonalCar);
        }

        reader.Close();

    }




    public static void InsertUser(string userName,string password,bool CorporateUser,decimal balance,string zipCode,decimal credit, string CRNumber )
    {
		var query =
			"EXEC CreateUser '" + userName
			+ "', " + password
			+ ", " + CorporateUser
			+ ", " + balance
			+ ", " + zipCode
			+ ", " + credit
			+ ", " + CRNumber;



        var reader = ExecuteNonQuery(query);

    }

    public static uint InsertAuction(Vehicle vehicle, ISeller seller, decimal miniumBid)
    {
		//set to minus one to create error if auction ID not read and for all return path to be filed
		int auctionId = -1;

        var query =
			"EXEC CreateAuction " + vehicle.VehicleID
			+ ", '" + seller.UserName
			+ "', " + miniumBid
		    +", " + false;


        var reader = ExecuteQuery(query);
        while (reader.Read())
        {
            auctionId = reader.GetInt32(0);
        }
        return Convert.ToUInt32((int)auctionId);
    }

    public static void InsertBidHistory(DateTime date, decimal bidAmound, string userName, int auctionId)
    {
		var SQLDate = date.ToString("yyyy/MM/dd HH:mm:ss.FFF");

        var query =
			"EXEC CreateBidHistory '" + SQLDate
        + "', " + bidAmound
			+ ", " + userName
			+ ", " + auctionId;


        var reader = ExecuteNonQuery(query);

    }

    public static void UpdateBalance(string userName,decimal balance)
    {
        var query =
                "EXEC UpdateBalance '" + userName 
				+ "', " + balance;

        var reader = ExecuteNonQuery(query);
    }

    public static void UpdateIsDone(int auctionId,bool isDone)
    {
        var query =
                "EXEC UpdateIsDone "  + auctionId
                + "', "  + isDone;

        var reader = ExecuteNonQuery(query);
    }
}

/// <summary>
///     Updates an address in the database.
/// </summary>
/// <param name="address">The address to update.</param>
/// <returns>True if the address was updated successfully, false otherwise.</returns>



/// <summary>
///     Delete an address from the database.
/// </summary>
/// <param name="address">The address to delete.</param>
/// <returns>True if the address was deleted successfully, false otherwise.</returns>
//public static bool DeleteAddress(Address address)
//{
//	var query =
//		"DELETE FROM Addresses " +
//		$"WHERE Id = '{address.Id}'";

//	// If the query fails, return false.
//	if (!ExecuteNonQuery(query))
//	{
//		return false;
//	}

// Update the local cache.
//Database.Addresses.Remove(address);

//		return true;
//	}
//}
