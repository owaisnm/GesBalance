using UnityEngine;
using System.Collections;

public class Visualizer : MonoBehaviour {

	public Camera camera;
	public Texture2D quit, Continue, visualizer;
	
	void Start ()
	{
		camera.orthographic = true;
	}
	
	void Update ()
	{

	}
	
	void OnGUI ()
	{
		GUI.backgroundColor = new Color(0, 0, 0, 0);

		GUI.Label (new Rect (Screen.width - 250, 50, 200, 150), visualizer);

		if(GUI.Button(new Rect(50, Screen.height - 300, 150, 50), quit))
		{
			// if guest
			if(LoginScreen.currentID == 0)
			{
				Application.LoadLevel("TitleScreen");
			}
			// else registered patient
			else
			{
				LoginScreen.registeredPatient.finishSession();
				Application.LoadLevel("LoginScreen");
			}
		}
		if(GUI.Button(new Rect(50, Screen.height - 150, 150, 50), Continue))
		{
			Application.LoadLevel("Calibration");
		}
	}
}
