using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kinect = Windows.Kinect;

public class BodySourceView : MonoBehaviour 
{
    public Material BoneMaterial;
    public GameObject BodySourceManager;

	// good/bad joint color representations, true = good, false = bad
	public static bool[] jointC;
    
    private Dictionary<ulong, GameObject> _Bodies = new Dictionary<ulong, GameObject>();
    private BodySourceManager _BodyManager;
    
    private Dictionary<Kinect.JointType, Kinect.JointType> _BoneMap = new Dictionary<Kinect.JointType, Kinect.JointType>()
    {
        { Kinect.JointType.FootLeft, Kinect.JointType.AnkleLeft },
        { Kinect.JointType.AnkleLeft, Kinect.JointType.KneeLeft },
        { Kinect.JointType.KneeLeft, Kinect.JointType.HipLeft },
        { Kinect.JointType.HipLeft, Kinect.JointType.SpineBase },
        
        { Kinect.JointType.FootRight, Kinect.JointType.AnkleRight },
        { Kinect.JointType.AnkleRight, Kinect.JointType.KneeRight },
        { Kinect.JointType.KneeRight, Kinect.JointType.HipRight },
        { Kinect.JointType.HipRight, Kinect.JointType.SpineBase },
        
        { Kinect.JointType.HandTipLeft, Kinect.JointType.HandLeft },
        { Kinect.JointType.ThumbLeft, Kinect.JointType.HandLeft },
        { Kinect.JointType.HandLeft, Kinect.JointType.WristLeft },
        { Kinect.JointType.WristLeft, Kinect.JointType.ElbowLeft },
        { Kinect.JointType.ElbowLeft, Kinect.JointType.ShoulderLeft },
        { Kinect.JointType.ShoulderLeft, Kinect.JointType.SpineShoulder },
        
        { Kinect.JointType.HandTipRight, Kinect.JointType.HandRight },
        { Kinect.JointType.ThumbRight, Kinect.JointType.HandRight },
        { Kinect.JointType.HandRight, Kinect.JointType.WristRight },
        { Kinect.JointType.WristRight, Kinect.JointType.ElbowRight },
        { Kinect.JointType.ElbowRight, Kinect.JointType.ShoulderRight },
        { Kinect.JointType.ShoulderRight, Kinect.JointType.SpineShoulder },
        
        { Kinect.JointType.SpineBase, Kinect.JointType.SpineMid },
        { Kinect.JointType.SpineMid, Kinect.JointType.SpineShoulder },
        { Kinect.JointType.SpineShoulder, Kinect.JointType.Neck },
        { Kinect.JointType.Neck, Kinect.JointType.Head },
    };

	// added by gestherapy
	void Start ()
	{
		// all joints green
		jointC = new bool[25];
		for(int i = 0; i < 25; i++)
		{
			jointC[i] = true;
		}
	}
    
    void Update () 
    {
        if (BodySourceManager == null)
        {
            return;
        }
        
        _BodyManager = BodySourceManager.GetComponent<BodySourceManager>();
        if (_BodyManager == null)
        {
            return;
        }
        
        Kinect.Body[] data = _BodyManager.GetData();
        if (data == null)
        {
            return;
        }
        
        List<ulong> trackedIds = new List<ulong>();
        foreach(var body in data)
        {
            if (body == null)
            {
                continue;
              }
                
            if(body.IsTracked)
            {
                trackedIds.Add (body.TrackingId);
            }
        }
        
        List<ulong> knownIds = new List<ulong>(_Bodies.Keys);
        
        // First delete untracked bodies
        foreach(ulong trackingId in knownIds)
        {
            if(!trackedIds.Contains(trackingId))
            {
                Destroy(_Bodies[trackingId]);
                _Bodies.Remove(trackingId);
            }
        }

        foreach(var body in data)
        {
            if (body == null)
            {
                continue;
            }
            
            if(body.IsTracked)
            {
                if(!_Bodies.ContainsKey(body.TrackingId))
                {
                    _Bodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
                }
                
                RefreshBodyObject(body, _Bodies[body.TrackingId]);
            }
        }
    }
    
    private GameObject CreateBodyObject(ulong id)
    {
        GameObject body = new GameObject("Body:" + id);
        
        for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
        {
            GameObject jointObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            
            LineRenderer lr = jointObj.AddComponent<LineRenderer>();
            lr.SetVertexCount(2);
            lr.material = BoneMaterial;
            lr.SetWidth(0.5f, 0.5f);
            
            jointObj.transform.localScale = new Vector3(0.45f, 0.45f, 0.45f);
            jointObj.name = jt.ToString();
            jointObj.transform.parent = body.transform;
        }
        
        return body;
    }
    
