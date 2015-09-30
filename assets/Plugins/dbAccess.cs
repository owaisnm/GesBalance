using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite; // we import sqlite

public class dbAccess {

	// variables for basic query access
    private string connection;
	private SqliteConnection dbcon;
	private SqliteCommand dbcmd;
	private SqliteDataReader reader;
 
 	// Open a Sqlite database, or create one if not yet made
    public void OpenDB(string p)
    {
    	connection = "URI=file:" + p; // we set the connection to our database
    	//dbcon = new SqliteConnection(connection);
    	//dbcon.Open();
    }
    
    // Run a basic Sqlite query
    public SqliteDataReader BasicQuery(string q)
    {
    	using( SqliteConnection dbcon = new SqliteConnection(connection) )
		{
			dbcon.Open();
			using( SqliteCommand dbcmd = new SqliteCommand(q, dbcon) )
			{
				using( SqliteDataReader reader = dbcmd.ExecuteReader() )
				{
					return reader;
				}
			}
		}
		/*dbcmd = dbcon.CreateCommand(); // create empty command
        dbcmd.CommandText = q; // fill the command
        reader = dbcmd.ExecuteReader(); // execute command which returns a reader
        return reader; // return the reader*/
    }
    
    // Create a table, name, column array, column type array
    public void CreateTable(string name, List<string> col, List<string> colType)
    {
    	string query;
        query  = "CREATE TABLE " + name + "(" + col[0] + " " + colType[0] + " PRIMARY KEY AUTOINCREMENT";
        for(int i=1; i<col.Count; i++)
        {
            query += ", " + col[i] + " " + colType[i];
        }
        query += ")";
		using( SqliteConnection dbcon = new SqliteConnection(connection) )
		{
			dbcon.Open();
			using( SqliteCommand dbcmd = new SqliteCommand(query, dbcon) )
			{
				dbcmd.ExecuteNonQuery();
			}
		}
    }
    
    // Create a table if and only if it doesn't exist
    public void CreateTableIfNotExist(string name, List<string> col, List<string> colType)
    {
    	string query;
        query  = "CREATE TABLE IF NOT EXISTS " + name + "(" + col[0] + " " + colType[0] + " PRIMARY KEY AUTOINCREMENT";
        for(var i=1; i<col.Count; i++)
        {
            query += ", " + col[i] + " " + colType[i];
        }
        query += ")";
        using( SqliteConnection dbcon = new SqliteConnection(connection) )
		{
			dbcon.Open();
			using( SqliteCommand dbcmd = new SqliteCommand(query, dbcon) )
			{
				dbcmd.ExecuteNonQuery();
			}
		}
    }
    
    // This public void deletes the table from disk
    public void DeleteTable(string tableName)
    {
    	string query;
    	query = "DROP TABLE IF EXISTS " + tableName;
    	using( SqliteConnection dbcon = new SqliteConnection(connection) )
		{
			dbcon.Open();
			using( SqliteCommand dbcmd = new SqliteCommand(query, dbcon) )
			{
				dbcmd.ExecuteNonQuery();
			}
		}
    }
    
    // Get number of rows in table
    public int GetRowCount(string tableName)
    {
    	string query;
    	query = "SELECT COUNT(*) AS rowCount " + " FROM " + tableName;
		using( SqliteConnection dbcon = new SqliteConnection(connection) )
		{
			dbcon.Open();
			using( SqliteCommand dbcmd = new SqliteCommand(query, dbcon) )
			{
				using( SqliteDataReader reader = dbcmd.ExecuteReader() )
				{
					reader.Read();
					return (reader.GetInt32(0));
				}
			}
		}
    }
    
    // Get value from row and column
    public string GetValue(string tableName, string colName, string IDcol, int IDvalue)
    {
    	string query;
        query = "SELECT " + colName + " FROM " + tableName + " WHERE " + IDcol + "=" + IDvalue.ToString();
		using( SqliteConnection dbcon = new SqliteConnection(connection) )
		{
			dbcon.Open();
			using( SqliteCommand dbcmd = new SqliteCommand(query, dbcon) )
			{
				using( SqliteDataReader reader = dbcmd.ExecuteReader() )
				{
					reader.Read();
					return (reader.GetString(0));
				}
			}
		}
    }
    
    // Get row ID from other column values
    public int GetID(string tableName, string IDcol, string col1, string col1Entry, string col2, string col2Entry /*, string col3, string col3Entry */)
    {
    	string query;
		query = "SELECT " + IDcol + " FROM " + tableName + " WHERE " + col1 + "='" + col1Entry + "' AND " + col2 + "='" + col2Entry + "'"; // AND " + col3 + "='" + col3Entry + "'";
        using( SqliteConnection dbcon = new SqliteConnection(connection) )
		{
			dbcon.Open();
			using( SqliteCommand dbcmd = new SqliteCommand(query, dbcon) )
			{
				using( SqliteDataReader reader = dbcmd.ExecuteReader() )
				{
					reader.Read();
					return (reader.GetInt32(0));
				}
			}
		}
    }

	// Get row ID from TWO other column values
	public int GetIDWithUserPass(string tableName, string IDcol, string col1, string col1Entry, string col2, string col2Entry)
	{
		string query;
		query = "SELECT " + IDcol + " FROM " + tableName + " WHERE " + col1 + "='" + col1Entry + "' AND " + col2 + "='" + col2Entry  + "'";
		using( SqliteConnection dbcon = new SqliteConnection(connection) )
		{
			dbcon.Open();
			using( SqliteCommand dbcmd = new SqliteCommand(query, dbcon) )
			{
				using( SqliteDataReader reader = dbcmd.ExecuteReader() )
				{
					reader.Read();
					return (reader.GetInt32(0));
				}
			}
		}
	}

