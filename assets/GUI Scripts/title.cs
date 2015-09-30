using UnityEngine;
using System.Collections;

public class title : MonoBehaviour {

	public Texture2D logo, login, guest, exit;
	public int spacing = 50;
	
	void OnGUI() 
	{
		//  Creating transparent backgrounds for GUI buttons
		// Make new Color(0, 0, 0, 1) to see where the gui boxes are (no longer transparent)
		GUI.backgroundColor = new Color(0, 0, 0, 0);
		
		// Container of all fields
		GUILayout.BeginArea(new Rect(Screen.width/2 -200, Screen.height/2 - 175, 400, 600));
		GUILayout.Box(logo);
		GUILayout.Space(spacing);
		
		GUILayout.BeginArea(new Rect(50, 200, 300, 250));
		// login button => registered patient is playing game
		if(GUILayout.Button (login, GUILayout.Height(100), GUILayout.Width(300))) {
			Application.LoadLevel ("LoginScreen");
		}
		
		GUILayout.Space(spacing);
		
		// guest button => guest patient is playing game
		if(GUILayout.Button (guest, GUILayout.Height(100), GUILayout.Width(300))) {
			// LoginGUI.currentID = 0;
			// *** 	set LoginScree.currentID = 0 ****, so system 
			//		differentiate between user and guest
			Application.LoadLevel ("Visualizer");
		}
		
		GUILayout.EndArea();
		GUILayout.EndArea();
		
		if(GUI.Button(new Rect(Screen.width - 60 - 150, 10 , 150, 50), exit))
		{
			Application.Quit();
		}
	}
}

