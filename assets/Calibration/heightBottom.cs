using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class heightBottom : MonoBehaviour {

	public Transform thisLevel;
	public List<Transform> followJoints;
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
				// if joints are leveled with each other
				if ( Mathf.Abs(followJoints[0].position.y - followJoints[1].position.y) < 30)
				{
					thisLevel.renderer.material = matActive;
					float avgY = Camera.main.WorldToScreenPoint(new Vector3(0f,( followJoints[0].position.y + followJoints[1].position.y ) / 2f,0f)).y;
					jointsY.Dequeue();
					jointsY.Enqueue(avgY);
				}
				// else don't change queue and show error
				else
				{
					thisLevel.renderer.material = matBad;
				}
			}
			// Move level with joints accordingly
			float avg = Camera.main.WorldToScreenPoint(new Vector3(0f,( followJoints[0].position.y + followJoints[1].position.y ) / 2f,0f)).y;
			Vector3 screenPt = new Vector3(Screen.width/2, avg, 5f);
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