    // string use added by GesTherapy
	private void RefreshBodyObject(Kinect.Body body, GameObject bodyObject)
    {
		string bodyOut = "";
		for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
        {
            Kinect.Joint sourceJoint = body.Joints[jt];
            Kinect.Joint? targetJoint = null;
            
            if(_BoneMap.ContainsKey(jt))
            {
                targetJoint = body.Joints[_BoneMap[jt]];
            }
            
            Transform jointObj = bodyObject.transform.FindChild(jt.ToString());
            jointObj.position = GetVector3FromJoint(sourceJoint);

			//added
			if (jt == Kinect.JointType.ThumbRight)
			{
				bodyOut += ((int)jt).ToString() + "," + jointObj.position.x.ToString() + "," +
					jointObj.position.y.ToString() + "," + jointObj.position.z.ToString();
			}
			else
			{
				bodyOut += ((int)jt).ToString() + "," + jointObj.position.x.ToString() + "," +
					jointObj.position.y.ToString() + "," + jointObj.position.z.ToString() + ",";
			}
            
            LineRenderer lr = jointObj.GetComponent<LineRenderer>();
            if(targetJoint.HasValue)
            {
                lr.SetPosition(0, jointObj.position);
                lr.SetPosition(1, GetVector3FromJoint(targetJoint.Value));
                lr.SetColors(GetColorForState (sourceJoint.JointType), GetColorForState(targetJoint.Value.JointType));
            }
            else
            {
                lr.enabled = false;
            }
        }
		KinectJoints.jointsXY = bodyOut;
    }
    
