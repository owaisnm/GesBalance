using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LoginScreen : MonoBehaviour {

	public Texture2D chooseOne, player, therapist, newUser, exit;
	public Texture2D playerLogin, UserName, PassWord, cancel, signIn;
	public Texture2D AddAPlayerOrTherapist, enterInfo, PlayerLogin;
	public Texture2D FirstName, LastName, add;

	// --------------------setup database--------------------
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
	
	public static List<string> newsessionCol;
	public static List<string> newsessionEntries;

	// --------------------setup GUI--------------------
	string username = "username";
	string password = "password";
	public static bool isPatient = true;
	public static bool isTherapist = false;
	
	int window_ID = 1;

	string newPatientFirstName = "";
	string newPatientLastName = "";
	string newPatientUsername = "";
	string newPatientPassword = "";
	string newPatientTherapist = "";

	string newTherapistFirstName = "";
	string newTherapistLastName = "";
	string newTherapistUsername = "";
	string newTherapistPassword = "";

	string PatientUsername = "";
	string PatientPassword = "";
	public static int currentID;
	public static Patient registeredPatient;
	string TherapistUsername = "";
	string TherapistPassword = "";

	public Rect loginRect;
	public Rect patientRect;
	public Rect therapistRect;
	public Rect newUserRect;
	public Rect newPatientRect;
	public Rect newTherapistRect;
	
	GUIStyle centeredStyle; 

	void Start()
	{
		// --------------------initialize database stuff--------------------
		db = new dbAccess();
		db.OpenDB(dbName);
		
		columnNames = new List<string>();
		columnValues = new List<string>();
		newpatientCol = new List<string>();
		newpatientEntries = new List<string>();
		newtableCol = new List<string>();
		newtableVal = new List<string>();
		newsessionCol = new List<string>();
		newsessionEntries = new List<string>();
		
		SetupNewPatient();
		PresetNewSessionValues();

		newpatientCol.Add ("LastName"); 
		newpatientCol.Add ("FirstName");
		newpatientCol.Add ("Therapist");
		newpatientCol.Add ("username");
		newpatientCol.Add ("password");
		
		// If first time playing, create patient table
		columnNames.Add ("PatientID");
		columnNames.Add ("LastName");
		columnNames.Add ("FirstName");
		columnNames.Add ("Therapist");
		columnNames.Add ("username");
		columnNames.Add ("password");
		columnValues.Add ("INTEGER"); 
		columnValues.Add ("text"); 
		columnValues.Add ("text"); 
		columnValues.Add ("text");
		columnValues.Add ("text");
		columnValues.Add ("text");
		db.CreateTableIfNotExist(tableName,columnNames,columnValues);
	}

	void OnGUI()
	{
		centeredStyle =  GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;

		// are you a patient or therapist
		if(window_ID == 1)
		{
			loginRect = GUILayout.Window(window_ID, new Rect(Screen.width/2 - 110, Screen.height/2 - 150, 220, 180), DoMyWindow, "");
		}

		// patient login
		if(window_ID == 2)
		{
			patientRect = GUILayout.Window(window_ID, new Rect(Screen.width/2 - 150, Screen.height/2 - 150, 300, 200), DoMyWindow, "");
		}

		// therapist login
		if(window_ID == 3)
		{
			therapistRect = GUILayout.Window(window_ID, new Rect(Screen.width/2 - 150, Screen.height/2 - 150, 300, 200), DoMyWindow, "");
		}

		// New user - Patient or Therapist?
		if(window_ID == 4)
		{
			newUserRect = GUILayout.Window(window_ID, new Rect(Screen.width/2 - 110, Screen.height/2 - 150, 220, 200), DoMyWindow, "");
		}

		// new patient sign-up
		if(window_ID == 5)
		{
			newPatientRect = GUILayout.Window(window_ID, new Rect(Screen.width/2 - 235, Screen.height/2 - 200, 460, 340), DoMyWindow, "");
		}

		// new therapist sign-up
		if(window_ID == 6)
		{
			newTherapistRect = GUILayout.Window(window_ID, new Rect(Screen.width/2 - 200, Screen.height/2 - 150, 400, 200), DoMyWindow, "");
		}

		if(GUI.Button (new Rect(Screen.width - 220, 20, newUser.width, newUser.height), newUser))
		{
			window_ID = 4;
		}

		if(GUI.Button(new Rect(20, Screen.height - 80, exit.width, exit.height), exit))
		{
			db.CloseDB();
			Application.LoadLevel ("TitleScreen");
		}
	}

	void DoMyWindow(int windowID)
	{
		// Q. Are you a player or a therapist?
		// A. Patient or Therapist
		if(windowID == 1)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Space(20);
			GUILayout.BeginVertical();
			GUILayout.Space (10);
			
			GUILayout.BeginHorizontal();
			GUILayout.Label(chooseOne, centeredStyle);
			GUILayout.EndHorizontal();
			
			GUILayout.Space(10);
			
			GUILayout.BeginVertical();
			if(GUILayout.Button(player, GUILayout.Width(player.width), GUILayout.Height(player.height)))
			{
				window_ID = 2;
			}
			
			if(GUILayout.Button(therapist, GUILayout.Height (player.height), GUILayout.Width(player.width)))
			{
				window_ID = 3;
			}
			GUILayout.EndVertical();

			GUILayout.Space(20);
			GUILayout.EndVertical();
			GUILayout.Space(20);
			GUILayout.EndHorizontal();		
		}

		// patient login
		// Q. First Name, Last Name
		// A. ...
		if(windowID == 2)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Space (20);
			GUILayout.BeginVertical();
			GUILayout.Space(10);
			
			GUILayout.Label(playerLogin, centeredStyle);

			GUILayout.BeginHorizontal();
			GUILayout.Label(UserName);
			PatientUsername = GUILayout.TextField(PatientUsername,  GUILayout.Width(200), GUILayout.Height(30));
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			GUILayout.Label(PassWord);
			PatientPassword = GUILayout.PasswordField(PatientPassword, "*"[0], 25, "box", GUILayout.Width(200), GUILayout.Height(30));
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			if(GUILayout.Button(cancel, GUILayout.Width (cancel.width), GUILayout.Height(cancel.height)))
			{
				PatientUsername = "";
				PatientPassword = "";
				window_ID = 1;
			}

			if(GUILayout.Button(signIn))
			{
				// check if patient is in database; if so, successful login
				if(db.isRecordExists(tableName, "username", PatientUsername, "password", PatientPassword))
				{
					currentID = db.GetIDWithUserPass(tableName, "PatientID", "username", PatientUsername, "password", PatientPassword);
					string patientTableName = tablePrefix + currentID;

					db.InsertRow(patientTableName, newsessionCol, newsessionEntries);
					List<int> sessID_list = new List<int>();
					sessID_list = db.GetIDValues(patientTableName, "SessionID");
					int newSessionNum = sessID_list[sessID_list.Count - 1];
					registeredPatient = new Patient();
					registeredPatient.beginSession(currentID, newSessionNum );

					db.CloseDB();
					PatientUsername = "";
					PatientPassword = "";
					Application.LoadLevel ("Visualizer");
				}

				PatientUsername = "";
				PatientPassword = "";

			}
			GUILayout.EndHorizontal();
			
			GUILayout.Space (20);
			GUILayout.EndVertical();
			GUILayout.Space (20);
			GUILayout.EndHorizontal();
		}

		// therapist login
		// Q. username, password
		// A. ...
		if(windowID == 3)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Space (20);
			GUILayout.BeginVertical();
			GUILayout.Space(10);

			GUILayout.Label ("THERAPIST LOGIN", centeredStyle);

			GUILayout.BeginHorizontal();
			GUILayout.Label (UserName);
			TherapistUsername = GUILayout.TextField (TherapistUsername, "box", GUILayout.Width(200), GUILayout.Height(30));
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			GUILayout.Label (PassWord);
			TherapistPassword = GUILayout.PasswordField(TherapistPassword, "*"[0], 25, "box", GUILayout.Width(200), GUILayout.Height(30));
			GUILayout.EndHorizontal();
			
			GUILayout.Space (5);

			GUILayout.BeginHorizontal();	
			if (GUILayout.Button (cancel, GUILayout.Width (cancel.width), GUILayout.Height(cancel.height)))
			{
				TherapistUsername = "";
				TherapistPassword = "";
				window_ID = 1;
			}
			if(GUILayout.Button(signIn , GUILayout.Width (signIn.width), GUILayout.Height(signIn.height)))
			{
				// check if therapist is in database
				// if so, successful login
				Application.LoadLevel ("TherapistScreen");
				Debug.Log ("do stuff");
			}
			GUILayout.EndHorizontal();

			GUILayout.Space(20);
			GUILayout.EndVertical();
			GUILayout.Space (20);
			GUILayout.EndHorizontal();
		}

		// new user sign up
		// Q. Add a player or a therapist
		// A. Player or Therapist or Cancel
		if(windowID == 4)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Space(20);
			GUILayout.BeginVertical();
			GUILayout.Space (10);
			
			GUILayout.BeginHorizontal();
			GUILayout.Label(AddAPlayerOrTherapist, centeredStyle);
			GUILayout.EndHorizontal();
			
			GUILayout.Space(10);
			
			GUILayout.BeginVertical();
			if(GUILayout.Button(player, GUILayout.Width (player.width), GUILayout.Height(player.height)))
			{
				window_ID = 5;
			}
			if(GUILayout.Button(therapist, GUILayout.Width (therapist.width), GUILayout.Height(therapist.height)))
			{
				window_ID = 6;
			}
			if(GUILayout.Button (cancel, GUILayout.Width (cancel.width), GUILayout.Height(cancel.height)))
			{
				window_ID = 1;
			}

			GUILayout.EndVertical();

			GUILayout.Space(20);
			GUILayout.EndVertical();
			GUILayout.Space(20);
			GUILayout.EndHorizontal();			
		}

		// new patient sign up
		// Q. First Name, Last Name, Therapist (***implement dropdown***)
		// A. ...
		if(windowID == 5)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Space(20);
			GUILayout.BeginVertical();
			GUILayout.Space(10);

			GUILayout.Label(enterInfo, centeredStyle);

			GUILayout.BeginHorizontal();
			GUILayout.Label(FirstName);
			newPatientFirstName = GUILayout.TextField(newPatientFirstName,  GUILayout.Width(200), GUILayout.Height(30));
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			GUILayout.Label(LastName);
			newPatientLastName = GUILayout.TextField(newPatientLastName,  GUILayout.Width(200), GUILayout.Height(30));
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			GUILayout.Label(therapist);
			newPatientTherapist = GUILayout.TextField(newPatientTherapist, GUILayout.Width(200), GUILayout.Height(30));
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			GUILayout.Label(UserName);
			newPatientUsername = GUILayout.TextField (newPatientUsername, GUILayout.Width(200), GUILayout.Height(30));
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			GUILayout.Label(PassWord);
			newPatientPassword = GUILayout.PasswordField(newPatientPassword, "*"[0], 25,  GUILayout.Width(200), GUILayout.Height(30));
			GUILayout.EndHorizontal();
				
			GUILayout.BeginHorizontal();
			if(GUILayout.Button(add, GUILayout.Width (add.width), GUILayout.Height(add.height)))
			{
				// add patient to list
				if(newPatientLastName != "" && newPatientFirstName != "" && newPatientTherapist != ""
				   && newPatientUsername != "" && newPatientPassword != "")
				{
					newpatientEntries.Add (newPatientLastName);
					newpatientEntries.Add (newPatientFirstName);
					newpatientEntries.Add (newPatientTherapist);
					newpatientEntries.Add (newPatientUsername);
					newpatientEntries.Add (newPatientPassword);
					db.InsertRow(tableName, newpatientCol, newpatientEntries);

					string newPatientTableName = tablePrefix + db.GetID(
						tableName, "PatientID", "LastName", newPatientLastName, "FirstName", newPatientFirstName);
					db.CreateTable(newPatientTableName, newtableCol, newtableVal);
					newPatientLastName = "";
					newPatientFirstName = "";
					newPatientTherapist = "";
					newPatientUsername = "";
					newPatientPassword = "";
					newpatientEntries.Clear();
				}
				window_ID = 1;
			}
			if(GUILayout.Button(cancel, GUILayout.Width (cancel.width), GUILayout.Height(cancel.height)))
			{
				newPatientLastName = "";
				newPatientFirstName = "";
				// newPatientPilotHand = "";
				newPatientTherapist = "";
				newPatientUsername = "";
				newPatientPassword = "";
				newpatientEntries.Clear();
				window_ID = 1;
			}
			GUILayout.EndHorizontal();

			GUILayout.Space (20);
			GUILayout.EndVertical();
			GUILayout.Space (20);
			GUILayout.EndHorizontal();
		}

		// new therapist sign up
		// Q. First Name, Last Name, username, password
		// A. ...
		if(windowID == 6)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Space (20);
			GUILayout.BeginVertical();
			GUILayout.Space(10);

			GUILayout.Label(enterInfo, centeredStyle);

			GUILayout.BeginHorizontal();
			GUILayout.Label(FirstName);
			newTherapistFirstName = GUILayout.TextField(newTherapistFirstName, GUILayout.Width(200), GUILayout.Height(30));
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			GUILayout.Label(LastName);
			newTherapistLastName = GUILayout.TextField(newTherapistLastName, GUILayout.Width(200), GUILayout.Height(30));
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			// GUILayout.Space (40);
			GUILayout.Label(UserName);
			newTherapistUsername = GUILayout.TextField (newTherapistUsername, GUILayout.Width(200), GUILayout.Height(30));
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			// GUILayout.Space (40);
			GUILayout.Label(PassWord);
			newTherapistPassword = GUILayout.PasswordField(newTherapistPassword, "*"[0], 25,  GUILayout.Width(200), GUILayout.Height(30));
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			if(GUILayout.Button(add, GUILayout.Width (add.width), GUILayout.Height(add.height)))
			{
				// add therapist to list
				window_ID = 1;
			}
			if(GUILayout.Button(cancel, GUILayout.Width (cancel.width), GUILayout.Height(cancel.height)))
			{
				window_ID = 2;
			}
			GUILayout.EndHorizontal();

			GUILayout.Space (20);
			GUILayout.EndVertical();
			GUILayout.Space (20);
			GUILayout.EndHorizontal();
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
	
	// Differs from new patient table because doesn't include Session #, which allows Session # to update itself
	void PresetNewSessionValues()
	{
		int i;
		newsessionCol.Add("SessionDate"); newsessionCol.Add("SessionStartTime"); newsessionCol.Add("SessionLength");
		newsessionCol.Add("NumOfPlays");
		// IF COLUMNS ARE CHANGED,
		// change for_limit in above function SetupNewPatient() in LoginScreen.cs and TherapistScreen.cs to 100+#col_counting_id
		// change string play = rowList[n+i] in StatisticsGUI.cs in DoMyWindow() > WindowID=1 > statsSwitch=1, with n= #col_counting_id
		for(i = 1; i <= 100; i++)
		{
			string playCol = "Play" + i.ToString();
			newsessionCol.Add(playCol);
		}
		
		newsessionEntries.Add("00/00/0000"); newsessionEntries.Add("00:00:00"); newsessionEntries.Add("00:00:00");
		newsessionEntries.Add("0");
		// Play: "Duration|ActivityName|Grade"
		for(i = 1; i <= 100; i++)
			newsessionEntries.Add("00:00:00|Activity?|-1");
	}

}
