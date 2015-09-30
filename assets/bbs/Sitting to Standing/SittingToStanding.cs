using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SittingToStanding : MonoBehaviour {

	public Transform circle0, circle1, circle2, circle3, circle4, circle5, circle6, circle7, circle8, circle9, circle10, circle11, circle12, circle13, circle14, circle15, circle16, circle17, circle18, circle19, circle20, circle21, circle22, circle23, circle24;
	public Camera camera;
	private static List<Transform> joints;
	public Transform elevCeiling;
	public Material matGood, matBad, matInvis;
	public Texture2D quit, complete;
	
	private static float timeElevGood, timeElevBad;
	private static float timeArmGood, timeArmBad;
	private static float timeFeetGood, timeFeetBad;
	public static bool showAnnouncement, startGame, done;
	
	private const float standHeight = 450f;
	private const float maxFeetDist = 2.0f;
	private const float maxArmXDist = 0.4f;
	private const float maxArmZDist = 0.2f;
	private static Queue<float> elevDiff;
	private const int elevCap = 100;
	public GUIStyle announcement, textStyle, goodStyle, badStyle;

	public static int BBSgrade = 0;
	
	void Start ()
	{
		done = false;
		timeElevGood = 0f;
		timeElevBad = 0f;
		timeArmGood = 0f;
		timeArmBad = 0f;
		timeFeetGood = 0f;
		timeFeetBad = 0f;
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
			//make invisible
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
			// Have elevation ceiling follow head joint
			Vector3 screenPt = new Vector3(Screen.width/2, Camera.main.WorldToScreenPoint(new Vector3(0f,circle3.position.y,0f)).y, 5f);
			elevCeiling.position = Camera.main.ScreenToWorldPoint(screenPt);
		}
	}
	
	void OnGUI ()
	{
		GUI.backgroundColor = new Color(0, 0, 0, 0);

		if (showAnnouncement)
		{
			GUI.Box (new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "Please sit,\nThen proceed to stand", announcement);
		}
		else
		{
			if (!done)
			{
				BodyElevation();
				ArmSupport();
				FeetTogether();
				
				if(GUI.Button(new Rect(50, Screen.height - 150, 150, 50), quit))
				{
					Application.LoadLevel("MainScreen");
				}
			}
			else
			{
				if(GUI.Button(new Rect(50, Screen.height - 150, 150, 50), complete))
				{
					if(LoginScreen.currentID > 0)
					{
						dbStorage.RecordSession();
					}
					Application.LoadLevel("MainScreen");
				}

				// Show Results
				string category = "Elevation \t \t \t Arm Support \t \t \t Foot Support";
				GUI.Box (new Rect (Screen.width/2 - 200, 100, 400, 30), category, textStyle);
				string good = timeElevGood + " \t \t \t " + timeArmGood + " \t \t \t " + timeFeetGood;
				GUI.Box (new Rect(Screen.width/2 - 200, 150, 400, 30), good, goodStyle);
				string bad = timeElevBad + " \t \t \t " + timeArmBad + " \t \t \t " + timeFeetBad;
				GUI.Box (new Rect(Screen.width/2 - 200, 200, 400, 30), bad, badStyle);

				// Analyze BBS grade by using proportions in %
				float elevProp = (timeElevBad*100f) / (timeElevGood+timeElevBad);
				float armProp = (timeArmBad*100f) / (timeArmGood+timeArmBad);
				float feetProp = (timeFeetBad*100f) / (timeFeetGood+timeFeetBad);
				// if elevation went well, then grade 2-4
				if (elevProp < 10f)
				{
					// if arm support not needed, then grade 4
					if (armProp < 20f)
					{
						BBSgrade = 4;
					}
					// else arm support needed, then grade 3
					else
					{
						BBSgrade = 3;
					}
				}
				// else, then grade 0-2
				else
				{
					// if arm support needed but not foot support, then grade 1-2
					if (armProp > 0f && feetProp < 10f)
					{
						BBSgrade = 2;
					}
					// else if arm support and foot support moderately needed, then grade 1
					else if(armProp > 20f && feetProp < 50f)
					{
						BBSgrade = 1;
					}
					// else maximal support needed, then grade 0
					else
					{
						BBSgrade = 0;
					}
				}

				// Show grade
				string grade = "BBS Grade: " + BBSgrade.ToString();
				GUI.Box (new Rect (Screen.width/2 - 20, 250, 40, 30), grade, textStyle);
			}
		}
	}

	private void BodyElevation()
	{
		// Head => 3
		// if head has not descended significantly
		if (Camera.main.WorldToScreenPoint(new Vector3(0f,circle3.position.y,0f)).y - elevDiff.Peek() > -15f)
		{
			elevCeiling.renderer.material = matGood;
			timeElevGood += 1 * Time.deltaTime;
		}
		// else if body has clearly descended
		else
		{
			elevCeiling.renderer.material = matBad;
			timeElevBad += 1 * Time.deltaTime;
		}

		// Update values
		elevDiff.Dequeue();
		elevDiff.Enqueue(Camera.main.WorldToScreenPoint(new Vector3(0f,circle3.position.y,0f)).y);
		//Debug.Log (Camera.main.WorldToScreenPoint(new Vector3(0f,circle3.position.y,0f)).y);

		// Check if body is confirmed standing
		float[] elevArray = elevDiff.ToArray();
		int standCount = 0;
		for(int i = 0; i < elevArray.Length; i++)
		{
			if ( elevArray[i] > standHeight )
				standCount++;
		}
		// If all data confirms standing, then done
		if ( standCount >= elevCap )
			done = true;
	}

	private void ArmSupport()
	{
		// ShoulderLeft => 4 , ElbowLeft => 5
		// if elbow and shoulder are aligned vertically
		if( (Mathf.Abs(circle4.position.z - circle5.position.z) <= maxArmZDist) &&
		    (Mathf.Abs(circle4.position.x - circle5.position.x) <= maxArmXDist) )
		{
			//circle4.renderer.material = matGood;
			//circle5.renderer.material = matGood;
			BodySourceView.jointC[4] = true;
			BodySourceView.jointC[5] = true;
			timeArmGood += 1 * Time.deltaTime;
		}
		// else if arm is bent in supporting manner
		else
		{
			//circle4.renderer.material = matBad;
			//circle5.renderer.material = matBad;
			BodySourceView.jointC[4] = false;
			BodySourceView.jointC[5] = false;
			timeArmBad += 1 * Time.deltaTime;
		}

		// ShoulderRight => 8 , ElbowRight => 9
		// if elbow and shoulder are aligned vertically
		if( (Mathf.Abs(circle8.position.z - circle9.position.z) <= maxArmZDist) &&
		    (Mathf.Abs(circle8.position.x - circle9.position.x) <= maxArmXDist) )
		{
			//circle8.renderer.material = matGood;
			//circle9.renderer.material = matGood;
			BodySourceView.jointC[8] = true;
			BodySourceView.jointC[9] = true;
			timeArmGood += 1 * Time.deltaTime;
		}
		// else if arm is bent in supporting manner
		else
		{
			//circle8.renderer.material = matBad;
			//circle9.renderer.material = matBad;
			BodySourceView.jointC[8] = false;
			BodySourceView.jointC[9] = false;
			timeArmBad += 1 * Time.deltaTime;
		}
	}
	
	private void FeetTogether()
	{
		// FootLeft => 15 , FootRight => 19
		// if feet are together
		if(Vector3.Distance(circle15.position, circle19.position) <= maxFeetDist)
		{
			//circle15.renderer.material = matGood;
			//circle19.renderer.material = matGood;
			BodySourceView.jointC[14] = true;		// left ankle
			BodySourceView.jointC[18] = true;		// right ankle
			BodySourceView.jointC[15] = true;
			BodySourceView.jointC[19] = true;
			timeFeetGood += 1 * Time.deltaTime;
		}
		// else if feet are not together
		else
		{
			//circle15.renderer.material = matBad;
			//circle19.renderer.material = matBad;
			BodySourceView.jointC[14] = false;		// left ankle
			BodySourceView.jointC[18] = false;		// right ankle
			BodySourceView.jointC[15] = false;
			BodySourceView.jointC[19] = false;
			timeFeetBad += 1 * Time.deltaTime;
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

				// shift body to bottom of screen
				//float floorShift = 50f - (((y[15]+y[19])/2) + Calibration.lowerShift);

				for(int i = 0; i < values.Length/4; i++)
				{
					Vector3 screenPoint;
					// if upper half of body
					/*if ( (i >= 1 && i <= 11) || (i >= 20 && i <= 24) )
						screenPoint = new Vector3(x[i], y[i]+Calibration.upperShift+floorShift, 0);
					// else if lower half of body
					else if ( (i >= 13 && i <= 15) || (i >= 17 && i <= 19) )
						screenPoint = new Vector3(x[i], y[i]+Calibration.lowerShift+floorShift, 0);
					// else hips or spine base
					else
						screenPoint = new Vector3(x[i], y[i]+floorShift, 0);*/
					screenPoint = new Vector3(x[i], y[i], 0);
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
