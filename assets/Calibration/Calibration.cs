using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Calibration : MonoBehaviour {

	public Transform circle0, circle1, circle2, circle3, circle4, circle5, circle6, circle7, circle8, circle9, circle10, circle11, circle12, circle13, circle14, circle15, circle16, circle17, circle18, circle19, circle20, circle21, circle22, circle23, circle24;
	public Camera camera;
	private static List<Transform> joints;
	public Transform topLevel, bottomLevel;
	public GUIStyle announcement;
	public Texture2D quit, redo, Continue;
	public Material matInvis;

	bool showAnnouncement;
	public static int doneCount;
	private static bool startGame, done;
	private static Queue<float> elevDiff;
	private const int elevCap = 100;

	public static float upperShift = 0f;
	public static float lowerShift = 0f;
	
	void Start ()
	{
		doneCount = 0;
		done = false;

		elevDiff = new Queue<float>(elevCap);
		for(int i = 0; i < elevCap; i++)
			elevDiff.Enqueue(0f);

		startGame = false;
		showAnnouncement = true;
		// show message for 3 seconds
		StartCoroutine(Announce(3.0f));
		
		camera.orthographic = true;
		joints = new List<Transform>();
		
		// assign circles to joints
		joints.Add((Transform)circle0);
		joints.Add((Transform)circle1);
		joints.Add((Transform)circle2);
		joints.Add((Transform)circle3);
		joints.Add((Transform)circle4);
		joints.Add((Transform)circle5);
		joints.Add((Transform)circle6);
		joints.Add((Transform)circle7);
		joints.Add((Transform)circle8);
		joints.Add((Transform)circle9);
		joints.Add((Transform)circle10);
		joints.Add((Transform)circle11);
		joints.Add((Transform)circle12);
		joints.Add((Transform)circle13);
		joints.Add((Transform)circle14);
		joints.Add((Transform)circle15);
		joints.Add((Transform)circle16);
		joints.Add((Transform)circle17);
		joints.Add((Transform)circle18);
		joints.Add((Transform)circle19);
		joints.Add((Transform)circle20);
		joints.Add((Transform)circle21);
		joints.Add((Transform)circle22);
		joints.Add((Transform)circle23);
		joints.Add((Transform)circle24);
		
		joints[0].position = camera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
		joints[0].renderer.material = matInvis;
		for(int i = 1; i < joints.Count; i++)
		{
			Vector3 screenPoint = new Vector3(0f, 0f, 0f);
			screenPoint.z = 10.0f; // distance of the plane from the camera
			joints[i].position = Camera.main.ScreenToWorldPoint(screenPoint);
			joints[i].renderer.material = matInvis;
		}
	}

	IEnumerator Announce(float waitTime)
	{
		showAnnouncement = true;
		yield return new WaitForSeconds(waitTime);
		showAnnouncement = false;
		startGame = true;
	}
	
	void Update ()
	{
		if (!done && !showAnnouncement)
		{
			HandleKinectInput(KinectJoints.jointsXY);
		}
		if (doneCount >= 2)
		{
			done = true;
		}
	}
	
	void OnGUI ()
	{
		GUI.backgroundColor = new Color(0, 0, 0, 0);

		if (showAnnouncement)
		{
			GUI.Box (new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "Stand Still\nDuring\nCalibration", announcement);
		}
		else
		{
			if (!done)
			{
				if(GUI.Button(new Rect(50, Screen.height - 150, 150, 50), quit))
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
			}
			else
			{
				if(GUI.Button(new Rect(50, Screen.height - 300, 150, 50), redo))
				{
					Application.LoadLevel(Application.loadedLevel);
				}

				if(GUI.Button(new Rect(50, Screen.height - 150, 150, 50), Continue))
				{
					Application.LoadLevel("MainScreen");
				}

				// Calibrated Shifts
				upperShift = Camera.main.ScreenToWorldPoint(new Vector3(0f,500f,0f)).y - topLevel.position.y;
				lowerShift = Camera.main.ScreenToWorldPoint(new Vector3(0f,100f,0f)).y - bottomLevel.position.y;
			}
		}
	}
	
	private void HandleKinectInput(string input)
	{
		// If joints found
		if (input != "NONE")
		{
			string[] values = input.Split(',');
			// If proper joint specs were found
			if (values.Length % 4 == 0)
			{
				//Debug.Log("Good Joint Data Found and Used!");
				int count = values.Length / 4;
				int[] node = new int[count];
				int[] x = new int[count];
				int[] y = new int[count];
				int[] z = new int[count];
				
				for(int i = 0; i < values.Length; i+=4)
					node[i/4] = int.Parse(values[i]);
				
				for(int i = 1; i < values.Length; i+=4)
					x[(i-1)/4] = (int) float.Parse(values[i]);
				
				for(int i = 2; i < values.Length; i+=4)
					y[(i-2)/4] = (int) float.Parse(values[i]);	// flip y for VS to Unity compliance
				
				for(int i = 3; i < values.Length; i+=4)
					z[(i-3)/4] = (int) float.Parse(values[i]);
				
				for(int i = 0; i < values.Length/4; i++)
				{
					Vector3 screenPoint = new Vector3(x[i], (y[i]), 0);
					screenPoint.z = z[i];
					joints[node[i]].position = screenPoint;
					//Debug.Log(node[i] + " to " + "(" + x[i] + "," + y[i] + ")");
				}
			}
			else
			{
				//Debug.Log("Improper data");
			}
		}
		else
		{
			//Debug.Log("No Joints");
		}
	}
}