	// changed by GesTherapy
    private static Color GetColorForState(Kinect.JointType jT)
    {
        // if during calibration, then keep skeleton white
		if (Application.loadedLevelName == "Calibration")
		{
			return Color.white;
		}
		// else if during visualizer, then keep skeleton green
		if (Application.loadedLevelName == "Visualizer")
		{
			return Color.green;
		}
		// else, if game, then green if good, red if bad
		else
		{
			if (jT==Kinect.JointType.AnkleLeft && jointC[14])
				return Color.green;
			else if (jT==Kinect.JointType.AnkleLeft && !jointC[14])
				return Color.red;
			else if (jT==Kinect.JointType.AnkleRight && jointC[18])
				return Color.green;
			else if (jT==Kinect.JointType.AnkleRight && !jointC[18])
				return Color.red;
			else if (jT==Kinect.JointType.ElbowLeft && jointC[5])
				return Color.green;
			else if (jT==Kinect.JointType.ElbowLeft && !jointC[5])
				return Color.red;
			else if (jT==Kinect.JointType.ElbowRight && jointC[9])
				return Color.green;
			else if (jT==Kinect.JointType.ElbowRight && !jointC[9])
				return Color.red;
			else if (jT==Kinect.JointType.FootLeft && jointC[15])
				return Color.green;
			else if (jT==Kinect.JointType.FootLeft && !jointC[15])
				return Color.red;
			else if (jT==Kinect.JointType.FootRight && jointC[19])
				return Color.green;
			else if (jT==Kinect.JointType.FootRight && !jointC[19])
				return Color.red;
			else if (jT==Kinect.JointType.HandLeft && jointC[7])
				return Color.green;
			else if (jT==Kinect.JointType.HandLeft && !jointC[7])
				return Color.red;
			else if (jT==Kinect.JointType.HandRight && jointC[11])
				return Color.green;
			else if (jT==Kinect.JointType.HandRight && !jointC[11])
				return Color.red;
			else if (jT==Kinect.JointType.HandTipLeft && jointC[21])
				return Color.green;
			else if (jT==Kinect.JointType.HandTipLeft && !jointC[21])
				return Color.red;
			else if (jT==Kinect.JointType.HandTipRight && jointC[23])
				return Color.green;
			else if (jT==Kinect.JointType.HandTipRight && !jointC[23])
				return Color.red;
			else if (jT==Kinect.JointType.Head && jointC[3])
				return Color.green;
			else if (jT==Kinect.JointType.Head && !jointC[3])
				return Color.red;
			else if (jT==Kinect.JointType.HipLeft && jointC[12])
				return Color.green;
			else if (jT==Kinect.JointType.HipLeft && !jointC[12])
				return Color.red;
			else if (jT==Kinect.JointType.HipRight && jointC[16])
				return Color.green;
			else if (jT==Kinect.JointType.HipRight && !jointC[16])
				return Color.red;
			else if (jT==Kinect.JointType.KneeLeft && jointC[13])
				return Color.green;
			else if (jT==Kinect.JointType.KneeLeft && !jointC[13])
				return Color.red;
			else if (jT==Kinect.JointType.KneeRight && jointC[17])
				return Color.green;
			else if (jT==Kinect.JointType.KneeRight && !jointC[17])
				return Color.red;
			else if (jT==Kinect.JointType.Neck && jointC[2])
				return Color.green;
			else if (jT==Kinect.JointType.Neck && !jointC[2])
				return Color.red;
			else if (jT==Kinect.JointType.ShoulderLeft && jointC[4])
				return Color.green;
			else if (jT==Kinect.JointType.ShoulderLeft && !jointC[4])
				return Color.red;
			else if (jT==Kinect.JointType.ShoulderRight && jointC[8])
				return Color.green;
			else if (jT==Kinect.JointType.ShoulderRight && !jointC[8])
				return Color.red;
			else if (jT==Kinect.JointType.SpineBase && jointC[0])
				return Color.green;
			else if (jT==Kinect.JointType.SpineBase && !jointC[0])
				return Color.red;
			else if (jT==Kinect.JointType.SpineMid && jointC[1])
				return Color.green;
			else if (jT==Kinect.JointType.SpineMid && !jointC[1])
				return Color.red;
			else if (jT==Kinect.JointType.SpineShoulder && jointC[20])
				return Color.green;
			else if (jT==Kinect.JointType.SpineShoulder && !jointC[20])
				return Color.red;
			else if (jT==Kinect.JointType.ThumbLeft && jointC[22])
				return Color.green;
			else if (jT==Kinect.JointType.ThumbLeft && !jointC[22])
				return Color.red;
			else if (jT==Kinect.JointType.ThumbRight && jointC[24])
				return Color.green;
			else if (jT==Kinect.JointType.ThumbRight && !jointC[24])
				return Color.red;
			else if (jT==Kinect.JointType.WristLeft && jointC[6])
				return Color.green;
			else if (jT==Kinect.JointType.WristLeft && !jointC[6])
				return Color.red;
			else if (jT==Kinect.JointType.WristRight && jointC[10])
				return Color.green;
			else if (jT==Kinect.JointType.WristRight && !jointC[10])
				return Color.red;
			else
				return Color.green;
		}
		/*switch (state)
        {
        case Kinect.TrackingState.Tracked:
            return Color.green;

        case Kinect.TrackingState.Inferred:
            return Color.red;

        default:
            return Color.black;
        }*/
    }
    
    public static Vector3 GetVector3FromJoint(Kinect.Joint joint)
    {
		// variations added by GesTherapy to contract/lift skeleton on unity screen
		if (Application.loadedLevelName == "Calibration" || Application.loadedLevelName == "Visualizer")
		{
			return new Vector3(joint.Position.X * 5.5f, (joint.Position.Y * 5.5f) + 1.5f, joint.Position.Z * 5.5f);
		}
		else
		{
			// if upper half of body
			if ( (joint.JointType >= Kinect.JointType.SpineMid && joint.JointType <= Kinect.JointType.HandRight) 
			    || (joint.JointType >= Kinect.JointType.SpineShoulder && joint.JointType <= Kinect.JointType.ThumbRight) )
				return new Vector3(joint.Position.X * 5.5f, (joint.Position.Y * 5.5f) + 1.5f + Calibration.upperShift, joint.Position.Z * 5.5f);
			// else if lower half of body
			else if ( (joint.JointType >= Kinect.JointType.KneeLeft && joint.JointType <= Kinect.JointType.FootLeft) 
			         || (joint.JointType >= Kinect.JointType.KneeRight && joint.JointType <= Kinect.JointType.FootRight) )
				return new Vector3(joint.Position.X * 5.5f, (joint.Position.Y * 5.5f) + 1.5f + Calibration.lowerShift, joint.Position.Z * 5.5f);
			// else hips or spine base
			else
				return new Vector3(joint.Position.X * 5.5f, (joint.Position.Y * 5.5f) + 1.5f, joint.Position.Z * 5.5f);
		}
    }
}