	public bool isRecordExists( string tableName, string col1, string col1Entry, string col2, string col2Entry) 
	{ 
		bool result = false;
		string  query = "SELECT * FROM " + tableName + " WHERE " +  col1 + "='" + col1Entry + "' AND " + col2 + "='" + col2Entry + "'";
		using (SqliteConnection dbcon = new SqliteConnection( connection ))
		{
			dbcon.Open();
			using (SqliteCommand dbcmd = new SqliteCommand( query, dbcon ))
			{
				using (SqliteDataReader reader = dbcmd.ExecuteReader())
				{
					if (reader.Read())
						result = true;
					reader.Close(); 
				}
			}
		} 
		return result; 
	} 

    
    // Get all values from a column in table
    public List<string> GetColumnValues(string tableName, string column)
    {
    	string query;
        query = "SELECT " + column + " FROM " + tableName;
		using( SqliteConnection dbcon = new SqliteConnection(connection) )
		{
			dbcon.Open();
			using( SqliteCommand dbcmd = new SqliteCommand(query, dbcon) )
			{
				using( SqliteDataReader reader = dbcmd.ExecuteReader() )
				{
			        List<string> readList = new List<string>();
			        while(reader.Read()){
			            readList.Add(reader.GetValue(0).ToString());
			        }
			        return readList;
				}
			}
		}
    }
	
	// Get all values from a column in table
    public List<int> GetIDValues(string tableName, string IDcolumn)
    {
    	string query;
        query = "SELECT " + IDcolumn + " FROM " + tableName;
		using( SqliteConnection dbcon = new SqliteConnection(connection) )
		{
			dbcon.Open();
			using( SqliteCommand dbcmd = new SqliteCommand(query, dbcon) )
			{
				using( SqliteDataReader reader = dbcmd.ExecuteReader() )
				{
			        List<int> readList = new List<int>();
			        while(reader.Read()){
			            readList.Add(reader.GetInt32(0));
			        }
			        return readList;
				}
			}
		}
    }
    
    // Get all values from a row in table
    public List<string> GetRowValues(string tableName, string IDcol, int IDvalue)
    {
    	string query;
        query = "SELECT * FROM " + tableName + " WHERE " + IDcol + "=" + IDvalue.ToString();
		using( SqliteConnection dbcon = new SqliteConnection(connection) )
		{
			dbcon.Open();
			using( SqliteCommand dbcmd = new SqliteCommand(query, dbcon) )
			{
				using( SqliteDataReader reader = dbcmd.ExecuteReader() )
				{
			        List<string> readList = new List<string>();
			        while(reader.Read()){
			        	for (int i = 0; i < reader.FieldCount; i++) {
			        		readList.Add(reader.GetValue(i).ToString());
			        	}
			        }
			        return readList;
				}
			}
		}
    }
	
	// Get all values in table
    public List<List<string>> GetTableValues(string tableName)
    {
    	string query;
        query = "SELECT * FROM " + tableName;
		using( SqliteConnection dbcon = new SqliteConnection(connection) )
		{
			dbcon.Open();
			using( SqliteCommand dbcmd = new SqliteCommand(query, dbcon) )
			{
				using( SqliteDataReader reader = dbcmd.ExecuteReader() )
				{
			        List<List<string>> readTable = new List<List<string>>();
			        while(reader.Read()){
						List<string> readList = new List<string>();
			        	for (int i = 0; i < reader.FieldCount; i++) {
			        		readList.Add(reader.GetValue(i).ToString());
			        	}
						readTable.Add(readList);
			        }
			        return readTable;
				}
			}
		}
    }
    
    // Insert new row of values
    public void InsertRow(string tableName, List<string> col, List<string> values)
    {
    	string query;
        query = "INSERT INTO " + tableName + " (" + col[0];
        for(int i=1; i<col.Count; i++)
        {
        	query += ", " + col[i];
        }
        query += ") VALUES ('" + values[0];
        for(int i=1; i<values.Count; i++)
        {
            query += "','" + values[i];
        }
        query += "')";
        using( SqliteConnection dbcon = new SqliteConnection(connection) )
		{
			dbcon.Open();
			using( SqliteCommand dbcmd = new SqliteCommand(query, dbcon) )
			{
				dbcmd.ExecuteNonQuery();
			}
		}
    }
    
    // Basic update of a value
    public void UpdateSpecific(string tableName, string colName, string newValue, string IDcol, int IDvalue)
    {
        string query;
        query = "UPDATE " + tableName + " SET " + colName + "='" + newValue + "' WHERE " + IDcol + "=" + IDvalue.ToString();
        using( SqliteConnection dbcon = new SqliteConnection(connection) )
		{
			dbcon.Open();
			using( SqliteCommand dbcmd = new SqliteCommand(query, dbcon) )
			{
				dbcmd.ExecuteNonQuery();
			}
		}
    }
    
    // Delete row from table
    public void DeleteRow(string tableName, string IDcol, int IDvalue)
    {
    	string query;
        query = "DELETE FROM " + tableName + " WHERE " + IDcol + "=" + IDvalue.ToString();
        using( SqliteConnection dbcon = new SqliteConnection(connection) )
		{
			dbcon.Open();
			using( SqliteCommand dbcmd = new SqliteCommand(query, dbcon) )
			{
				dbcmd.ExecuteNonQuery();
			}
		}
    }
    
    // Close database after use
    public void CloseDB()
    {
        if (reader != null) {
			reader.Close();
		}
		reader = null;
		if (dbcmd != null) {
			dbcmd.Cancel();
		}
		dbcmd = null;
		if (dbcon != null) {
			dbcon.Close();
		}
		dbcon = null;
    }

}