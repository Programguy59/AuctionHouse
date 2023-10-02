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



		}
		catch (SqlException e)
		{
			Console.WriteLine("Failed to connect to the database!");
			Console.WriteLine("Cause: " + e.Message);

			Console.WriteLine("Press any key to retry...");
			Console.ReadKey();
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
					var numberOfSeats = reader.GetDecimal(18);
					var numberOfSleepingSpaces = reader.GetDecimal(19);
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
					vehicle = privatePersonalCar;
					return vehicle;


				}
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
            "EXEC CreateBus " + bus.Name
			+" "+ bus.Km 
			+" "+ bus.RegistrationNumber
			+" "+ bus.Year
			+" "+ bus.NewPrice
			+" "+ bus.HasTowbar
			+" "+ bus.EngineSize
			+" "+ bus.KmPerLiter
			+" "+ bus.FuelType
			+" "+ bus.VehicleDimensions.Height
			+" "+ bus.VehicleDimensions.Weight
			+" "+ bus.VehicleDimensions.Length
			+" "+ bus.NumberOfSeats
			+" "+ bus.NumberOfSleepingSpaces
			+" "+ bus.HasToilet;

		var reader = ExecuteNonQuery(query);


		// Update the local cache.
		Database.Buses.Add(bus);
	}

    public static void InsertUser(string userName,string password,Boolean CorporateUser,decimal balance,string zipCode,decimal credit, string CRNumber )
    {
		var query =
			"EXEC CreateUser " + userName
			+ ", " + password
			+ ", " + CorporateUser
			+ ", " + balance
			+ ", " + zipCode
			+ ", " + credit
			+ ", " + CRNumber;



        var reader = ExecuteNonQuery(query);

    }
}

/// <summary>
///     Updates an address in the database.
/// </summary>
/// <param name="address">The address to update.</param>
/// <returns>True if the address was updated successfully, false otherwise.</returns>
//public static bool UpdateAddress(Address address)
//{
//	var query =
//		"UPDATE Addresses " +
//		$"SET StreetName = '{address.StreetName}', StreetNumber = '{address.StreetNumber}', City = '{address.City}', ZipCode = '{address.ZipCode}', Country = '{address.Country}' " +
//		$"WHERE Id = '{address.Id}'";

//	// If the query fails, return false.
//	if (!ExecuteNonQuery(query))
//	{
//		return false;
//	}

//	// Update the local cache.
//	//var index = Database.Addresses.FindIndex(a => a.Id == address.Id);
//	//Database.Addresses[index] = address;

//	//return true;
//}


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
