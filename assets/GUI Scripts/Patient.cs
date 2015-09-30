using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Patient {
	
	// this is a patient class
	private static int ID;
	private static int sessionNum;
	public static int numPlays;
	private static float sessionTime;
	
	// This is the patient database
	public string dbName = "//GesBalance_Data//PatientDB.db";
	public string tablePrefix = "PatientID";
	public static string patientTable;
	public dbAccess db;	
	
	public Patient()
	{
		ID = 0;		// guest before assigned
		sessionNum = 0;
		numPlays = 0;
		
		sessionTime = 0f;

	}
	
	public int getID()
	{
		return ID;
	}
	
	public int getSessionNum()
	{
		return sessionNum;
	}
	
	public void beginSession(int newID, int newSessionNum /*,  string newHand*/ )
	{
		ID = newID;
		sessionNum = newSessionNum;
		patientTable = tablePrefix + ID;
	
		System.DateTime start = System.DateTime.Now;
		LoginScreen.db.UpdateSpecific(patientTable, "SessionDate", start.ToString("MM/dd/yyyy"), "SessionID", sessionNum);
		LoginScreen.db.UpdateSpecific(patientTable, "SessionStartTime", start.ToString("hh:mm tt"), "SessionID", sessionNum);

	}

	public void newStats(float timePlayed, string bbsActivity, int bbsGrade)
	{
		numPlays++;
		if(numPlays <= 100)
		{
			db = new dbAccess();
			db.OpenDB(dbName);
			
			// Get Play Duration
			string playColumn = "Play" + numPlays.ToString();
			TimeSpan duration = TimeSpan.FromSeconds((int)timePlayed);

			// Store values into DB
			string playString = duration.ToString() + "|" + bbsActivity + "|" + bbsGrade.ToString();
			db.UpdateSpecific(patientTable, playColumn, playString, "SessionID", sessionNum);
			
			// Update session stats
			sessionTime += timePlayed;
			
			db.CloseDB();
		}
	}

	public void finishSession()
	{
		ID = 0;
		
		db = new dbAccess();
		db.OpenDB(dbName);
		
		// If not accidental login
		if(sessionTime > 0)
		{
			TimeSpan duration = TimeSpan.FromSeconds((int)sessionTime);
			db.UpdateSpecific(patientTable, "SessionLength", sessionTime.ToString(), "SessionID", sessionNum);
			db.UpdateSpecific(patientTable, "NumOfPlays", numPlays.ToString(), "SessionID", sessionNum);
		}
		// If accidental login, delete the row made for this session
		else
		{
			db.DeleteRow(patientTable, "SessionID", sessionNum);
		}
		
		db.CloseDB();
	}
}
