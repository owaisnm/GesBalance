using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

	public Texture2D [] appTextures = new Texture2D[12];
	public Texture2D back, quit, controlPanel;

	int AppIconHeight = 130;
	int HorizontalSpaceBetweenIcons = 60;
	int VerticalSpaceBetweenIcons = 30;
	string[,] AppNames;

	void Start () 
	{
		AppNames = new string[3,4] { { "app1", "app2", "app3", "app4" }, { "app5", "app6", "app7", "app8" }, { "app9", "app10", "app11", "app12" } };
	}
	
	void Update () {
	
	}

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(Screen.height/10, Screen.height/10, 4*Screen.width/5, 4*Screen.height/5));
		GUILayout.BeginVertical();

		// row 1
		GUILayout.BeginHorizontal ();
		if (GUILayout.Button (appTextures [0], GUILayout.Width(AppIconHeight), GUILayout.Height(AppIconHeight)))
			Application.LoadLevel ("SittingToStanding");
		GUILayout.Space(HorizontalSpaceBetweenIcons);
		GUILayout.Button(appTextures[1], GUILayout.Width(AppIconHeight), GUILayout.Height(AppIconHeight));
		GUILayout.Space(HorizontalSpaceBetweenIcons);
		GUILayout.Button(appTextures[2], GUILayout.Width(AppIconHeight), GUILayout.Height(AppIconHeight));
		GUILayout.Space(HorizontalSpaceBetweenIcons);
		GUILayout.Button(appTextures[3], GUILayout.Width(AppIconHeight), GUILayout.Height(AppIconHeight));
		GUILayout.EndHorizontal();

		// row 2
		GUILayout.Space(VerticalSpaceBetweenIcons);
		GUILayout.BeginHorizontal ();
		GUILayout.Button(appTextures[4], GUILayout.Width(AppIconHeight), GUILayout.Height(AppIconHeight));
		GUILayout.Space(HorizontalSpaceBetweenIcons);
		GUILayout.Button(appTextures[5], GUILayout.Width(AppIconHeight), GUILayout.Height(AppIconHeight));
		GUILayout.Space(HorizontalSpaceBetweenIcons);
		GUILayout.Button(appTextures[6], GUILayout.Width(AppIconHeight), GUILayout.Height(AppIconHeight));
		GUILayout.Space(HorizontalSpaceBetweenIcons);
		GUILayout.Button(appTextures[7], GUILayout.Width(AppIconHeight), GUILayout.Height(AppIconHeight));
		GUILayout.EndHorizontal();

		// row 3
		GUILayout.Space(VerticalSpaceBetweenIcons);
		GUILayout.BeginHorizontal ();
		GUILayout.Button(appTextures[8], GUILayout.Width(AppIconHeight), GUILayout.Height(AppIconHeight));
		GUILayout.Space(HorizontalSpaceBetweenIcons);
		GUILayout.Button(appTextures[9], GUILayout.Width(AppIconHeight), GUILayout.Height(AppIconHeight));
		GUILayout.Space(HorizontalSpaceBetweenIcons);
		GUILayout.Button(appTextures[10], GUILayout.Width(AppIconHeight), GUILayout.Height(AppIconHeight));
		GUILayout.Space(HorizontalSpaceBetweenIcons);
		GUILayout.Button(appTextures[11], GUILayout.Width(AppIconHeight), GUILayout.Height(AppIconHeight));
		GUILayout.EndHorizontal();
		GUILayout.EndVertical ();
		GUILayout.EndArea ();

		// if guest
		if(LoginScreen.currentID == 0)
		{
			if(GUI.Button(new Rect(20, Screen.height - 80, back.width, back.height), back))
			{
				Application.LoadLevel ("TitleScreen");
			}
		}
		// else registered patient
		else
		{
			if(GUI.Button(new Rect(20, Screen.height - 80, back.width, back.height), quit))
			{
				LoginScreen.registeredPatient.finishSession();
				Application.LoadLevel ("LoginScreen");
			}
		}

		if(GUI.Button (new Rect(Screen.width - controlPanel.width - 20, Screen.height - 80, controlPanel.width, controlPanel.height), controlPanel))
		{
			Debug.Log("nothing");
		}
	}
}
