using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Windows.Kinect;

public class KinectJoints : MonoBehaviour {

	public GameObject BodySourceManager;
	private BodySourceManager _BodyManager;

	public static string jointsXY;
	
	void Start ()
	{

	}

	void Update ()
	{
		if (BodySourceManager == null)
		{
			Debug.Log("Forgot to attach BodySourceManager to this script/object in Inspector");
			return;
		}
		
		_BodyManager = BodySourceManager.GetComponent<BodySourceManager>();
		if (_BodyManager == null)
		{
			Debug.Log("Forgot to attach BodySourceManager script to BodyManager object");
			return;
		}

		Body[] data = _BodyManager.GetData();
		if (data == null)
		{
			jointsXY = "NONE";
			//Debug.Log("no body");
			return;
		}

		// If the body is being tracked, then send data
		if(data[0].IsTracked)
		{
			// let BodySourceView take care of jointsXY
		}
		// Else send error data
		else
		{
			//jointsXY = "NONE";
			//Debug.Log("not tracked");
		}
	}
}
