using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TherapistScreen : MonoBehaviour {

	public static int currentID;
	public static Patient registeredPatient;

	public Rect mainRect; 
	public Rect newPatientRect;
	public Rect deletePatientRect;
	public Rect stopRect;
	int window_ID = 1;
	public string displayID = "";
	public GUIStyle idStyle;
	
	private Vector2 scrollPosition = Vector2.zero;
	int selectedID;
	
	string newPatientLastName = "";
	string newPatientFirstName = "";
	private string deletePatientID = "";	
	
	// Input textures for the buttons
	public Texture2D login, back, statistics, delete, id, noPatient, selectedPatient;

	// database
	public static string dbName = "//GesBalance_Data//PatientDB.db";
	public static string tableName = "Patients";
	public static string tablePrefix = "PatientID";
	public static dbAccess db;

	public static List<string> columnNames;
	public static List<string> columnValues;
	
	public static List<string> newpatientCol;
	public static List<string> newpatientEntries;
	
	public static List<string> newtableCol;
	public static List<string> newtableVal;
	
	void Start()
	{	
		selectedID = -1;
		currentID = 0;

		db = new dbAccess();
		db.OpenDB(dbName);
		
		newpatientCol = new List<string>();
		newpatientEntries = new List<string>();
		newtableCol = new List<string>();
		newtableVal = new List<string>();
		
		LoginScreen.newsessionCol = new List<string>();
		LoginScreen.newsessionEntries = new List<string>();
		
		SetupNewPatient();

		newpatientCol.Add ("LastName"); 
		newpatientCol.Add ("FirstName");
		newpatientCol.Add ("Therapist");
		newpatientCol.Add ("username");
		newpatientCol.Add ("password");
	}
	
	void OnGUI()
	{
		//  Creating transparent backgrounds for GUI buttons
		// Make new Color(0, 0, 0, 1) to see where the gui boxes are (no longer transparent)

		GUI.backgroundColor = Color.blue;
		
		// add window
		if(window_ID == 1) 			// show all patients
		{
			mainRect = GUI.Window(window_ID, new Rect(150, 60, Screen.width/2 - 100, Screen.height*2/3), DoMyWindow, "");
		}
		else if (window_ID == 2)	// show add patient form and get user input
		{
			newPatientRect = GUI.Window(window_ID, new Rect(150, 60, Screen.width/2 - 100, Screen.height*2/3), DoMyWindow, "");
		}
		else if(window_ID == 3)
		{
			deletePatientRect = GUI.Window(window_ID, new Rect(150, 60, Screen.width/2 - 100, Screen.height*2/3), DoMyWindow, "");
		}

		GUI.backgroundColor = new Color(0, 0, 0, 0);
		
		if (selectedID == -1)
		{
			GUI.Box (new Rect (Screen.width/2 + 100, 100, 300, 50), noPatient);	
		}
		else
		{
			GUI.Box (new Rect (Screen.width/2 + 100, 100, 300, 50), selectedPatient);	
			displayID = selectedID.ToString();
			GUI.Box (new Rect (Screen.width/2 + 405, 100, 50, 50), displayID, idStyle);	
		}
		
		// add "Add new patient" button
		/*if(GUI.Button(new Rect(Screen.width/2 + 150, 300, 120, 25), "Add new patient")) {
			// popup a window prompting for new patient information
			window_ID = 2;
			newPatientRect = GUI.Window(window_ID, new Rect(20, 60, Screen.width - 40, Screen.height - 130), DoMyWindow, "");
		}*/
		
		if(GUI.Button(new Rect(Screen.width/2 + 150, 400, 150, 50), delete))
		{
			// delete patient information from patientID, patientLastName, patientFirstName
			window_ID = 3;
			deletePatientRect = GUI.Window(window_ID, new Rect(20, 60, Screen.width - 40, Screen.height - 130), DoMyWindow, "");
		}

		if(GUI.Button(new Rect(60, Screen.height-60, 150, 50), back))
		{
			LoginScreen.db.CloseDB();
			Application.LoadLevel("TitleScreen");
		}
		
		if(GUI.Button(new Rect(220, Screen.height-60, 150, 50), statistics))
		{
			if(selectedID > -1)
			{
				// Stop the window from continuing to use the db to avoid conflict
				window_ID = 0;
				stopRect = GUI.Window(window_ID, new Rect(20, 60, Screen.width - 40, Screen.height - 130), DoMyWindow, "");
				
				// selected player
				currentID = selectedID;
				
				db.CloseDB();
				// open window to view statitics of selected patient
				Application.LoadLevel("Statistics");
			}			
		}
	}
	
	void DoMyWindow(int windowID) 
	{
		if(windowID == 1)
		{
			// Open Main Window

			// Draw any controls inside the window here
			GUI.Label (new Rect (7, 10, 100, 30), "ID");
			GUI.Label (new Rect (130, 10, 100, 30), "Name");

			// show tabular patient listing
			GUILayout.BeginArea(new Rect(0, 40, Screen.width/2-100, Screen.height*2/3-40));
			
			// DISPLAY PATIENTS AND SELECT BUTTONS
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(Screen.height*2/3-40));

			if ( db.GetRowCount(tableName) > 0 )
			{
				List<int> ID_list = new List<int>();
				ID_list = db.GetIDValues(tableName, "PatientID");
				for(int i = 0; i < ID_list.Count; i++)
				{
					List<string> rowList = new List<string>();
					rowList = db.GetRowValues(tableName, "PatientID", ID_list[i]);
					GUILayout.BeginHorizontal("box");
					GUILayout.Space(20);
					GUILayout.Label(rowList[0],GUILayout.Width(50));	// ID
					GUILayout.FlexibleSpace();
					string name = rowList[1] + ", " + rowList[2];
					GUILayout.Label(name, GUILayout.Width (150));		// Last, First
					GUILayout.FlexibleSpace();
					if (GUILayout.Button("Select",GUILayout.Width(150))) {
						selectedID = int.Parse(rowList[0]);
					}
					GUILayout.EndHorizontal();
				}
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}
		
		/*else if (windowID == 2)
		{
			selectedID = -1;
			
			// Open Add Patient Window
			GUILayout.BeginArea(new Rect(50, Screen.height/4, Screen.width/3, Screen.height/3));
			GUILayout.BeginVertical();
			
			GUILayout.Label("New patient information: ");
			GUILayout.Space(10);
			
			GUILayout.BeginHorizontal("box");
			GUILayout.Label("Last Name");
			newPatientLastName = GUILayout.TextField(newPatientLastName);
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal("box");
			GUILayout.Label("First Name");
			newPatientFirstName = GUILayout.TextField(newPatientFirstName);
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal("box");
			if(GUILayout.Button("Add"))
			{
				if(newPatientLastName != "" && newPatientFirstName != "")
				{
					newpatientEntries.Add(newPatientLastName);
					newpatientEntries.Add(newPatientFirstName);
					db.InsertRow(tableName, newpatientCol, newpatientEntries);
					
					string newPatientTableName = tablePrefix + db.GetID(
						tableName, "PatientID", "LastName", newPatientLastName, "FirstName", newPatientFirstName);
					db.CreateTable(newPatientTableName, newtableCol, newtableVal);
					
					newPatientLastName = "";
					newPatientFirstName = "";
					newpatientEntries.Clear();
					
					window_ID = 1;
				}
			}
			if(GUILayout.Button("Cancel"))
			{
				window_ID = 1;
			}
			GUILayout.EndHorizontal();
			GUILayout.EndVertical();
			GUILayout.EndArea();
		}*/
		else if(windowID == 3)
		{
			selectedID = -1;
			
			// Open Delete Patient Window
			GUILayout.BeginArea(new Rect(50, Screen.height/4, Screen.width/3, Screen.height/3));
			GUILayout.BeginVertical("box");

			GUILayout.Label("Enter patient information: ");
			GUILayout.Space(10);
			GUILayout.BeginHorizontal("box");
			GUILayout.Label("ID");
			deletePatientID = GUILayout.TextField(deletePatientID);
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal("box");

			if(GUILayout.Button("Delete"))
			{
				/* TO BE ADDED LATER
				 * prompt user if he is sure he would like to delete this patient
				*/
				if(deletePatientID != "")
				{
					/* TO BE ADDED LATER
					 * if ID not found, show message: "Patient ID not found!"
					*/
					int deleteID;	// if string can be converted to int, then delete
					if(int.TryParse(deletePatientID,out deleteID))
					{
						int delID = deleteID;	// to avoid NullReferenceException
						db.DeleteRow(tableName, "PatientID", delID);
						string tabletoDelete = tablePrefix + delID.ToString();
						db.DeleteTable(tabletoDelete);
					}
					deletePatientID = "";
					
					window_ID = 1;
				}
			}

			if(GUILayout.Button("Cancel"))
			{
				deletePatientID = "";
				window_ID = 1;
			}
			GUILayout.EndHorizontal();
			GUILayout.EndVertical();
			GUILayout.EndArea();			
		}
	}

	// Sets up parameters for new patient table
	void SetupNewPatient()
	{
		int i;
		newtableCol.Add("SessionID");
		newtableCol.Add("SessionDate"); newtableCol.Add("SessionStartTime"); newtableCol.Add("SessionLength");
		newtableCol.Add("NumOfPlays");
		for(i = 1; i <= 100; i++)
		{
			string playCol = "Play" + i.ToString();
			newtableCol.Add(playCol);
		}
		newtableVal.Add("INTEGER");
		for(i = 1; i < 105; i++)
			newtableVal.Add("text");
	}
}
