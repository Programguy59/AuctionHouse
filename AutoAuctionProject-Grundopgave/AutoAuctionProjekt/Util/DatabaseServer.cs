using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using AutoAuctionProjekt.Classes;

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
	private static SqlDataReader ExecuteQuery(string query)
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

	/// <summary>
	///     Fetch all addresses from the database.
	/// </summary>
	/// <returns>A list of all addresses.</returns>
	private static List<Auction> FetchAuctions()
	{
		var Auctions = new List<Auction>();

		const string query = "SELECT * FROM Auctions";

		using var reader = ExecuteQuery(query);

		while (reader.Read())
		{
			var id = reader.GetInt32(0);

			var streetName = reader.GetString(1);
			var streetNumber = reader.GetString(2);

			var zipCode = reader.GetString(3);
			var city = reader.GetString(4);

			var country = reader.GetString(5);

			var auction = new Auction();

            Auctions.Add(auction);
		}

		reader.Close();

		return addresses;
	}



	/// <summary>
	///     Inserts an address into the database.
	/// </summary>
	/// <param name="address">The address to insert.</param>
	/// <returns>True if the address was inserted successfully, false otherwise.</returns>
	public static bool InsertAddress(Address address)
	{
		var query =
			"INSERT INTO Addresses (StreetName, StreetNumber, City, ZipCode, Country) " +
			"OUTPUT INSERTED.Id " +
			$"VALUES ('{address.StreetName}', '{address.StreetNumber}', '{address.City}', '{address.ZipCode}', '{address.Country}')";

		var reader = ExecuteQuery(query);

		// Get the ID of the inserted order.
		while (reader.Read())
		{
			address.Id = reader.GetInt32(0);
		}

		// If the ID is DefaultId, the query must have failed.
		if (address.Id == Constants.DefaultId)
		{
			return false;
		}

		// Update the local cache.
		Database.Addresses.Add(address);

		return true;
	}

	/// <summary>
	///     Updates an address in the database.
	/// </summary>
	/// <param name="address">The address to update.</param>
	/// <returns>True if the address was updated successfully, false otherwise.</returns>
	public static bool UpdateAddress(Address address)
	{
		var query =
			"UPDATE Addresses " +
			$"SET StreetName = '{address.StreetName}', StreetNumber = '{address.StreetNumber}', City = '{address.City}', ZipCode = '{address.ZipCode}', Country = '{address.Country}' " +
			$"WHERE Id = '{address.Id}'";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		var index = Database.Addresses.FindIndex(a => a.Id == address.Id);
		Database.Addresses[index] = address;

		return true;
	}


	/// <summary>
	///     Delete an address from the database.
	/// </summary>
	/// <param name="address">The address to delete.</param>
	/// <returns>True if the address was deleted successfully, false otherwise.</returns>
	public static bool DeleteAddress(Address address)
	{
		var query =
			"DELETE FROM Addresses " +
			$"WHERE Id = '{address.Id}'";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		Database.Addresses.Remove(address);

		return true;
	}
}
