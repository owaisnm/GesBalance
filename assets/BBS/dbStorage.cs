using UnityEngine;
using System.Collections;

public class dbStorage : MonoBehaviour {

	public static float duration;
	public static System.DateTime start;

	void Start ()
	{
		Time.timeScale = 1.0f;
		duration = 0.0f;
		start = System.DateTime.Now;
	}
	
	void Update ()
	{
		if (!SittingToStanding.done && SittingToStanding.startGame && Time.timeScale == 1.0f)
		{
			duration += 1 * Time.deltaTime;
		}
	}

	public static void RecordSession ()
	{
		string activity = "NONE";
		int grade = -1;
		
		if (Application.loadedLevelName == "SittingToStanding")
		{
			activity = "Sitting to Standing";
			grade = SittingToStanding.BBSgrade;
		}

		LoginScreen.registeredPatient.newStats (duration, activity, grade);
	}
}
