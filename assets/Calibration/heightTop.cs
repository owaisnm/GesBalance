using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class heightTop : MonoBehaviour {

	public Transform thisLevel;
	public Transform followJoint;
	public Material matDone, matActive, matBad;
	
	public static bool done;
	private Queue<float> jointsY;
	private const int yCap = 200;
	
	void Start ()
	{
		done = false;
		thisLevel.renderer.material = matActive;
		
		// Initialize queue with varying values so that it does not appear stabilized
		jointsY = new Queue<float>(yCap);
		float start = 0f;
		for(int i = 0; i < yCap; i++)
		{
			jointsY.Enqueue(start);
			start++;
		}
	}
	
	void Update ()
	{
		if (!done)
		{
			// If level is stable then freeze it
			if ( LevelStable(jointsY) )
			{
				thisLevel.renderer.material = matDone;
				Calibration.doneCount++;
				done = true;
			}
			// else if continue gathering data
			else
			{
				thisLevel.renderer.material = matActive;
				jointsY.Dequeue();
				jointsY.Enqueue(Camera.main.WorldToScreenPoint(new Vector3(0f,followJoint.position.y,0f)).y);
			}
			// Move level with joints accordingly
			Vector3 screenPt = new Vector3(Screen.width/2, Camera.main.WorldToScreenPoint(new Vector3(0f,followJoint.position.y,0f)).y, 5f);
			thisLevel.position = Camera.main.ScreenToWorldPoint(screenPt);
		}
	}
	
	bool LevelStable (Queue<float> allY)
	{
		float[] yArray = allY.ToArray();
		float maxY = -5000f;
		float minY = 5000f;
		for (int i = 0; i < yArray.Length; i++)
		{
			if (yArray[i] > maxY)
				maxY = yArray[i];
			if (yArray[i] < minY)
				minY = yArray[i];
		}
		
		if (Mathf.Abs(maxY - minY) < 15f) {
			return true;
		}
		else {
			return false;
		}
	}
}
