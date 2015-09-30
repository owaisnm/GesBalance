using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatisticsGUI : MonoBehaviour {
	// This is the statistics menu
	
	private int windowID = 0;
	private Rect windowRect = new Rect(15, 50, Screen.width - 25, Screen.height - 120);
	private int tabInt = 0;
	public Texture2D[] tabTexs;
	public Texture2D[] tabSelectedTexs;
	public Texture2D timeBox;
	
	public Texture2D back, box;
	private Vector2 scrollPosition = Vector2.zero;
	
	public GUIStyle barStyle, summaryStyle, summarySmallStyle, titleStyle,
							colStyle, idStyle, goodStyle, normStyle, badStyle;
	
	private string inputString = "";
	private char[] line = {'|'};
	private char[] slash = {'/'};
	private char[] percent = {'%'};
	private int statsSwitch = 0;
	private int selectedSession;
	
	// This is the patient database
	public string tablePrefix = "PatientID";
	public string dbName = "//GesBalance_Data//PatientDB.db";
	public dbAccess db;
	
	void Start()
	{
		tabInt = 0;
		statsSwitch = 0;
		
		if(LoginScreen.currentID > 0)
		{
			db = new dbAccess();
			db.OpenDB(dbName);
		}
	}
	
	void OnGUI () 
	{
		//  Creating transparent backgrounds for GUI buttons
		// Make new Color(0, 0, 0, 1) to see where the gui boxes are (no longer transparent)
		//GUI.backgroundColor = new Color(0, 0, 0, 0);
	
		GUI.backgroundColor = Color.gray;
		tabInt = GUI.Toolbar (new Rect (15, 5, 150*2, 50), tabInt, tabTexs);
		windowID = tabInt;
		switch(tabInt)
		{
			case 0:
				GUI.Button(new Rect(15-1, 5, 150, 50), tabSelectedTexs[0]);
				windowRect = GUI.Window(windowID, windowRect, DoMyWindow, "");
				break;
			case 1:
				GUI.Button(new Rect(15+150+1, 5, 150, 50), tabSelectedTexs[1]);
				windowRect = GUI.Window(windowID, windowRect, DoMyWindow, "");
				break;
			default:
				break;
		}
		
		// Outside buttons
		if ( windowID == 1 )
		{
			if ( statsSwitch == 0 )
			{
				// To view details of a session
				inputString = GUI.TextField(new Rect(Screen.width - 280, 10, 100, 30), inputString);
				if( GUI.Button(new Rect(Screen.width - 170, 10, 150, 30), "View Session Details") )
				{
					if(LoginScreen.currentID > 0)
					{
						string patientTable = tablePrefix + LoginScreen.currentID;
						int inputInt;
						// Is this even a number?
						if( int.TryParse(inputString,out inputInt) )
						{
							// Is this in the session list?
							int input = inputInt;
							List<int> ID_list = new List<int>();
							ID_list = db.GetIDValues(patientTable, "SessionID");
							if( ID_list.Contains(input) )
							{
								selectedSession = input;
								statsSwitch = 1;
							}
						}
					}
				}
			}
			else if ( statsSwitch == 1 )
			{
				// Button to go back to stats
				if (GUI.Button(new Rect(Screen.width - 170, 10, 150, 30), "Return to Sessions"))
				{
					statsSwitch = 0;
				}
			}
		}
		
		// Large box container
		GUILayout.BeginArea(new Rect (15, 50, Screen.width - 25, Screen.height - 120));
			GUILayout.Label(box);
		GUILayout.EndArea();

		// Back button to game menu
		if(GUI.Button(new Rect(60, Screen.height-60, 150, 50), back))
		{
			if( LoginScreen.currentID > 0 )
				db.CloseDB();
			Application.LoadLevel("TherapistScreen");
		}
		
	}
	
	void DoMyWindow(int ID) 
	{
		if(windowID == 0)
		{
			// Open Overall Stats Window
			
			statsSwitch = 0;
			
			// Draw statistics boxes
			
			// Total time playing
			GUI.Label (new Rect (50, 50, 300, 140), timeBox);

			// Print overall statistics
			if( LoginScreen.currentID > 0 )
			{
				// Calculate overall stats using db.GetColumnValues(patientTable, "Column Name")
				string patientTable = tablePrefix + LoginScreen.currentID;
				
				// Overall Time
				List<string> timeList = new List<string>();
				timeList = db.GetColumnValues(patientTable, "SessionLength");
				System.TimeSpan timeTotal = System.TimeSpan.Zero;
				foreach (string s in timeList)
				{
					System.TimeSpan ts = System.TimeSpan.Parse(s);
					timeTotal = timeTotal.Add(ts);
				}
				string overallTime = timeTotal.ToString();

				// Table showing highest grades for each BBS activity?
				
				// Print values on drawn boxes
				GUI.Label (new Rect (140, 120, 100, 50), overallTime, summaryStyle);
			}
		}
		
		else if (windowID == 1)
		{
			// Open Session Stats Window
			if ( statsSwitch == 0 )
			{
				// Draw any controls inside the window here

				GUI.Label (new Rect (20, 30, 20, 20), "#", colStyle);
				GUI.Label (new Rect (Screen.width/5, 30, 70, 20), "Date", colStyle);
				GUI.Label (new Rect (Screen.width*2/5, 30, 70, 20), "Time", colStyle);
				GUI.Label (new Rect (Screen.width*3/5, 30, 70, 20), "Duration", colStyle);
				GUI.Label (new Rect (Screen.width*4/5 - 12, 30, 70, 20), "# of Plays", colStyle);

				// show tabular session listing
				GUILayout.BeginArea(new Rect(10, 50, Screen.width - 40, Screen.height - 130));
				
				if( LoginScreen.currentID > 0 )
				{
					string patientTable = tablePrefix + LoginScreen.currentID;
					
					// DISPLAY SESSIONS
			        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(410));
					
						List<int> ID_list = new List<int>();
						ID_list = db.GetIDValues(patientTable, "SessionID");
						List<List<string>> listOfRows = new List<List<string>>();
						listOfRows = db.GetTableValues(patientTable);
			            for(int i = 0; i < ID_list.Count; i++)
						{
							List<string> rowList = new List<string>();
							rowList = listOfRows[i];
							GUILayout.BeginHorizontal("box");
							GUILayout.Space(1);
					        GUILayout.Label(rowList[0],idStyle,GUILayout.Width(30));	// ID
							GUILayout.FlexibleSpace();
					        GUILayout.Label(rowList[1],normStyle,GUILayout.Width(60));	// Date
							GUILayout.FlexibleSpace();
							GUILayout.Label(rowList[2],normStyle,GUILayout.Width(70));	// Start Time
							GUILayout.FlexibleSpace();
							GUILayout.Label(rowList[3],normStyle,GUILayout.Width(70));	// Session Length
							GUILayout.FlexibleSpace();
							GUILayout.Label(rowList[4],normStyle,GUILayout.Width(20));	// # of Plays
							GUILayout.FlexibleSpace();
							GUILayout.EndHorizontal();
						}
					
			        GUILayout.EndScrollView();
				}
				
				GUILayout.EndArea();
			}
			
			// Open Play Stats Window
			else if ( statsSwitch == 1)
			{
				string patientTable = tablePrefix + LoginScreen.currentID;
				
				// Draw any controls inside the window here

				GUI.Label (new Rect (50, 40, 100, 30), "BBS Total Score?", normStyle);
				GUI.Label (new Rect (50, 70, 100, 30), "BBS Activity Best Score?", normStyle);
				
				GUI.Label (new Rect (15, 100, 20, 30), "Play #", colStyle);
				GUI.Label (new Rect (Screen.width/4 - 18, 100, 50, 30), "Duration", colStyle);
				GUI.Label (new Rect (Screen.width/2, 100, 100, 30), "Activity", colStyle);
				GUI.Label (new Rect (Screen.width*3/4 - 20, 100, 50, 30), "BBS Grade", colStyle);
				
				List<string> rowList = new List<string>();
				rowList = db.GetRowValues(patientTable, "SessionID", selectedSession);
				
				// show tabular play listing
				GUILayout.BeginArea(new Rect(10, 130, Screen.width - 40, Screen.height - 70));
				
				// DISPLAY PLAYS
		        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(330));
					
					int numPlays = int.Parse( db.GetValue(patientTable, "NumOfPlays", "SessionID", selectedSession) );
					
					for(int i = 0; i < numPlays; i++)
					{
						GUILayout.BeginHorizontal("box");
						GUILayout.Space(10);
						GUILayout.Label((i+1).ToString(),idStyle,GUILayout.Width(20));	// Play #
						GUILayout.FlexibleSpace();
					
						string play = rowList[5+i];
						string[] playStats = play.Split(line);
					
				        GUILayout.Label(playStats[0],normStyle,GUILayout.Width(70));	// Duration
						GUILayout.FlexibleSpace();
					
						GUILayout.Label(playStats[1],normStyle,GUILayout.Width(100));	// BBS Activity
						GUILayout.FlexibleSpace();
					
						GUILayout.Label(playStats[2],normStyle,GUILayout.Width(40));	// BBS Grade
						GUILayout.FlexibleSpace();
						GUILayout.EndHorizontal();
					}
				
		        GUILayout.EndScrollView();
				
				GUILayout.EndArea();
			}
		}
	}
}
