using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
	
	#region Enums
	
	//
	// Windows.Kinect.KinectCapabilities
	//
	public enum KinectCapabilities : uint
	{
		None                                     =0,
		Vision                                   =1,
		Audio                                    =2,
		Face                                     =4,
		Expressions                              =8,
		Gamechat                                 =16,
	}
	
	//
	// Windows.Kinect.FrameSourceTypes
	//
	public enum FrameSourceTypes : uint
	{
		None                                     =0,
		Color                                    =1,
		Infrared                                 =2,
		LongExposureInfrared                     =4,
		Depth                                    =8,
		BodyIndex                                =16,
		Body                                     =32,
		Audio                                    =64,
	}
	
	//
	// Windows.Kinect.ColorImageFormat
	//
	public enum ColorImageFormat : int
	{
		None                                     =0,
		Rgba                                     =1,
		Yuv                                      =2,
		Bgra                                     =3,
		Bayer                                    =4,
		Yuy2                                     =5,
	}
	
	//
	// Windows.Kinect.HandState
	//
	public enum HandState : int
	{
		Unknown                                  =0,
		NotTracked                               =1,
		Open                                     =2,
		Closed                                   =3,
		Lasso                                    =4,
	}
	
	//
	// Windows.Kinect.Expression
	//
	public enum Expression : int
	{
		Neutral                                  =0,
		Happy                                    =1,
	}
	
	//
	// Windows.Kinect.DetectionResult
	//
	public enum DetectionResult : int
	{
		Unknown                                  =0,
		No                                       =1,
		Maybe                                    =2,
		Yes                                      =3,
	}
	
	//
	// Windows.Kinect.TrackingConfidence
	//
	public enum TrackingConfidence : int
	{
		Low                                      =0,
		High                                     =1,
	}
	
	//
	// Windows.Kinect.Activity
	//
	public enum Activity : int
	{
		EyeLeftClosed                            =0,
		EyeRightClosed                           =1,
		MouthOpen                                =2,
		MouthMoved                               =3,
		LookingAway                              =4,
	}
	
	//
	// Windows.Kinect.Appearance
	//
	public enum Appearance : int
	{
		WearingGlasses                           =0,
	}
	
	//
	// Windows.Kinect.JointType
	//
	public enum JointType : int
	{
		SpineBase                                =0,
		SpineMid                                 =1,
		Neck                                     =2,
		Head                                     =3,
		ShoulderLeft                             =4,
		ElbowLeft                                =5,
		WristLeft                                =6,
		HandLeft                                 =7,
		ShoulderRight                            =8,
		ElbowRight                               =9,
		WristRight                               =10,
		HandRight                                =11,
		HipLeft                                  =12,
		KneeLeft                                 =13,
		AnkleLeft                                =14,
		FootLeft                                 =15,
		HipRight                                 =16,
		KneeRight                                =17,
		AnkleRight                               =18,
		FootRight                                =19,
		SpineShoulder                            =20,
		HandTipLeft                              =21,
		ThumbLeft                                =22,
		HandTipRight                             =23,
		ThumbRight                               =24,
	}
	
	//
	// Windows.Kinect.TrackingState
	//
	public enum TrackingState : int
	{
		NotTracked                               =0,
		Inferred                                 =1,
		Tracked                                  =2,
	}
	
	//
	// Windows.Kinect.FrameEdges
	//
	public enum FrameEdges : uint
	{
		None                                     =0,
		Right                                    =1,
		Left                                     =2,
		Top                                      =4,
		Bottom                                   =8,
	}
	
	//
	// Windows.Kinect.FrameCapturedStatus
	//
	public enum FrameCapturedStatus : int
	{
		Unknown                                  =0,
		Queued                                   =1,
		Dropped                                  =2,
	}
	
	//
	// Windows.Kinect.AudioBeamMode
	//
	public enum AudioBeamMode : int
	{
		Automatic                                =0,
		Manual                                   =1,
	}
	
	#endregion // Enums
	
	#region Structs
	
	//
	// Windows.Kinect.Vector4
	//
	[RootSystem.Runtime.InteropServices.StructLayout(RootSystem.Runtime.InteropServices.LayoutKind.Sequential)]
	public struct Vector4
	{
		public float X;
		public float Y;
		public float Z;
		public float W;
	}
	
	//
	// Windows.Kinect.ColorSpacePoint
	//
	[RootSystem.Runtime.InteropServices.StructLayout(RootSystem.Runtime.InteropServices.LayoutKind.Sequential)]
	public struct ColorSpacePoint
	{
		public float X;
		public float Y;
	}
	
	//
	// Windows.Kinect.DepthSpacePoint
	//
	[RootSystem.Runtime.InteropServices.StructLayout(RootSystem.Runtime.InteropServices.LayoutKind.Sequential)]
	public struct DepthSpacePoint
	{
		public float X;
		public float Y;
	}
	
	//
	// Windows.Kinect.CameraSpacePoint
	//
	[RootSystem.Runtime.InteropServices.StructLayout(RootSystem.Runtime.InteropServices.LayoutKind.Sequential)]
	public struct CameraSpacePoint
	{
		public float X;
		public float Y;
		public float Z;
	}
	
	//
	// Windows.Kinect.Joint
	//
	[RootSystem.Runtime.InteropServices.StructLayout(RootSystem.Runtime.InteropServices.LayoutKind.Sequential)]
	public struct Joint
	{
		public Windows.Kinect.JointType JointType;
		public Windows.Kinect.CameraSpacePoint Position;
		public Windows.Kinect.TrackingState TrackingState;
	}
	
	//
	// Windows.Kinect.JointOrientation
	//
	[RootSystem.Runtime.InteropServices.StructLayout(RootSystem.Runtime.InteropServices.LayoutKind.Sequential)]
	public struct JointOrientation
	{
		public Windows.Kinect.JointType JointType;
		public Windows.Kinect.Vector4 Orientation;
	}
	
	#endregion // Structs
	
	#region Classes
	
	//
	// Windows.Kinect.KinectSensor
	//
	public partial class KinectSensor
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal KinectSensor(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_KinectSensor_AddRefObject(ref _pNative);
		}
		
		~KinectSensor()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_KinectSensor_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_KinectSensor_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<KinectSensor>(_pNative);
			Windows_Kinect_KinectSensor_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(KinectSensor other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator KinectSensor(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<KinectSensor>(other);
			if(obj == null)
			{
				obj = new KinectSensor(other);
				Helper.NativeObjectCache.AddObject<KinectSensor>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_AudioSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.AudioSource AudioSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("KinectSensor");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_AudioSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.AudioSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.AudioSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.AudioSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_BodyFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.BodyFrameSource BodyFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("KinectSensor");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_BodyFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.BodyFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.BodyFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.BodyFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_BodyIndexFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.BodyIndexFrameSource BodyIndexFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("KinectSensor");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_BodyIndexFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.BodyIndexFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.BodyIndexFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.BodyIndexFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_ColorFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.ColorFrameSource ColorFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("KinectSensor");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_ColorFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.ColorFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.ColorFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.ColorFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_CoordinateMapper(RootSystem.IntPtr pNative);
		public  Windows.Kinect.CoordinateMapper CoordinateMapper
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("KinectSensor");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_CoordinateMapper(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.CoordinateMapper>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.CoordinateMapper(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.CoordinateMapper>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_DepthFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.DepthFrameSource DepthFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("KinectSensor");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_DepthFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.DepthFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.DepthFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.DepthFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_InfraredFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.InfraredFrameSource InfraredFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("KinectSensor");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_InfraredFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.InfraredFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.InfraredFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.InfraredFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_KinectSensor_get_IsAvailable(RootSystem.IntPtr pNative);
		public  bool IsAvailable
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("KinectSensor");
				}
				
				return Windows_Kinect_KinectSensor_get_IsAvailable(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_KinectSensor_get_IsOpen(RootSystem.IntPtr pNative);
		public  bool IsOpen
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("KinectSensor");
				}
				
				return Windows_Kinect_KinectSensor_get_IsOpen(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.KinectCapabilities Windows_Kinect_KinectSensor_get_KinectCapabilities(RootSystem.IntPtr pNative);
		public  Windows.Kinect.KinectCapabilities KinectCapabilities
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("KinectSensor");
				}
				
				return Windows_Kinect_KinectSensor_get_KinectCapabilities(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_LongExposureInfraredFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.LongExposureInfraredFrameSource LongExposureInfraredFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("KinectSensor");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_LongExposureInfraredFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.LongExposureInfraredFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.LongExposureInfraredFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.LongExposureInfraredFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_UniqueKinectId(RootSystem.IntPtr pNative);
		public  string UniqueKinectId
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("KinectSensor");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_UniqueKinectId(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				return RootSystem.Runtime.InteropServices.Marshal.PtrToStringUni(objectPointer);
			}
		}
		
		
		// Events
		[RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		public delegate void Windows_Kinect_IsAvailableChangedEventArgs_Delegate(Windows.Kinect.IsAvailableChangedEventArgs args);
		private delegate void _Windows_Kinect_IsAvailableChangedEventArgs_Delegate(RootSystem.IntPtr args);
		private static List<Windows_Kinect_IsAvailableChangedEventArgs_Delegate> Windows_Kinect_IsAvailableChangedEventArgs_Delegate_callbacks = new List<Windows_Kinect_IsAvailableChangedEventArgs_Delegate>();
		[AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_IsAvailableChangedEventArgs_Delegate))]
		private static void Windows_Kinect_IsAvailableChangedEventArgs_Delegate_Handler(RootSystem.IntPtr result)
		{
			lock(Windows_Kinect_IsAvailableChangedEventArgs_Delegate_callbacks)
			{
				foreach(var func in Windows_Kinect_IsAvailableChangedEventArgs_Delegate_callbacks)
				{
					if(func != null)
					{
						func((Windows.Kinect.IsAvailableChangedEventArgs)result);
					}
				}
			}
		}
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_KinectSensor_add_IsAvailableChanged(_Windows_Kinect_IsAvailableChangedEventArgs_Delegate eventCallback, bool unsubscribe);
		public  event Windows_Kinect_IsAvailableChangedEventArgs_Delegate IsAvailableChanged
		{
			add
			{
				lock (Windows_Kinect_IsAvailableChangedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_IsAvailableChangedEventArgs_Delegate_callbacks.Add(value);
					if(Windows_Kinect_IsAvailableChangedEventArgs_Delegate_callbacks.Count == 1)
					{
						Windows_Kinect_KinectSensor_add_IsAvailableChanged(Windows_Kinect_IsAvailableChangedEventArgs_Delegate_Handler, false);
					}
				}
			}
			remove
			{
				lock (Windows_Kinect_IsAvailableChangedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_IsAvailableChangedEventArgs_Delegate_callbacks.Remove(value);
					if(Windows_Kinect_IsAvailableChangedEventArgs_Delegate_callbacks.Count == 0)
					{
						Windows_Kinect_KinectSensor_add_IsAvailableChanged(Windows_Kinect_IsAvailableChangedEventArgs_Delegate_Handler, true);
					}
				}
			}
		}
		
		
		// Static Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_GetDefault();
		public static Windows.Kinect.KinectSensor GetDefault()
		{
			RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_GetDefault();
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.KinectSensor>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.KinectSensor(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.KinectSensor>(objectPointer, obj);
			}
			
			return obj;
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_KinectSensor_Open(RootSystem.IntPtr pNative);
		public void Open()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("KinectSensor");
			}
			
			Windows_Kinect_KinectSensor_Open(_pNative);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_KinectSensor_Close(RootSystem.IntPtr pNative);
		public void Close()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("KinectSensor");
			}
			
			Windows_Kinect_KinectSensor_Close(_pNative);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_OpenMultiSourceFrameReader(RootSystem.IntPtr pNative, Windows.Kinect.FrameSourceTypes enabledFrameSourceTypes);
		public Windows.Kinect.MultiSourceFrameReader OpenMultiSourceFrameReader(Windows.Kinect.FrameSourceTypes enabledFrameSourceTypes)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("KinectSensor");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_OpenMultiSourceFrameReader(_pNative, enabledFrameSourceTypes);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.MultiSourceFrameReader>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.MultiSourceFrameReader(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.MultiSourceFrameReader>(objectPointer, obj);
			}
			
			return obj;
		}
		
	}
	
	//
	// Windows.Kinect.IsAvailableChangedEventArgs
	//
	public partial class IsAvailableChangedEventArgs
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal IsAvailableChangedEventArgs(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_IsAvailableChangedEventArgs_AddRefObject(ref _pNative);
		}
		
		~IsAvailableChangedEventArgs()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_IsAvailableChangedEventArgs_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_IsAvailableChangedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<IsAvailableChangedEventArgs>(_pNative);
			Windows_Kinect_IsAvailableChangedEventArgs_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(IsAvailableChangedEventArgs other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator IsAvailableChangedEventArgs(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<IsAvailableChangedEventArgs>(other);
			if(obj == null)
			{
				obj = new IsAvailableChangedEventArgs(other);
				Helper.NativeObjectCache.AddObject<IsAvailableChangedEventArgs>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_IsAvailableChangedEventArgs_get_IsAvailable(RootSystem.IntPtr pNative);
		public  bool IsAvailable
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("IsAvailableChangedEventArgs");
				}
				
				return Windows_Kinect_IsAvailableChangedEventArgs_get_IsAvailable(_pNative);
			}
		}
		
	}
	
	//
	// Windows.Kinect.ColorFrameSource
	//
	public partial class ColorFrameSource
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal ColorFrameSource(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_ColorFrameSource_AddRefObject(ref _pNative);
		}
		
		~ColorFrameSource()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrameSource_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrameSource_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<ColorFrameSource>(_pNative);
			Windows_Kinect_ColorFrameSource_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(ColorFrameSource other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator ColorFrameSource(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<ColorFrameSource>(other);
			if(obj == null)
			{
				obj = new ColorFrameSource(other);
				Helper.NativeObjectCache.AddObject<ColorFrameSource>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_ColorFrameSource_get_FrameDescription(RootSystem.IntPtr pNative);
		public  Windows.Kinect.FrameDescription FrameDescription
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("ColorFrameSource");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_ColorFrameSource_get_FrameDescription(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.FrameDescription>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.FrameDescription(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.FrameDescription>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_ColorFrameSource_get_IsActive(RootSystem.IntPtr pNative);
		public  bool IsActive
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("ColorFrameSource");
				}
				
				return Windows_Kinect_ColorFrameSource_get_IsActive(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_ColorFrameSource_get_KinectSensor(RootSystem.IntPtr pNative);
		public  Windows.Kinect.KinectSensor KinectSensor
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("ColorFrameSource");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_ColorFrameSource_get_KinectSensor(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.KinectSensor>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.KinectSensor(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.KinectSensor>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		
		// Events
		[RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		public delegate void Windows_Kinect_FrameCapturedEventArgs_Delegate(Windows.Kinect.FrameCapturedEventArgs args);
		private delegate void _Windows_Kinect_FrameCapturedEventArgs_Delegate(RootSystem.IntPtr args);
		private static List<Windows_Kinect_FrameCapturedEventArgs_Delegate> Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks = new List<Windows_Kinect_FrameCapturedEventArgs_Delegate>();
		[AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_FrameCapturedEventArgs_Delegate))]
		private static void Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler(RootSystem.IntPtr result)
		{
			lock(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
			{
				foreach(var func in Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					if(func != null)
					{
						func((Windows.Kinect.FrameCapturedEventArgs)result);
					}
				}
			}
		}
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrameSource_add_FrameCaptured(_Windows_Kinect_FrameCapturedEventArgs_Delegate eventCallback, bool unsubscribe);
		public  event Windows_Kinect_FrameCapturedEventArgs_Delegate FrameCaptured
		{
			add
			{
				lock (Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Add(value);
					if(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Count == 1)
					{
						Windows_Kinect_ColorFrameSource_add_FrameCaptured(Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, false);
					}
				}
			}
			remove
			{
				lock (Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Remove(value);
					if(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Count == 0)
					{
						Windows_Kinect_ColorFrameSource_add_FrameCaptured(Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, true);
					}
				}
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_ColorFrameSource_OpenReader(RootSystem.IntPtr pNative);
		public Windows.Kinect.ColorFrameReader OpenReader()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("ColorFrameSource");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_ColorFrameSource_OpenReader(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.ColorFrameReader>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.ColorFrameReader(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.ColorFrameReader>(objectPointer, obj);
			}
			
			return obj;
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_ColorFrameSource_CreateFrameDescription(RootSystem.IntPtr pNative, Windows.Kinect.ColorImageFormat format);
		public Windows.Kinect.FrameDescription CreateFrameDescription(Windows.Kinect.ColorImageFormat format)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("ColorFrameSource");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_ColorFrameSource_CreateFrameDescription(_pNative, format);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.FrameDescription>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.FrameDescription(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.FrameDescription>(objectPointer, obj);
			}
			
			return obj;
		}
		
	}
	
	//
	// Windows.Kinect.DepthFrameSource
	//
	public partial class DepthFrameSource
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal DepthFrameSource(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_DepthFrameSource_AddRefObject(ref _pNative);
		}
		
		~DepthFrameSource()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_DepthFrameSource_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_DepthFrameSource_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<DepthFrameSource>(_pNative);
			Windows_Kinect_DepthFrameSource_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(DepthFrameSource other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator DepthFrameSource(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<DepthFrameSource>(other);
			if(obj == null)
			{
				obj = new DepthFrameSource(other);
				Helper.NativeObjectCache.AddObject<DepthFrameSource>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern ushort Windows_Kinect_DepthFrameSource_get_DepthMaxReliableDistance(RootSystem.IntPtr pNative);
		public  ushort DepthMaxReliableDistance
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("DepthFrameSource");
				}
				
				return Windows_Kinect_DepthFrameSource_get_DepthMaxReliableDistance(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern ushort Windows_Kinect_DepthFrameSource_get_DepthMinReliableDistance(RootSystem.IntPtr pNative);
		public  ushort DepthMinReliableDistance
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("DepthFrameSource");
				}
				
				return Windows_Kinect_DepthFrameSource_get_DepthMinReliableDistance(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_DepthFrameSource_get_FrameDescription(RootSystem.IntPtr pNative);
		public  Windows.Kinect.FrameDescription FrameDescription
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("DepthFrameSource");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_DepthFrameSource_get_FrameDescription(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.FrameDescription>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.FrameDescription(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.FrameDescription>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_DepthFrameSource_get_IsActive(RootSystem.IntPtr pNative);
		public  bool IsActive
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("DepthFrameSource");
				}
				
				return Windows_Kinect_DepthFrameSource_get_IsActive(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_DepthFrameSource_get_KinectSensor(RootSystem.IntPtr pNative);
		public  Windows.Kinect.KinectSensor KinectSensor
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("DepthFrameSource");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_DepthFrameSource_get_KinectSensor(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.KinectSensor>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.KinectSensor(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.KinectSensor>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		
		// Events
		[RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		public delegate void Windows_Kinect_FrameCapturedEventArgs_Delegate(Windows.Kinect.FrameCapturedEventArgs args);
		private delegate void _Windows_Kinect_FrameCapturedEventArgs_Delegate(RootSystem.IntPtr args);
		private static List<Windows_Kinect_FrameCapturedEventArgs_Delegate> Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks = new List<Windows_Kinect_FrameCapturedEventArgs_Delegate>();
		[AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_FrameCapturedEventArgs_Delegate))]
		private static void Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler(RootSystem.IntPtr result)
		{
			lock(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
			{
				foreach(var func in Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					if(func != null)
					{
						func((Windows.Kinect.FrameCapturedEventArgs)result);
					}
				}
			}
		}
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_DepthFrameSource_add_FrameCaptured(_Windows_Kinect_FrameCapturedEventArgs_Delegate eventCallback, bool unsubscribe);
		public  event Windows_Kinect_FrameCapturedEventArgs_Delegate FrameCaptured
		{
			add
			{
				lock (Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Add(value);
					if(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Count == 1)
					{
						Windows_Kinect_DepthFrameSource_add_FrameCaptured(Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, false);
					}
				}
			}
			remove
			{
				lock (Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Remove(value);
					if(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Count == 0)
					{
						Windows_Kinect_DepthFrameSource_add_FrameCaptured(Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, true);
					}
				}
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_DepthFrameSource_OpenReader(RootSystem.IntPtr pNative);
		public Windows.Kinect.DepthFrameReader OpenReader()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("DepthFrameSource");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_DepthFrameSource_OpenReader(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.DepthFrameReader>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.DepthFrameReader(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.DepthFrameReader>(objectPointer, obj);
			}
			
			return obj;
		}
		
	}
	
	//
	// Windows.Kinect.BodyFrameSource
	//
	public partial class BodyFrameSource
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal BodyFrameSource(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_BodyFrameSource_AddRefObject(ref _pNative);
		}
		
		~BodyFrameSource()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrameSource_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrameSource_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<BodyFrameSource>(_pNative);
			Windows_Kinect_BodyFrameSource_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(BodyFrameSource other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator BodyFrameSource(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<BodyFrameSource>(other);
			if(obj == null)
			{
				obj = new BodyFrameSource(other);
				Helper.NativeObjectCache.AddObject<BodyFrameSource>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_BodyFrameSource_get_BodyCount(RootSystem.IntPtr pNative);
		public  int BodyCount
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyFrameSource");
				}
				
				return Windows_Kinect_BodyFrameSource_get_BodyCount(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_BodyFrameSource_get_IsActive(RootSystem.IntPtr pNative);
		public  bool IsActive
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyFrameSource");
				}
				
				return Windows_Kinect_BodyFrameSource_get_IsActive(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_BodyFrameSource_get_KinectSensor(RootSystem.IntPtr pNative);
		public  Windows.Kinect.KinectSensor KinectSensor
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyFrameSource");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_BodyFrameSource_get_KinectSensor(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.KinectSensor>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.KinectSensor(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.KinectSensor>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		
		// Events
		[RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		public delegate void Windows_Kinect_FrameCapturedEventArgs_Delegate(Windows.Kinect.FrameCapturedEventArgs args);
		private delegate void _Windows_Kinect_FrameCapturedEventArgs_Delegate(RootSystem.IntPtr args);
		private static List<Windows_Kinect_FrameCapturedEventArgs_Delegate> Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks = new List<Windows_Kinect_FrameCapturedEventArgs_Delegate>();
		[AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_FrameCapturedEventArgs_Delegate))]
		private static void Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler(RootSystem.IntPtr result)
		{
			lock(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
			{
				foreach(var func in Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					if(func != null)
					{
						func((Windows.Kinect.FrameCapturedEventArgs)result);
					}
				}
			}
		}
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrameSource_add_FrameCaptured(_Windows_Kinect_FrameCapturedEventArgs_Delegate eventCallback, bool unsubscribe);
		public  event Windows_Kinect_FrameCapturedEventArgs_Delegate FrameCaptured
		{
			add
			{
				lock (Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Add(value);
					if(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Count == 1)
					{
						Windows_Kinect_BodyFrameSource_add_FrameCaptured(Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, false);
					}
				}
			}
			remove
			{
				lock (Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Remove(value);
					if(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Count == 0)
					{
						Windows_Kinect_BodyFrameSource_add_FrameCaptured(Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, true);
					}
				}
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_BodyFrameSource_OpenReader(RootSystem.IntPtr pNative);
		public Windows.Kinect.BodyFrameReader OpenReader()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("BodyFrameSource");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_BodyFrameSource_OpenReader(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.BodyFrameReader>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.BodyFrameReader(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.BodyFrameReader>(objectPointer, obj);
			}
			
			return obj;
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrameSource_OverrideHandTracking(RootSystem.IntPtr pNative, ulong trackingId);
		public void OverrideHandTracking(ulong trackingId)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("BodyFrameSource");
			}
			
			Windows_Kinect_BodyFrameSource_OverrideHandTracking(_pNative, trackingId);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrameSource_OverrideHandTracking_1(RootSystem.IntPtr pNative, ulong oldTrackingId, ulong newTrackingId);
		public void OverrideHandTracking(ulong oldTrackingId, ulong newTrackingId)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("BodyFrameSource");
			}
			
			Windows_Kinect_BodyFrameSource_OverrideHandTracking_1(_pNative, oldTrackingId, newTrackingId);
		}
		
	}
	
	//
	// Windows.Kinect.BodyIndexFrameSource
	//
	public partial class BodyIndexFrameSource
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal BodyIndexFrameSource(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_BodyIndexFrameSource_AddRefObject(ref _pNative);
		}
		
		~BodyIndexFrameSource()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyIndexFrameSource_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyIndexFrameSource_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<BodyIndexFrameSource>(_pNative);
			Windows_Kinect_BodyIndexFrameSource_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(BodyIndexFrameSource other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator BodyIndexFrameSource(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<BodyIndexFrameSource>(other);
			if(obj == null)
			{
				obj = new BodyIndexFrameSource(other);
				Helper.NativeObjectCache.AddObject<BodyIndexFrameSource>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_BodyIndexFrameSource_get_FrameDescription(RootSystem.IntPtr pNative);
		public  Windows.Kinect.FrameDescription FrameDescription
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyIndexFrameSource");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_BodyIndexFrameSource_get_FrameDescription(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.FrameDescription>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.FrameDescription(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.FrameDescription>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_BodyIndexFrameSource_get_IsActive(RootSystem.IntPtr pNative);
		public  bool IsActive
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyIndexFrameSource");
				}
				
				return Windows_Kinect_BodyIndexFrameSource_get_IsActive(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_BodyIndexFrameSource_get_KinectSensor(RootSystem.IntPtr pNative);
		public  Windows.Kinect.KinectSensor KinectSensor
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyIndexFrameSource");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_BodyIndexFrameSource_get_KinectSensor(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.KinectSensor>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.KinectSensor(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.KinectSensor>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		
		// Events
		[RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		public delegate void Windows_Kinect_FrameCapturedEventArgs_Delegate(Windows.Kinect.FrameCapturedEventArgs args);
		private delegate void _Windows_Kinect_FrameCapturedEventArgs_Delegate(RootSystem.IntPtr args);
		private static List<Windows_Kinect_FrameCapturedEventArgs_Delegate> Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks = new List<Windows_Kinect_FrameCapturedEventArgs_Delegate>();
		[AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_FrameCapturedEventArgs_Delegate))]
		private static void Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler(RootSystem.IntPtr result)
		{
			lock(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
			{
				foreach(var func in Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					if(func != null)
					{
						func((Windows.Kinect.FrameCapturedEventArgs)result);
					}
				}
			}
		}
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyIndexFrameSource_add_FrameCaptured(_Windows_Kinect_FrameCapturedEventArgs_Delegate eventCallback, bool unsubscribe);
		public  event Windows_Kinect_FrameCapturedEventArgs_Delegate FrameCaptured
		{
			add
			{
				lock (Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Add(value);
					if(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Count == 1)
					{
						Windows_Kinect_BodyIndexFrameSource_add_FrameCaptured(Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, false);
					}
				}
			}
			remove
			{
				lock (Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Remove(value);
					if(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Count == 0)
					{
						Windows_Kinect_BodyIndexFrameSource_add_FrameCaptured(Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, true);
					}
				}
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_BodyIndexFrameSource_OpenReader(RootSystem.IntPtr pNative);
		public Windows.Kinect.BodyIndexFrameReader OpenReader()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("BodyIndexFrameSource");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_BodyIndexFrameSource_OpenReader(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.BodyIndexFrameReader>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.BodyIndexFrameReader(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.BodyIndexFrameReader>(objectPointer, obj);
			}
			
			return obj;
		}
		
	}
	
	//
	// Windows.Kinect.InfraredFrameSource
	//
	public partial class InfraredFrameSource
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal InfraredFrameSource(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_InfraredFrameSource_AddRefObject(ref _pNative);
		}
		
		~InfraredFrameSource()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_InfraredFrameSource_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_InfraredFrameSource_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<InfraredFrameSource>(_pNative);
			Windows_Kinect_InfraredFrameSource_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(InfraredFrameSource other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator InfraredFrameSource(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<InfraredFrameSource>(other);
			if(obj == null)
			{
				obj = new InfraredFrameSource(other);
				Helper.NativeObjectCache.AddObject<InfraredFrameSource>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_InfraredFrameSource_get_FrameDescription(RootSystem.IntPtr pNative);
		public  Windows.Kinect.FrameDescription FrameDescription
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("InfraredFrameSource");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_InfraredFrameSource_get_FrameDescription(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.FrameDescription>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.FrameDescription(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.FrameDescription>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_InfraredFrameSource_get_IsActive(RootSystem.IntPtr pNative);
		public  bool IsActive
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("InfraredFrameSource");
				}
				
				return Windows_Kinect_InfraredFrameSource_get_IsActive(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_InfraredFrameSource_get_KinectSensor(RootSystem.IntPtr pNative);
		public  Windows.Kinect.KinectSensor KinectSensor
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("InfraredFrameSource");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_InfraredFrameSource_get_KinectSensor(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.KinectSensor>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.KinectSensor(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.KinectSensor>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		
		// Events
		[RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		public delegate void Windows_Kinect_FrameCapturedEventArgs_Delegate(Windows.Kinect.FrameCapturedEventArgs args);
		private delegate void _Windows_Kinect_FrameCapturedEventArgs_Delegate(RootSystem.IntPtr args);
		private static List<Windows_Kinect_FrameCapturedEventArgs_Delegate> Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks = new List<Windows_Kinect_FrameCapturedEventArgs_Delegate>();
		[AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_FrameCapturedEventArgs_Delegate))]
		private static void Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler(RootSystem.IntPtr result)
		{
			lock(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
			{
				foreach(var func in Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					if(func != null)
					{
						func((Windows.Kinect.FrameCapturedEventArgs)result);
					}
				}
			}
		}
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_InfraredFrameSource_add_FrameCaptured(_Windows_Kinect_FrameCapturedEventArgs_Delegate eventCallback, bool unsubscribe);
		public  event Windows_Kinect_FrameCapturedEventArgs_Delegate FrameCaptured
		{
			add
			{
				lock (Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Add(value);
					if(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Count == 1)
					{
						Windows_Kinect_InfraredFrameSource_add_FrameCaptured(Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, false);
					}
				}
			}
			remove
			{
				lock (Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Remove(value);
					if(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Count == 0)
					{
						Windows_Kinect_InfraredFrameSource_add_FrameCaptured(Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, true);
					}
				}
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_InfraredFrameSource_OpenReader(RootSystem.IntPtr pNative);
		public Windows.Kinect.InfraredFrameReader OpenReader()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("InfraredFrameSource");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_InfraredFrameSource_OpenReader(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.InfraredFrameReader>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.InfraredFrameReader(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.InfraredFrameReader>(objectPointer, obj);
			}
			
			return obj;
		}
		
	}
	
	//
	// Windows.Kinect.LongExposureInfraredFrameSource
	//
	public partial class LongExposureInfraredFrameSource
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal LongExposureInfraredFrameSource(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_LongExposureInfraredFrameSource_AddRefObject(ref _pNative);
		}
		
		~LongExposureInfraredFrameSource()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_LongExposureInfraredFrameSource_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_LongExposureInfraredFrameSource_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<LongExposureInfraredFrameSource>(_pNative);
			Windows_Kinect_LongExposureInfraredFrameSource_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(LongExposureInfraredFrameSource other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator LongExposureInfraredFrameSource(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<LongExposureInfraredFrameSource>(other);
			if(obj == null)
			{
				obj = new LongExposureInfraredFrameSource(other);
				Helper.NativeObjectCache.AddObject<LongExposureInfraredFrameSource>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_LongExposureInfraredFrameSource_get_FrameDescription(RootSystem.IntPtr pNative);
		public  Windows.Kinect.FrameDescription FrameDescription
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrameSource");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_LongExposureInfraredFrameSource_get_FrameDescription(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.FrameDescription>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.FrameDescription(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.FrameDescription>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_LongExposureInfraredFrameSource_get_IsActive(RootSystem.IntPtr pNative);
		public  bool IsActive
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrameSource");
				}
				
				return Windows_Kinect_LongExposureInfraredFrameSource_get_IsActive(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_LongExposureInfraredFrameSource_get_KinectSensor(RootSystem.IntPtr pNative);
		public  Windows.Kinect.KinectSensor KinectSensor
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrameSource");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_LongExposureInfraredFrameSource_get_KinectSensor(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.KinectSensor>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.KinectSensor(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.KinectSensor>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		
		// Events
		[RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		public delegate void Windows_Kinect_FrameCapturedEventArgs_Delegate(Windows.Kinect.FrameCapturedEventArgs args);
		private delegate void _Windows_Kinect_FrameCapturedEventArgs_Delegate(RootSystem.IntPtr args);
		private static List<Windows_Kinect_FrameCapturedEventArgs_Delegate> Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks = new List<Windows_Kinect_FrameCapturedEventArgs_Delegate>();
		[AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_FrameCapturedEventArgs_Delegate))]
		private static void Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler(RootSystem.IntPtr result)
		{
			lock(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
			{
				foreach(var func in Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					if(func != null)
					{
						func((Windows.Kinect.FrameCapturedEventArgs)result);
					}
				}
			}
		}
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_LongExposureInfraredFrameSource_add_FrameCaptured(_Windows_Kinect_FrameCapturedEventArgs_Delegate eventCallback, bool unsubscribe);
		public  event Windows_Kinect_FrameCapturedEventArgs_Delegate FrameCaptured
		{
			add
			{
				lock (Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Add(value);
					if(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Count == 1)
					{
						Windows_Kinect_LongExposureInfraredFrameSource_add_FrameCaptured(Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, false);
					}
				}
			}
			remove
			{
				lock (Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Remove(value);
					if(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Count == 0)
					{
						Windows_Kinect_LongExposureInfraredFrameSource_add_FrameCaptured(Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, true);
					}
				}
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_LongExposureInfraredFrameSource_OpenReader(RootSystem.IntPtr pNative);
		public Windows.Kinect.LongExposureInfraredFrameReader OpenReader()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrameSource");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_LongExposureInfraredFrameSource_OpenReader(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.LongExposureInfraredFrameReader>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.LongExposureInfraredFrameReader(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.LongExposureInfraredFrameReader>(objectPointer, obj);
			}
			
			return obj;
		}
		
	}
	
	//
	// Windows.Kinect.AudioSource
	//
	public partial class AudioSource
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal AudioSource(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_AudioSource_AddRefObject(ref _pNative);
		}
		
		~AudioSource()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioSource_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioSource_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<AudioSource>(_pNative);
			Windows_Kinect_AudioSource_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(AudioSource other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator AudioSource(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<AudioSource>(other);
			if(obj == null)
			{
				obj = new AudioSource(other);
				Helper.NativeObjectCache.AddObject<AudioSource>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_AudioSource_get_AudioBeams(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] RootSystem.IntPtr[] outCollection, int collectionSize);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_AudioSource_get_AudioBeams_Length(RootSystem.IntPtr pNative);
		public  Windows.Kinect.AudioBeam[] AudioBeams
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioSource");
				}
				
				int collectionSize = Windows_Kinect_AudioSource_get_AudioBeams_Length(_pNative);
				var outCollection = new RootSystem.IntPtr[collectionSize];
				var managedCollection = new Windows.Kinect.AudioBeam[collectionSize];
				
				collectionSize = Windows_Kinect_AudioSource_get_AudioBeams(_pNative, outCollection, collectionSize);
				for(int i=0;i<collectionSize;i++)
				{
					if(outCollection[i] == RootSystem.IntPtr.Zero)
					{
						continue;
					}
					
					outCollection[i] = Helper.NativeObjectCache.MapToIUnknown(outCollection[i]);
					var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.AudioBeam>(outCollection[i]);
					if (obj == null)
					{
						obj = new Windows.Kinect.AudioBeam(outCollection[i]);
						Helper.NativeObjectCache.AddObject<Windows.Kinect.AudioBeam>(outCollection[i], obj);
					}
					
					managedCollection[i] = obj;
				}
				return managedCollection;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_AudioSource_get_IsActive(RootSystem.IntPtr pNative);
		public  bool IsActive
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioSource");
				}
				
				return Windows_Kinect_AudioSource_get_IsActive(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_AudioSource_get_KinectSensor(RootSystem.IntPtr pNative);
		public  Windows.Kinect.KinectSensor KinectSensor
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioSource");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_AudioSource_get_KinectSensor(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.KinectSensor>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.KinectSensor(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.KinectSensor>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern uint Windows_Kinect_AudioSource_get_MaxSubFrameCount(RootSystem.IntPtr pNative);
		public  uint MaxSubFrameCount
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioSource");
				}
				
				return Windows_Kinect_AudioSource_get_MaxSubFrameCount(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_AudioSource_get_SubFrameDuration(RootSystem.IntPtr pNative);
		public  long SubFrameDuration
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioSource");
				}
				
				return Windows_Kinect_AudioSource_get_SubFrameDuration(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern uint Windows_Kinect_AudioSource_get_SubFrameLengthInBytes(RootSystem.IntPtr pNative);
		public  uint SubFrameLengthInBytes
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioSource");
				}
				
				return Windows_Kinect_AudioSource_get_SubFrameLengthInBytes(_pNative);
			}
		}
		
		
		// Events
		[RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		public delegate void Windows_Kinect_FrameCapturedEventArgs_Delegate(Windows.Kinect.FrameCapturedEventArgs args);
		private delegate void _Windows_Kinect_FrameCapturedEventArgs_Delegate(RootSystem.IntPtr args);
		private static List<Windows_Kinect_FrameCapturedEventArgs_Delegate> Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks = new List<Windows_Kinect_FrameCapturedEventArgs_Delegate>();
		[AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_FrameCapturedEventArgs_Delegate))]
		private static void Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler(RootSystem.IntPtr result)
		{
			lock(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
			{
				foreach(var func in Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					if(func != null)
					{
						func((Windows.Kinect.FrameCapturedEventArgs)result);
					}
				}
			}
		}
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioSource_add_FrameCaptured(_Windows_Kinect_FrameCapturedEventArgs_Delegate eventCallback, bool unsubscribe);
		public  event Windows_Kinect_FrameCapturedEventArgs_Delegate FrameCaptured
		{
			add
			{
				lock (Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Add(value);
					if(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Count == 1)
					{
						Windows_Kinect_AudioSource_add_FrameCaptured(Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, false);
					}
				}
			}
			remove
			{
				lock (Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Remove(value);
					if(Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.Count == 0)
					{
						Windows_Kinect_AudioSource_add_FrameCaptured(Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, true);
					}
				}
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_AudioSource_OpenReader(RootSystem.IntPtr pNative);
		public Windows.Kinect.AudioBeamFrameReader OpenReader()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("AudioSource");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_AudioSource_OpenReader(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.AudioBeamFrameReader>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.AudioBeamFrameReader(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.AudioBeamFrameReader>(objectPointer, obj);
			}
			
			return obj;
		}
		
	}
	
	//
	// Windows.Kinect.MultiSourceFrameReader
	//
	public partial class MultiSourceFrameReader : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal MultiSourceFrameReader(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_MultiSourceFrameReader_AddRefObject(ref _pNative);
		}
		
		~MultiSourceFrameReader()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_MultiSourceFrameReader_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_MultiSourceFrameReader_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<MultiSourceFrameReader>(_pNative);
			Windows_Kinect_MultiSourceFrameReader_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_MultiSourceFrameReader_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(MultiSourceFrameReader other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator MultiSourceFrameReader(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<MultiSourceFrameReader>(other);
			if(obj == null)
			{
				obj = new MultiSourceFrameReader(other);
				Helper.NativeObjectCache.AddObject<MultiSourceFrameReader>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.FrameSourceTypes Windows_Kinect_MultiSourceFrameReader_get_FrameSourceTypes(RootSystem.IntPtr pNative);
		public  Windows.Kinect.FrameSourceTypes FrameSourceTypes
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("MultiSourceFrameReader");
				}
				
				return Windows_Kinect_MultiSourceFrameReader_get_FrameSourceTypes(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_MultiSourceFrameReader_get_IsPaused(RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_MultiSourceFrameReader_put_IsPaused(RootSystem.IntPtr pNative, bool isPaused);
		public  bool IsPaused
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("MultiSourceFrameReader");
				}
				
				return Windows_Kinect_MultiSourceFrameReader_get_IsPaused(_pNative);
			}
			set
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("MultiSourceFrameReader");
				}
				
				Windows_Kinect_MultiSourceFrameReader_put_IsPaused(_pNative, value);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrameReader_get_KinectSensor(RootSystem.IntPtr pNative);
		public  Windows.Kinect.KinectSensor KinectSensor
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("MultiSourceFrameReader");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_MultiSourceFrameReader_get_KinectSensor(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.KinectSensor>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.KinectSensor(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.KinectSensor>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		
		// Events
		[RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		public delegate void Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate(Windows.Kinect.MultiSourceFrameArrivedEventArgs args);
		private delegate void _Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate(RootSystem.IntPtr args);
		private static List<Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate> Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate_callbacks = new List<Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate>();
		[AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate))]
		private static void Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate_Handler(RootSystem.IntPtr result)
		{
			lock(Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate_callbacks)
			{
				foreach(var func in Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate_callbacks)
				{
					if(func != null)
					{
						func((Windows.Kinect.MultiSourceFrameArrivedEventArgs)result);
					}
				}
			}
		}
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_MultiSourceFrameReader_add_MultiSourceFrameArrived(_Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate eventCallback, bool unsubscribe);
		public  event Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate MultiSourceFrameArrived
		{
			add
			{
				lock (Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate_callbacks.Add(value);
					if(Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate_callbacks.Count == 1)
					{
						Windows_Kinect_MultiSourceFrameReader_add_MultiSourceFrameArrived(Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate_Handler, false);
					}
				}
			}
			remove
			{
				lock (Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate_callbacks.Remove(value);
					if(Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate_callbacks.Count == 0)
					{
						Windows_Kinect_MultiSourceFrameReader_add_MultiSourceFrameArrived(Windows_Kinect_MultiSourceFrameArrivedEventArgs_Delegate_Handler, true);
					}
				}
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrameReader_AcquireLatestFrame(RootSystem.IntPtr pNative);
		public Windows.Kinect.MultiSourceFrame AcquireLatestFrame()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("MultiSourceFrameReader");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_MultiSourceFrameReader_AcquireLatestFrame(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.MultiSourceFrame>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.MultiSourceFrame(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.MultiSourceFrame>(objectPointer, obj);
			}
			
			return obj;
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_MultiSourceFrameReader_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("MultiSourceFrameReader");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.CoordinateMapper
	//
	public partial class CoordinateMapper
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal CoordinateMapper(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_CoordinateMapper_AddRefObject(ref _pNative);
		}
		
		~CoordinateMapper()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_CoordinateMapper_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_CoordinateMapper_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<CoordinateMapper>(_pNative);
			Windows_Kinect_CoordinateMapper_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(CoordinateMapper other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator CoordinateMapper(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<CoordinateMapper>(other);
			if(obj == null)
			{
				obj = new CoordinateMapper(other);
				Helper.NativeObjectCache.AddObject<CoordinateMapper>(other, obj);
			}
			return obj;
		}
		
		
		// Events
		[RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		public delegate void Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate(Windows.Kinect.CoordinateMappingChangedEventArgs args);
		private delegate void _Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate(RootSystem.IntPtr args);
		private static List<Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate> Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks = new List<Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate>();
		[AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate))]
		private static void Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handler(RootSystem.IntPtr result)
		{
			lock(Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks)
			{
				foreach(var func in Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks)
				{
					if(func != null)
					{
						func((Windows.Kinect.CoordinateMappingChangedEventArgs)result);
					}
				}
			}
		}
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_CoordinateMapper_add_CoordinateMappingChanged(_Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate eventCallback, bool unsubscribe);
		public  event Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate CoordinateMappingChanged
		{
			add
			{
				lock (Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks.Add(value);
					if(Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks.Count == 1)
					{
						Windows_Kinect_CoordinateMapper_add_CoordinateMappingChanged(Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handler, false);
					}
				}
			}
			remove
			{
				lock (Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks.Remove(value);
					if(Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks.Count == 0)
					{
						Windows_Kinect_CoordinateMapper_add_CoordinateMappingChanged(Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handler, true);
					}
				}
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.DepthSpacePoint Windows_Kinect_CoordinateMapper_MapCameraPointToDepthSpace(RootSystem.IntPtr pNative, Windows.Kinect.CameraSpacePoint cameraPoint);
		public Windows.Kinect.DepthSpacePoint MapCameraPointToDepthSpace(Windows.Kinect.CameraSpacePoint cameraPoint)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("CoordinateMapper");
			}
			
			return Windows_Kinect_CoordinateMapper_MapCameraPointToDepthSpace(_pNative, cameraPoint);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.ColorSpacePoint Windows_Kinect_CoordinateMapper_MapCameraPointToColorSpace(RootSystem.IntPtr pNative, Windows.Kinect.CameraSpacePoint cameraPoint);
		public Windows.Kinect.ColorSpacePoint MapCameraPointToColorSpace(Windows.Kinect.CameraSpacePoint cameraPoint)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("CoordinateMapper");
			}
			
			return Windows_Kinect_CoordinateMapper_MapCameraPointToColorSpace(_pNative, cameraPoint);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.CameraSpacePoint Windows_Kinect_CoordinateMapper_MapDepthPointToCameraSpace(RootSystem.IntPtr pNative, Windows.Kinect.DepthSpacePoint depthPoint, ushort depth);
		public Windows.Kinect.CameraSpacePoint MapDepthPointToCameraSpace(Windows.Kinect.DepthSpacePoint depthPoint, ushort depth)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("CoordinateMapper");
			}
			
			return Windows_Kinect_CoordinateMapper_MapDepthPointToCameraSpace(_pNative, depthPoint, depth);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.ColorSpacePoint Windows_Kinect_CoordinateMapper_MapDepthPointToColorSpace(RootSystem.IntPtr pNative, Windows.Kinect.DepthSpacePoint depthPoint, ushort depth);
		public Windows.Kinect.ColorSpacePoint MapDepthPointToColorSpace(Windows.Kinect.DepthSpacePoint depthPoint, ushort depth)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("CoordinateMapper");
			}
			
			return Windows_Kinect_CoordinateMapper_MapDepthPointToColorSpace(_pNative, depthPoint, depth);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_CoordinateMapper_MapCameraPointsToDepthSpace(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.CameraSpacePoint[] cameraPoints, int cameraPointsSize, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.DepthSpacePoint[] depthPoints, int depthPointsSize);
		public void MapCameraPointsToDepthSpace(Windows.Kinect.CameraSpacePoint[] cameraPoints, Windows.Kinect.DepthSpacePoint[] depthPoints)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("CoordinateMapper");
			}
			
			Windows_Kinect_CoordinateMapper_MapCameraPointsToDepthSpace(_pNative, cameraPoints, cameraPoints.Length, depthPoints, depthPoints.Length);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_CoordinateMapper_MapCameraPointsToColorSpace(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.CameraSpacePoint[] cameraPoints, int cameraPointsSize, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.ColorSpacePoint[] colorPoints, int colorPointsSize);
		public void MapCameraPointsToColorSpace(Windows.Kinect.CameraSpacePoint[] cameraPoints, Windows.Kinect.ColorSpacePoint[] colorPoints)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("CoordinateMapper");
			}
			
			Windows_Kinect_CoordinateMapper_MapCameraPointsToColorSpace(_pNative, cameraPoints, cameraPoints.Length, colorPoints, colorPoints.Length);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_CoordinateMapper_MapDepthPointsToCameraSpace(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.DepthSpacePoint[] depthPoints, int depthPointsSize, ushort[] depths, int depthsSize, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.CameraSpacePoint[] cameraPoints, int cameraPointsSize);
		public void MapDepthPointsToCameraSpace(Windows.Kinect.DepthSpacePoint[] depthPoints, ushort[] depths, Windows.Kinect.CameraSpacePoint[] cameraPoints)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("CoordinateMapper");
			}
			
			Windows_Kinect_CoordinateMapper_MapDepthPointsToCameraSpace(_pNative, depthPoints, depthPoints.Length, depths, depths.Length, cameraPoints, cameraPoints.Length);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_CoordinateMapper_MapDepthPointsToColorSpace(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.DepthSpacePoint[] depthPoints, int depthPointsSize, ushort[] depths, int depthsSize, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.ColorSpacePoint[] colorPoints, int colorPointsSize);
		public void MapDepthPointsToColorSpace(Windows.Kinect.DepthSpacePoint[] depthPoints, ushort[] depths, Windows.Kinect.ColorSpacePoint[] colorPoints)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("CoordinateMapper");
			}
			
			Windows_Kinect_CoordinateMapper_MapDepthPointsToColorSpace(_pNative, depthPoints, depthPoints.Length, depths, depths.Length, colorPoints, colorPoints.Length);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_CoordinateMapper_MapDepthFrameToCameraSpace(RootSystem.IntPtr pNative, ushort[] depthFrameData, int depthFrameDataSize, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.CameraSpacePoint[] cameraSpacePoints, int cameraSpacePointsSize);
		public void MapDepthFrameToCameraSpace(ushort[] depthFrameData, Windows.Kinect.CameraSpacePoint[] cameraSpacePoints)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("CoordinateMapper");
			}
			
			Windows_Kinect_CoordinateMapper_MapDepthFrameToCameraSpace(_pNative, depthFrameData, depthFrameData.Length, cameraSpacePoints, cameraSpacePoints.Length);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_CoordinateMapper_MapDepthFrameToColorSpace(RootSystem.IntPtr pNative, ushort[] depthFrameData, int depthFrameDataSize, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.ColorSpacePoint[] colorSpacePoints, int colorSpacePointsSize);
		public void MapDepthFrameToColorSpace(ushort[] depthFrameData, Windows.Kinect.ColorSpacePoint[] colorSpacePoints)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("CoordinateMapper");
			}
			
			Windows_Kinect_CoordinateMapper_MapDepthFrameToColorSpace(_pNative, depthFrameData, depthFrameData.Length, colorSpacePoints, colorSpacePoints.Length);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_CoordinateMapper_MapDepthFrameToCameraSpaceUsingIBuffer(RootSystem.IntPtr pNative, RootSystem.IntPtr depthFrameData, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.CameraSpacePoint[] cameraSpacePoints, int cameraSpacePointsSize);
		public void MapDepthFrameToCameraSpaceUsingIBuffer(Windows.Storage.Streams.IBuffer depthFrameData, Windows.Kinect.CameraSpacePoint[] cameraSpacePoints)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("CoordinateMapper");
			}
			
			Windows_Kinect_CoordinateMapper_MapDepthFrameToCameraSpaceUsingIBuffer(_pNative, depthFrameData, cameraSpacePoints, cameraSpacePoints.Length);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_CoordinateMapper_MapDepthFrameToColorSpaceUsingIBuffer(RootSystem.IntPtr pNative, RootSystem.IntPtr depthFrameData, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.ColorSpacePoint[] colorSpacePoints, int colorSpacePointsSize);
		public void MapDepthFrameToColorSpaceUsingIBuffer(Windows.Storage.Streams.IBuffer depthFrameData, Windows.Kinect.ColorSpacePoint[] colorSpacePoints)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("CoordinateMapper");
			}
			
			Windows_Kinect_CoordinateMapper_MapDepthFrameToColorSpaceUsingIBuffer(_pNative, depthFrameData, colorSpacePoints, colorSpacePoints.Length);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_CoordinateMapper_MapColorFrameToDepthSpace(RootSystem.IntPtr pNative, ushort[] depthFrameData, int depthFrameDataSize, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.DepthSpacePoint[] depthSpacePoints, int depthSpacePointsSize);
		public void MapColorFrameToDepthSpace(ushort[] depthFrameData, Windows.Kinect.DepthSpacePoint[] depthSpacePoints)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("CoordinateMapper");
			}
			
			Windows_Kinect_CoordinateMapper_MapColorFrameToDepthSpace(_pNative, depthFrameData, depthFrameData.Length, depthSpacePoints, depthSpacePoints.Length);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_CoordinateMapper_MapColorFrameToCameraSpace(RootSystem.IntPtr pNative, ushort[] depthFrameData, int depthFrameDataSize, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.CameraSpacePoint[] cameraSpacePoints, int cameraSpacePointsSize);
		public void MapColorFrameToCameraSpace(ushort[] depthFrameData, Windows.Kinect.CameraSpacePoint[] cameraSpacePoints)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("CoordinateMapper");
			}
			
			Windows_Kinect_CoordinateMapper_MapColorFrameToCameraSpace(_pNative, depthFrameData, depthFrameData.Length, cameraSpacePoints, cameraSpacePoints.Length);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_CoordinateMapper_MapColorFrameToDepthSpaceUsingIBuffer(RootSystem.IntPtr pNative, RootSystem.IntPtr depthFrameData, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.DepthSpacePoint[] depthSpacePoints, int depthSpacePointsSize);
		public void MapColorFrameToDepthSpaceUsingIBuffer(Windows.Storage.Streams.IBuffer depthFrameData, Windows.Kinect.DepthSpacePoint[] depthSpacePoints)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("CoordinateMapper");
			}
			
			Windows_Kinect_CoordinateMapper_MapColorFrameToDepthSpaceUsingIBuffer(_pNative, depthFrameData, depthSpacePoints, depthSpacePoints.Length);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_CoordinateMapper_MapColorFrameToCameraSpaceUsingIBuffer(RootSystem.IntPtr pNative, RootSystem.IntPtr depthFrameData, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.CameraSpacePoint[] cameraSpacePoints, int cameraSpacePointsSize);
		public void MapColorFrameToCameraSpaceUsingIBuffer(Windows.Storage.Streams.IBuffer depthFrameData, Windows.Kinect.CameraSpacePoint[] cameraSpacePoints)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("CoordinateMapper");
			}
			
			Windows_Kinect_CoordinateMapper_MapColorFrameToCameraSpaceUsingIBuffer(_pNative, depthFrameData, cameraSpacePoints, cameraSpacePoints.Length);
		}
		
	}
	
	//
	// Windows.Kinect.MultiSourceFrameArrivedEventArgs
	//
	public partial class MultiSourceFrameArrivedEventArgs
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal MultiSourceFrameArrivedEventArgs(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_MultiSourceFrameArrivedEventArgs_AddRefObject(ref _pNative);
		}
		
		~MultiSourceFrameArrivedEventArgs()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_MultiSourceFrameArrivedEventArgs_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_MultiSourceFrameArrivedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<MultiSourceFrameArrivedEventArgs>(_pNative);
			Windows_Kinect_MultiSourceFrameArrivedEventArgs_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(MultiSourceFrameArrivedEventArgs other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator MultiSourceFrameArrivedEventArgs(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<MultiSourceFrameArrivedEventArgs>(other);
			if(obj == null)
			{
				obj = new MultiSourceFrameArrivedEventArgs(other);
				Helper.NativeObjectCache.AddObject<MultiSourceFrameArrivedEventArgs>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrameArrivedEventArgs_get_FrameReference(RootSystem.IntPtr pNative);
		public  Windows.Kinect.MultiSourceFrameReference FrameReference
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("MultiSourceFrameArrivedEventArgs");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_MultiSourceFrameArrivedEventArgs_get_FrameReference(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.MultiSourceFrameReference>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.MultiSourceFrameReference(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.MultiSourceFrameReference>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
	}
	
	//
	// Windows.Kinect.MultiSourceFrame
	//
	public partial class MultiSourceFrame : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal MultiSourceFrame(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_MultiSourceFrame_AddRefObject(ref _pNative);
		}
		
		~MultiSourceFrame()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_MultiSourceFrame_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_MultiSourceFrame_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<MultiSourceFrame>(_pNative);
			Windows_Kinect_MultiSourceFrame_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_MultiSourceFrame_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(MultiSourceFrame other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator MultiSourceFrame(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<MultiSourceFrame>(other);
			if(obj == null)
			{
				obj = new MultiSourceFrame(other);
				Helper.NativeObjectCache.AddObject<MultiSourceFrame>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrame_get_BodyFrameReference(RootSystem.IntPtr pNative);
		public  Windows.Kinect.BodyFrameReference BodyFrameReference
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("MultiSourceFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_MultiSourceFrame_get_BodyFrameReference(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.BodyFrameReference>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.BodyFrameReference(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.BodyFrameReference>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrame_get_BodyIndexFrameReference(RootSystem.IntPtr pNative);
		public  Windows.Kinect.BodyIndexFrameReference BodyIndexFrameReference
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("MultiSourceFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_MultiSourceFrame_get_BodyIndexFrameReference(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.BodyIndexFrameReference>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.BodyIndexFrameReference(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.BodyIndexFrameReference>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrame_get_ColorFrameReference(RootSystem.IntPtr pNative);
		public  Windows.Kinect.ColorFrameReference ColorFrameReference
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("MultiSourceFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_MultiSourceFrame_get_ColorFrameReference(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.ColorFrameReference>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.ColorFrameReference(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.ColorFrameReference>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrame_get_DepthFrameReference(RootSystem.IntPtr pNative);
		public  Windows.Kinect.DepthFrameReference DepthFrameReference
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("MultiSourceFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_MultiSourceFrame_get_DepthFrameReference(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.DepthFrameReference>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.DepthFrameReference(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.DepthFrameReference>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrame_get_InfraredFrameReference(RootSystem.IntPtr pNative);
		public  Windows.Kinect.InfraredFrameReference InfraredFrameReference
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("MultiSourceFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_MultiSourceFrame_get_InfraredFrameReference(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.InfraredFrameReference>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.InfraredFrameReference(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.InfraredFrameReference>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrame_get_LongExposureInfraredFrameReference(RootSystem.IntPtr pNative);
		public  Windows.Kinect.LongExposureInfraredFrameReference LongExposureInfraredFrameReference
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("MultiSourceFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_MultiSourceFrame_get_LongExposureInfraredFrameReference(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.LongExposureInfraredFrameReference>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.LongExposureInfraredFrameReference(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.LongExposureInfraredFrameReference>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_MultiSourceFrame_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("MultiSourceFrame");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.MultiSourceFrameReference
	//
	public partial class MultiSourceFrameReference
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal MultiSourceFrameReference(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_MultiSourceFrameReference_AddRefObject(ref _pNative);
		}
		
		~MultiSourceFrameReference()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_MultiSourceFrameReference_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_MultiSourceFrameReference_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<MultiSourceFrameReference>(_pNative);
			Windows_Kinect_MultiSourceFrameReference_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(MultiSourceFrameReference other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator MultiSourceFrameReference(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<MultiSourceFrameReference>(other);
			if(obj == null)
			{
				obj = new MultiSourceFrameReference(other);
				Helper.NativeObjectCache.AddObject<MultiSourceFrameReference>(other, obj);
			}
			return obj;
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrameReference_AcquireFrame(RootSystem.IntPtr pNative);
		public Windows.Kinect.MultiSourceFrame AcquireFrame()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("MultiSourceFrameReference");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_MultiSourceFrameReference_AcquireFrame(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.MultiSourceFrame>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.MultiSourceFrame(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.MultiSourceFrame>(objectPointer, obj);
			}
			
			return obj;
		}
		
	}
	
	//
	// Windows.Kinect.ColorFrameReference
	//
	public partial class ColorFrameReference
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal ColorFrameReference(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_ColorFrameReference_AddRefObject(ref _pNative);
		}
		
		~ColorFrameReference()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrameReference_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrameReference_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<ColorFrameReference>(_pNative);
			Windows_Kinect_ColorFrameReference_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(ColorFrameReference other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator ColorFrameReference(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<ColorFrameReference>(other);
			if(obj == null)
			{
				obj = new ColorFrameReference(other);
				Helper.NativeObjectCache.AddObject<ColorFrameReference>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_ColorFrameReference_get_RelativeTime(RootSystem.IntPtr pNative);
		public  long RelativeTime
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("ColorFrameReference");
				}
				
				return Windows_Kinect_ColorFrameReference_get_RelativeTime(_pNative);
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_ColorFrameReference_AcquireFrame(RootSystem.IntPtr pNative);
		public Windows.Kinect.ColorFrame AcquireFrame()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("ColorFrameReference");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_ColorFrameReference_AcquireFrame(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.ColorFrame>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.ColorFrame(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.ColorFrame>(objectPointer, obj);
			}
			
			return obj;
		}
		
	}
	
	//
	// Windows.Kinect.DepthFrameReference
	//
	public partial class DepthFrameReference
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal DepthFrameReference(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_DepthFrameReference_AddRefObject(ref _pNative);
		}
		
		~DepthFrameReference()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_DepthFrameReference_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_DepthFrameReference_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<DepthFrameReference>(_pNative);
			Windows_Kinect_DepthFrameReference_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(DepthFrameReference other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator DepthFrameReference(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<DepthFrameReference>(other);
			if(obj == null)
			{
				obj = new DepthFrameReference(other);
				Helper.NativeObjectCache.AddObject<DepthFrameReference>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_DepthFrameReference_get_RelativeTime(RootSystem.IntPtr pNative);
		public  long RelativeTime
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("DepthFrameReference");
				}
				
				return Windows_Kinect_DepthFrameReference_get_RelativeTime(_pNative);
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_DepthFrameReference_AcquireFrame(RootSystem.IntPtr pNative);
		public Windows.Kinect.DepthFrame AcquireFrame()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("DepthFrameReference");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_DepthFrameReference_AcquireFrame(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.DepthFrame>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.DepthFrame(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.DepthFrame>(objectPointer, obj);
			}
			
			return obj;
		}
		
	}
	
	//
	// Windows.Kinect.BodyFrameReference
	//
	public partial class BodyFrameReference
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal BodyFrameReference(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_BodyFrameReference_AddRefObject(ref _pNative);
		}
		
		~BodyFrameReference()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrameReference_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrameReference_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<BodyFrameReference>(_pNative);
			Windows_Kinect_BodyFrameReference_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(BodyFrameReference other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator BodyFrameReference(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<BodyFrameReference>(other);
			if(obj == null)
			{
				obj = new BodyFrameReference(other);
				Helper.NativeObjectCache.AddObject<BodyFrameReference>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_BodyFrameReference_get_RelativeTime(RootSystem.IntPtr pNative);
		public  long RelativeTime
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyFrameReference");
				}
				
				return Windows_Kinect_BodyFrameReference_get_RelativeTime(_pNative);
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_BodyFrameReference_AcquireFrame(RootSystem.IntPtr pNative);
		public Windows.Kinect.BodyFrame AcquireFrame()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("BodyFrameReference");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_BodyFrameReference_AcquireFrame(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.BodyFrame>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.BodyFrame(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.BodyFrame>(objectPointer, obj);
			}
			
			return obj;
		}
		
	}
	
	//
	// Windows.Kinect.BodyIndexFrameReference
	//
	public partial class BodyIndexFrameReference
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal BodyIndexFrameReference(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_BodyIndexFrameReference_AddRefObject(ref _pNative);
		}
		
		~BodyIndexFrameReference()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyIndexFrameReference_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyIndexFrameReference_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<BodyIndexFrameReference>(_pNative);
			Windows_Kinect_BodyIndexFrameReference_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(BodyIndexFrameReference other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator BodyIndexFrameReference(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<BodyIndexFrameReference>(other);
			if(obj == null)
			{
				obj = new BodyIndexFrameReference(other);
				Helper.NativeObjectCache.AddObject<BodyIndexFrameReference>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_BodyIndexFrameReference_get_RelativeTime(RootSystem.IntPtr pNative);
		public  long RelativeTime
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyIndexFrameReference");
				}
				
				return Windows_Kinect_BodyIndexFrameReference_get_RelativeTime(_pNative);
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_BodyIndexFrameReference_AcquireFrame(RootSystem.IntPtr pNative);
		public Windows.Kinect.BodyIndexFrame AcquireFrame()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("BodyIndexFrameReference");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_BodyIndexFrameReference_AcquireFrame(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.BodyIndexFrame>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.BodyIndexFrame(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.BodyIndexFrame>(objectPointer, obj);
			}
			
			return obj;
		}
		
	}
	
	//
	// Windows.Kinect.InfraredFrameReference
	//
	public partial class InfraredFrameReference
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal InfraredFrameReference(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_InfraredFrameReference_AddRefObject(ref _pNative);
		}
		
		~InfraredFrameReference()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_InfraredFrameReference_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_InfraredFrameReference_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<InfraredFrameReference>(_pNative);
			Windows_Kinect_InfraredFrameReference_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(InfraredFrameReference other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator InfraredFrameReference(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<InfraredFrameReference>(other);
			if(obj == null)
			{
				obj = new InfraredFrameReference(other);
				Helper.NativeObjectCache.AddObject<InfraredFrameReference>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_InfraredFrameReference_get_RelativeTime(RootSystem.IntPtr pNative);
		public  long RelativeTime
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("InfraredFrameReference");
				}
				
				return Windows_Kinect_InfraredFrameReference_get_RelativeTime(_pNative);
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_InfraredFrameReference_AcquireFrame(RootSystem.IntPtr pNative);
		public Windows.Kinect.InfraredFrame AcquireFrame()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("InfraredFrameReference");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_InfraredFrameReference_AcquireFrame(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.InfraredFrame>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.InfraredFrame(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.InfraredFrame>(objectPointer, obj);
			}
			
			return obj;
		}
		
	}
	
	//
	// Windows.Kinect.LongExposureInfraredFrameReference
	//
	public partial class LongExposureInfraredFrameReference
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal LongExposureInfraredFrameReference(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_LongExposureInfraredFrameReference_AddRefObject(ref _pNative);
		}
		
		~LongExposureInfraredFrameReference()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_LongExposureInfraredFrameReference_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_LongExposureInfraredFrameReference_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<LongExposureInfraredFrameReference>(_pNative);
			Windows_Kinect_LongExposureInfraredFrameReference_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(LongExposureInfraredFrameReference other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator LongExposureInfraredFrameReference(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<LongExposureInfraredFrameReference>(other);
			if(obj == null)
			{
				obj = new LongExposureInfraredFrameReference(other);
				Helper.NativeObjectCache.AddObject<LongExposureInfraredFrameReference>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_LongExposureInfraredFrameReference_get_RelativeTime(RootSystem.IntPtr pNative);
		public  long RelativeTime
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrameReference");
				}
				
				return Windows_Kinect_LongExposureInfraredFrameReference_get_RelativeTime(_pNative);
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_LongExposureInfraredFrameReference_AcquireFrame(RootSystem.IntPtr pNative);
		public Windows.Kinect.LongExposureInfraredFrame AcquireFrame()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrameReference");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_LongExposureInfraredFrameReference_AcquireFrame(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.LongExposureInfraredFrame>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.LongExposureInfraredFrame(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.LongExposureInfraredFrame>(objectPointer, obj);
			}
			
			return obj;
		}
		
	}
	
	//
	// Windows.Kinect.ColorFrame
	//
	public partial class ColorFrame : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal ColorFrame(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_ColorFrame_AddRefObject(ref _pNative);
		}
		
		~ColorFrame()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrame_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrame_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<ColorFrame>(_pNative);
			Windows_Kinect_ColorFrame_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_ColorFrame_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(ColorFrame other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator ColorFrame(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<ColorFrame>(other);
			if(obj == null)
			{
				obj = new ColorFrame(other);
				Helper.NativeObjectCache.AddObject<ColorFrame>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_ColorFrame_get_ColorCameraSettings(RootSystem.IntPtr pNative);
		public  Windows.Kinect.ColorCameraSettings ColorCameraSettings
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("ColorFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_ColorFrame_get_ColorCameraSettings(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.ColorCameraSettings>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.ColorCameraSettings(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.ColorCameraSettings>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_ColorFrame_get_ColorFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.ColorFrameSource ColorFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("ColorFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_ColorFrame_get_ColorFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.ColorFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.ColorFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.ColorFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_ColorFrame_get_FrameDescription(RootSystem.IntPtr pNative);
		public  Windows.Kinect.FrameDescription FrameDescription
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("ColorFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_ColorFrame_get_FrameDescription(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.FrameDescription>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.FrameDescription(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.FrameDescription>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.ColorImageFormat Windows_Kinect_ColorFrame_get_RawColorImageFormat(RootSystem.IntPtr pNative);
		public  Windows.Kinect.ColorImageFormat RawColorImageFormat
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("ColorFrame");
				}
				
				return Windows_Kinect_ColorFrame_get_RawColorImageFormat(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_ColorFrame_get_RelativeTime(RootSystem.IntPtr pNative);
		public  long RelativeTime
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("ColorFrame");
				}
				
				return Windows_Kinect_ColorFrame_get_RelativeTime(_pNative);
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrame_CopyRawFrameDataToArray(RootSystem.IntPtr pNative, byte[] frameData, int frameDataSize);
		public void CopyRawFrameDataToArray(byte[] frameData)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("ColorFrame");
			}
			
			Windows_Kinect_ColorFrame_CopyRawFrameDataToArray(_pNative, frameData, frameData.Length);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrame_CopyRawFrameDataToBuffer(RootSystem.IntPtr pNative, RootSystem.IntPtr buffer);
		public void CopyRawFrameDataToBuffer(Windows.Storage.Streams.IBuffer buffer)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("ColorFrame");
			}
			
			Windows_Kinect_ColorFrame_CopyRawFrameDataToBuffer(_pNative, buffer);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_ColorFrame_LockRawImageBuffer(RootSystem.IntPtr pNative);
		public Windows.Storage.Streams.IBuffer LockRawImageBuffer()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("ColorFrame");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_ColorFrame_LockRawImageBuffer(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Storage.Streams.IBuffer>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Storage.Streams.IBuffer(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Storage.Streams.IBuffer>(objectPointer, obj);
			}
			
			return obj;
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrame_CopyConvertedFrameDataToArray(RootSystem.IntPtr pNative, byte[] frameData, int frameDataSize, Windows.Kinect.ColorImageFormat colorFormat);
		public void CopyConvertedFrameDataToArray(byte[] frameData, Windows.Kinect.ColorImageFormat colorFormat)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("ColorFrame");
			}
			
			Windows_Kinect_ColorFrame_CopyConvertedFrameDataToArray(_pNative, frameData, frameData.Length, colorFormat);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrame_CopyConvertedFrameDataToBuffer(RootSystem.IntPtr pNative, RootSystem.IntPtr buffer, Windows.Kinect.ColorImageFormat colorFormat);
		public void CopyConvertedFrameDataToBuffer(Windows.Storage.Streams.IBuffer buffer, Windows.Kinect.ColorImageFormat colorFormat)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("ColorFrame");
			}
			
			Windows_Kinect_ColorFrame_CopyConvertedFrameDataToBuffer(_pNative, buffer, colorFormat);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_ColorFrame_CreateFrameDescription(RootSystem.IntPtr pNative, Windows.Kinect.ColorImageFormat format);
		public Windows.Kinect.FrameDescription CreateFrameDescription(Windows.Kinect.ColorImageFormat format)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("ColorFrame");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_ColorFrame_CreateFrameDescription(_pNative, format);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.FrameDescription>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.FrameDescription(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.FrameDescription>(objectPointer, obj);
			}
			
			return obj;
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrame_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("ColorFrame");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.FrameCapturedEventArgs
	//
	public partial class FrameCapturedEventArgs
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal FrameCapturedEventArgs(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_FrameCapturedEventArgs_AddRefObject(ref _pNative);
		}
		
		~FrameCapturedEventArgs()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_FrameCapturedEventArgs_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_FrameCapturedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<FrameCapturedEventArgs>(_pNative);
			Windows_Kinect_FrameCapturedEventArgs_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(FrameCapturedEventArgs other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator FrameCapturedEventArgs(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<FrameCapturedEventArgs>(other);
			if(obj == null)
			{
				obj = new FrameCapturedEventArgs(other);
				Helper.NativeObjectCache.AddObject<FrameCapturedEventArgs>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.FrameCapturedStatus Windows_Kinect_FrameCapturedEventArgs_get_FrameStatus(RootSystem.IntPtr pNative);
		public  Windows.Kinect.FrameCapturedStatus FrameStatus
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("FrameCapturedEventArgs");
				}
				
				return Windows_Kinect_FrameCapturedEventArgs_get_FrameStatus(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.FrameSourceTypes Windows_Kinect_FrameCapturedEventArgs_get_FrameType(RootSystem.IntPtr pNative);
		public  Windows.Kinect.FrameSourceTypes FrameType
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("FrameCapturedEventArgs");
				}
				
				return Windows_Kinect_FrameCapturedEventArgs_get_FrameType(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_FrameCapturedEventArgs_get_RelativeTime(RootSystem.IntPtr pNative);
		public  long RelativeTime
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("FrameCapturedEventArgs");
				}
				
				return Windows_Kinect_FrameCapturedEventArgs_get_RelativeTime(_pNative);
			}
		}
		
	}
	
	//
	// Windows.Kinect.ColorFrameReader
	//
	public partial class ColorFrameReader : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal ColorFrameReader(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_ColorFrameReader_AddRefObject(ref _pNative);
		}
		
		~ColorFrameReader()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrameReader_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrameReader_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<ColorFrameReader>(_pNative);
			Windows_Kinect_ColorFrameReader_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_ColorFrameReader_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(ColorFrameReader other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator ColorFrameReader(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<ColorFrameReader>(other);
			if(obj == null)
			{
				obj = new ColorFrameReader(other);
				Helper.NativeObjectCache.AddObject<ColorFrameReader>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_ColorFrameReader_get_ColorFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.ColorFrameSource ColorFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("ColorFrameReader");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_ColorFrameReader_get_ColorFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.ColorFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.ColorFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.ColorFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_ColorFrameReader_get_IsPaused(RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrameReader_put_IsPaused(RootSystem.IntPtr pNative, bool isPaused);
		public  bool IsPaused
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("ColorFrameReader");
				}
				
				return Windows_Kinect_ColorFrameReader_get_IsPaused(_pNative);
			}
			set
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("ColorFrameReader");
				}
				
				Windows_Kinect_ColorFrameReader_put_IsPaused(_pNative, value);
			}
		}
		
		
		// Events
		[RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		public delegate void Windows_Kinect_ColorFrameArrivedEventArgs_Delegate(Windows.Kinect.ColorFrameArrivedEventArgs args);
		private delegate void _Windows_Kinect_ColorFrameArrivedEventArgs_Delegate(RootSystem.IntPtr args);
		private static List<Windows_Kinect_ColorFrameArrivedEventArgs_Delegate> Windows_Kinect_ColorFrameArrivedEventArgs_Delegate_callbacks = new List<Windows_Kinect_ColorFrameArrivedEventArgs_Delegate>();
		[AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_ColorFrameArrivedEventArgs_Delegate))]
		private static void Windows_Kinect_ColorFrameArrivedEventArgs_Delegate_Handler(RootSystem.IntPtr result)
		{
			lock(Windows_Kinect_ColorFrameArrivedEventArgs_Delegate_callbacks)
			{
				foreach(var func in Windows_Kinect_ColorFrameArrivedEventArgs_Delegate_callbacks)
				{
					if(func != null)
					{
						func((Windows.Kinect.ColorFrameArrivedEventArgs)result);
					}
				}
			}
		}
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrameReader_add_FrameArrived(_Windows_Kinect_ColorFrameArrivedEventArgs_Delegate eventCallback, bool unsubscribe);
		public  event Windows_Kinect_ColorFrameArrivedEventArgs_Delegate FrameArrived
		{
			add
			{
				lock (Windows_Kinect_ColorFrameArrivedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_ColorFrameArrivedEventArgs_Delegate_callbacks.Add(value);
					if(Windows_Kinect_ColorFrameArrivedEventArgs_Delegate_callbacks.Count == 1)
					{
						Windows_Kinect_ColorFrameReader_add_FrameArrived(Windows_Kinect_ColorFrameArrivedEventArgs_Delegate_Handler, false);
					}
				}
			}
			remove
			{
				lock (Windows_Kinect_ColorFrameArrivedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_ColorFrameArrivedEventArgs_Delegate_callbacks.Remove(value);
					if(Windows_Kinect_ColorFrameArrivedEventArgs_Delegate_callbacks.Count == 0)
					{
						Windows_Kinect_ColorFrameReader_add_FrameArrived(Windows_Kinect_ColorFrameArrivedEventArgs_Delegate_Handler, true);
					}
				}
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_ColorFrameReader_AcquireLatestFrame(RootSystem.IntPtr pNative);
		public Windows.Kinect.ColorFrame AcquireLatestFrame()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("ColorFrameReader");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_ColorFrameReader_AcquireLatestFrame(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.ColorFrame>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.ColorFrame(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.ColorFrame>(objectPointer, obj);
			}
			
			return obj;
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrameReader_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("ColorFrameReader");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.FrameDescription
	//
	public partial class FrameDescription
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal FrameDescription(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_FrameDescription_AddRefObject(ref _pNative);
		}
		
		~FrameDescription()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_FrameDescription_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_FrameDescription_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<FrameDescription>(_pNative);
			Windows_Kinect_FrameDescription_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(FrameDescription other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator FrameDescription(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<FrameDescription>(other);
			if(obj == null)
			{
				obj = new FrameDescription(other);
				Helper.NativeObjectCache.AddObject<FrameDescription>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern uint Windows_Kinect_FrameDescription_get_BytesPerPixel(RootSystem.IntPtr pNative);
		public  uint BytesPerPixel
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("FrameDescription");
				}
				
				return Windows_Kinect_FrameDescription_get_BytesPerPixel(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern float Windows_Kinect_FrameDescription_get_DiagonalFieldOfView(RootSystem.IntPtr pNative);
		public  float DiagonalFieldOfView
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("FrameDescription");
				}
				
				return Windows_Kinect_FrameDescription_get_DiagonalFieldOfView(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_FrameDescription_get_Height(RootSystem.IntPtr pNative);
		public  int Height
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("FrameDescription");
				}
				
				return Windows_Kinect_FrameDescription_get_Height(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern float Windows_Kinect_FrameDescription_get_HorizontalFieldOfView(RootSystem.IntPtr pNative);
		public  float HorizontalFieldOfView
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("FrameDescription");
				}
				
				return Windows_Kinect_FrameDescription_get_HorizontalFieldOfView(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern uint Windows_Kinect_FrameDescription_get_LengthInPixels(RootSystem.IntPtr pNative);
		public  uint LengthInPixels
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("FrameDescription");
				}
				
				return Windows_Kinect_FrameDescription_get_LengthInPixels(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern float Windows_Kinect_FrameDescription_get_VerticalFieldOfView(RootSystem.IntPtr pNative);
		public  float VerticalFieldOfView
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("FrameDescription");
				}
				
				return Windows_Kinect_FrameDescription_get_VerticalFieldOfView(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_FrameDescription_get_Width(RootSystem.IntPtr pNative);
		public  int Width
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("FrameDescription");
				}
				
				return Windows_Kinect_FrameDescription_get_Width(_pNative);
			}
		}
		
	}
	
	//
	// Windows.Kinect.ColorFrameArrivedEventArgs
	//
	public partial class ColorFrameArrivedEventArgs
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal ColorFrameArrivedEventArgs(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_ColorFrameArrivedEventArgs_AddRefObject(ref _pNative);
		}
		
		~ColorFrameArrivedEventArgs()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrameArrivedEventArgs_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorFrameArrivedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<ColorFrameArrivedEventArgs>(_pNative);
			Windows_Kinect_ColorFrameArrivedEventArgs_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(ColorFrameArrivedEventArgs other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator ColorFrameArrivedEventArgs(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<ColorFrameArrivedEventArgs>(other);
			if(obj == null)
			{
				obj = new ColorFrameArrivedEventArgs(other);
				Helper.NativeObjectCache.AddObject<ColorFrameArrivedEventArgs>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_ColorFrameArrivedEventArgs_get_FrameReference(RootSystem.IntPtr pNative);
		public  Windows.Kinect.ColorFrameReference FrameReference
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("ColorFrameArrivedEventArgs");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_ColorFrameArrivedEventArgs_get_FrameReference(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.ColorFrameReference>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.ColorFrameReference(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.ColorFrameReference>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
	}
	
	//
	// Windows.Kinect.ColorCameraSettings
	//
	public partial class ColorCameraSettings
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal ColorCameraSettings(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_ColorCameraSettings_AddRefObject(ref _pNative);
		}
		
		~ColorCameraSettings()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorCameraSettings_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_ColorCameraSettings_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<ColorCameraSettings>(_pNative);
			Windows_Kinect_ColorCameraSettings_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(ColorCameraSettings other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator ColorCameraSettings(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<ColorCameraSettings>(other);
			if(obj == null)
			{
				obj = new ColorCameraSettings(other);
				Helper.NativeObjectCache.AddObject<ColorCameraSettings>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_ColorCameraSettings_get_ExposureTime(RootSystem.IntPtr pNative);
		public  long ExposureTime
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("ColorCameraSettings");
				}
				
				return Windows_Kinect_ColorCameraSettings_get_ExposureTime(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_ColorCameraSettings_get_FrameInterval(RootSystem.IntPtr pNative);
		public  long FrameInterval
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("ColorCameraSettings");
				}
				
				return Windows_Kinect_ColorCameraSettings_get_FrameInterval(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern float Windows_Kinect_ColorCameraSettings_get_Gain(RootSystem.IntPtr pNative);
		public  float Gain
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("ColorCameraSettings");
				}
				
				return Windows_Kinect_ColorCameraSettings_get_Gain(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern float Windows_Kinect_ColorCameraSettings_get_Gamma(RootSystem.IntPtr pNative);
		public  float Gamma
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("ColorCameraSettings");
				}
				
				return Windows_Kinect_ColorCameraSettings_get_Gamma(_pNative);
			}
		}
		
	}
	
	//
	// Windows.Kinect.DepthFrame
	//
	public partial class DepthFrame : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal DepthFrame(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_DepthFrame_AddRefObject(ref _pNative);
		}
		
		~DepthFrame()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_DepthFrame_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_DepthFrame_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<DepthFrame>(_pNative);
			Windows_Kinect_DepthFrame_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_DepthFrame_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(DepthFrame other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator DepthFrame(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<DepthFrame>(other);
			if(obj == null)
			{
				obj = new DepthFrame(other);
				Helper.NativeObjectCache.AddObject<DepthFrame>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_DepthFrame_get_DepthFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.DepthFrameSource DepthFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("DepthFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_DepthFrame_get_DepthFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.DepthFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.DepthFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.DepthFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern ushort Windows_Kinect_DepthFrame_get_DepthMaxReliableDistance(RootSystem.IntPtr pNative);
		public  ushort DepthMaxReliableDistance
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("DepthFrame");
				}
				
				return Windows_Kinect_DepthFrame_get_DepthMaxReliableDistance(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern ushort Windows_Kinect_DepthFrame_get_DepthMinReliableDistance(RootSystem.IntPtr pNative);
		public  ushort DepthMinReliableDistance
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("DepthFrame");
				}
				
				return Windows_Kinect_DepthFrame_get_DepthMinReliableDistance(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_DepthFrame_get_FrameDescription(RootSystem.IntPtr pNative);
		public  Windows.Kinect.FrameDescription FrameDescription
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("DepthFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_DepthFrame_get_FrameDescription(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.FrameDescription>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.FrameDescription(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.FrameDescription>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_DepthFrame_get_RelativeTime(RootSystem.IntPtr pNative);
		public  long RelativeTime
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("DepthFrame");
				}
				
				return Windows_Kinect_DepthFrame_get_RelativeTime(_pNative);
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_DepthFrame_CopyFrameDataToArray(RootSystem.IntPtr pNative, ushort[] frameData, int frameDataSize);
		public void CopyFrameDataToArray(ushort[] frameData)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("DepthFrame");
			}
			
			Windows_Kinect_DepthFrame_CopyFrameDataToArray(_pNative, frameData, frameData.Length);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_DepthFrame_CopyFrameDataToBuffer(RootSystem.IntPtr pNative, RootSystem.IntPtr buffer);
		public void CopyFrameDataToBuffer(Windows.Storage.Streams.IBuffer buffer)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("DepthFrame");
			}
			
			Windows_Kinect_DepthFrame_CopyFrameDataToBuffer(_pNative, buffer);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_DepthFrame_LockImageBuffer(RootSystem.IntPtr pNative);
		public Windows.Storage.Streams.IBuffer LockImageBuffer()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("DepthFrame");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_DepthFrame_LockImageBuffer(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Storage.Streams.IBuffer>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Storage.Streams.IBuffer(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Storage.Streams.IBuffer>(objectPointer, obj);
			}
			
			return obj;
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_DepthFrame_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("DepthFrame");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.DepthFrameReader
	//
	public partial class DepthFrameReader : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal DepthFrameReader(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_DepthFrameReader_AddRefObject(ref _pNative);
		}
		
		~DepthFrameReader()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_DepthFrameReader_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_DepthFrameReader_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<DepthFrameReader>(_pNative);
			Windows_Kinect_DepthFrameReader_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_DepthFrameReader_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(DepthFrameReader other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator DepthFrameReader(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<DepthFrameReader>(other);
			if(obj == null)
			{
				obj = new DepthFrameReader(other);
				Helper.NativeObjectCache.AddObject<DepthFrameReader>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_DepthFrameReader_get_DepthFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.DepthFrameSource DepthFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("DepthFrameReader");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_DepthFrameReader_get_DepthFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.DepthFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.DepthFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.DepthFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_DepthFrameReader_get_IsPaused(RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_DepthFrameReader_put_IsPaused(RootSystem.IntPtr pNative, bool isPaused);
		public  bool IsPaused
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("DepthFrameReader");
				}
				
				return Windows_Kinect_DepthFrameReader_get_IsPaused(_pNative);
			}
			set
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("DepthFrameReader");
				}
				
				Windows_Kinect_DepthFrameReader_put_IsPaused(_pNative, value);
			}
		}
		
		
		// Events
		[RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		public delegate void Windows_Kinect_DepthFrameArrivedEventArgs_Delegate(Windows.Kinect.DepthFrameArrivedEventArgs args);
		private delegate void _Windows_Kinect_DepthFrameArrivedEventArgs_Delegate(RootSystem.IntPtr args);
		private static List<Windows_Kinect_DepthFrameArrivedEventArgs_Delegate> Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_callbacks = new List<Windows_Kinect_DepthFrameArrivedEventArgs_Delegate>();
		[AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_DepthFrameArrivedEventArgs_Delegate))]
		private static void Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_Handler(RootSystem.IntPtr result)
		{
			lock(Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_callbacks)
			{
				foreach(var func in Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_callbacks)
				{
					if(func != null)
					{
						func((Windows.Kinect.DepthFrameArrivedEventArgs)result);
					}
				}
			}
		}
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_DepthFrameReader_add_FrameArrived(_Windows_Kinect_DepthFrameArrivedEventArgs_Delegate eventCallback, bool unsubscribe);
		public  event Windows_Kinect_DepthFrameArrivedEventArgs_Delegate FrameArrived
		{
			add
			{
				lock (Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_callbacks.Add(value);
					if(Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_callbacks.Count == 1)
					{
						Windows_Kinect_DepthFrameReader_add_FrameArrived(Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_Handler, false);
					}
				}
			}
			remove
			{
				lock (Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_callbacks.Remove(value);
					if(Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_callbacks.Count == 0)
					{
						Windows_Kinect_DepthFrameReader_add_FrameArrived(Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_Handler, true);
					}
				}
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_DepthFrameReader_AcquireLatestFrame(RootSystem.IntPtr pNative);
		public Windows.Kinect.DepthFrame AcquireLatestFrame()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("DepthFrameReader");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_DepthFrameReader_AcquireLatestFrame(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.DepthFrame>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.DepthFrame(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.DepthFrame>(objectPointer, obj);
			}
			
			return obj;
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_DepthFrameReader_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("DepthFrameReader");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.DepthFrameArrivedEventArgs
	//
	public partial class DepthFrameArrivedEventArgs
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal DepthFrameArrivedEventArgs(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_DepthFrameArrivedEventArgs_AddRefObject(ref _pNative);
		}
		
		~DepthFrameArrivedEventArgs()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_DepthFrameArrivedEventArgs_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_DepthFrameArrivedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<DepthFrameArrivedEventArgs>(_pNative);
			Windows_Kinect_DepthFrameArrivedEventArgs_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(DepthFrameArrivedEventArgs other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator DepthFrameArrivedEventArgs(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<DepthFrameArrivedEventArgs>(other);
			if(obj == null)
			{
				obj = new DepthFrameArrivedEventArgs(other);
				Helper.NativeObjectCache.AddObject<DepthFrameArrivedEventArgs>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_DepthFrameArrivedEventArgs_get_FrameReference(RootSystem.IntPtr pNative);
		public  Windows.Kinect.DepthFrameReference FrameReference
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("DepthFrameArrivedEventArgs");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_DepthFrameArrivedEventArgs_get_FrameReference(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.DepthFrameReference>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.DepthFrameReference(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.DepthFrameReference>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
	}
	
	//
	// Windows.Kinect.BodyFrame
	//
	public partial class BodyFrame : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal BodyFrame(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_BodyFrame_AddRefObject(ref _pNative);
		}
		
		~BodyFrame()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrame_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrame_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<BodyFrame>(_pNative);
			Windows_Kinect_BodyFrame_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_BodyFrame_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(BodyFrame other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator BodyFrame(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<BodyFrame>(other);
			if(obj == null)
			{
				obj = new BodyFrame(other);
				Helper.NativeObjectCache.AddObject<BodyFrame>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_BodyFrame_get_BodyCount(RootSystem.IntPtr pNative);
		public  int BodyCount
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyFrame");
				}
				
				return Windows_Kinect_BodyFrame_get_BodyCount(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_BodyFrame_get_BodyFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.BodyFrameSource BodyFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_BodyFrame_get_BodyFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.BodyFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.BodyFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.BodyFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.Vector4 Windows_Kinect_BodyFrame_get_FloorClipPlane(RootSystem.IntPtr pNative);
		public  Windows.Kinect.Vector4 FloorClipPlane
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyFrame");
				}
				
				return Windows_Kinect_BodyFrame_get_FloorClipPlane(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_BodyFrame_get_RelativeTime(RootSystem.IntPtr pNative);
		public  long RelativeTime
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyFrame");
				}
				
				return Windows_Kinect_BodyFrame_get_RelativeTime(_pNative);
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrame_GetAndRefreshBodyData(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] RootSystem.IntPtr[] bodies, int bodiesSize);
		public void GetAndRefreshBodyData(Windows.Kinect.Body[] bodies)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("BodyFrame");
			}
			
			int _bodies_idx=0;
			var _bodies = new RootSystem.IntPtr[bodies.Count()];
			foreach(var value in bodies)
			{
				_bodies[_bodies_idx] = (RootSystem.IntPtr)value;
				_bodies_idx++;
			}
			Windows_Kinect_BodyFrame_GetAndRefreshBodyData(_pNative, _bodies, bodies.Length);
			for(int i=0;i<bodies.Count();i++)
			{
				bodies[i] = (Windows.Kinect.Body)_bodies[i];
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrame_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("BodyFrame");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.BodyFrameReader
	//
	public partial class BodyFrameReader : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal BodyFrameReader(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_BodyFrameReader_AddRefObject(ref _pNative);
		}
		
		~BodyFrameReader()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrameReader_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrameReader_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<BodyFrameReader>(_pNative);
			Windows_Kinect_BodyFrameReader_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_BodyFrameReader_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(BodyFrameReader other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator BodyFrameReader(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<BodyFrameReader>(other);
			if(obj == null)
			{
				obj = new BodyFrameReader(other);
				Helper.NativeObjectCache.AddObject<BodyFrameReader>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_BodyFrameReader_get_BodyFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.BodyFrameSource BodyFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyFrameReader");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_BodyFrameReader_get_BodyFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.BodyFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.BodyFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.BodyFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_BodyFrameReader_get_IsPaused(RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrameReader_put_IsPaused(RootSystem.IntPtr pNative, bool isPaused);
		public  bool IsPaused
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyFrameReader");
				}
				
				return Windows_Kinect_BodyFrameReader_get_IsPaused(_pNative);
			}
			set
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyFrameReader");
				}
				
				Windows_Kinect_BodyFrameReader_put_IsPaused(_pNative, value);
			}
		}
		
		
		// Events
		[RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		public delegate void Windows_Kinect_BodyFrameArrivedEventArgs_Delegate(Windows.Kinect.BodyFrameArrivedEventArgs args);
		private delegate void _Windows_Kinect_BodyFrameArrivedEventArgs_Delegate(RootSystem.IntPtr args);
		private static List<Windows_Kinect_BodyFrameArrivedEventArgs_Delegate> Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_callbacks = new List<Windows_Kinect_BodyFrameArrivedEventArgs_Delegate>();
		[AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_BodyFrameArrivedEventArgs_Delegate))]
		private static void Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_Handler(RootSystem.IntPtr result)
		{
			lock(Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_callbacks)
			{
				foreach(var func in Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_callbacks)
				{
					if(func != null)
					{
						func((Windows.Kinect.BodyFrameArrivedEventArgs)result);
					}
				}
			}
		}
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrameReader_add_FrameArrived(_Windows_Kinect_BodyFrameArrivedEventArgs_Delegate eventCallback, bool unsubscribe);
		public  event Windows_Kinect_BodyFrameArrivedEventArgs_Delegate FrameArrived
		{
			add
			{
				lock (Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_callbacks.Add(value);
					if(Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_callbacks.Count == 1)
					{
						Windows_Kinect_BodyFrameReader_add_FrameArrived(Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_Handler, false);
					}
				}
			}
			remove
			{
				lock (Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_callbacks.Remove(value);
					if(Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_callbacks.Count == 0)
					{
						Windows_Kinect_BodyFrameReader_add_FrameArrived(Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_Handler, true);
					}
				}
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_BodyFrameReader_AcquireLatestFrame(RootSystem.IntPtr pNative);
		public Windows.Kinect.BodyFrame AcquireLatestFrame()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("BodyFrameReader");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_BodyFrameReader_AcquireLatestFrame(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.BodyFrame>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.BodyFrame(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.BodyFrame>(objectPointer, obj);
			}
			
			return obj;
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrameReader_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("BodyFrameReader");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.BodyFrameArrivedEventArgs
	//
	public partial class BodyFrameArrivedEventArgs
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal BodyFrameArrivedEventArgs(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_BodyFrameArrivedEventArgs_AddRefObject(ref _pNative);
		}
		
		~BodyFrameArrivedEventArgs()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrameArrivedEventArgs_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyFrameArrivedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<BodyFrameArrivedEventArgs>(_pNative);
			Windows_Kinect_BodyFrameArrivedEventArgs_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(BodyFrameArrivedEventArgs other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator BodyFrameArrivedEventArgs(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<BodyFrameArrivedEventArgs>(other);
			if(obj == null)
			{
				obj = new BodyFrameArrivedEventArgs(other);
				Helper.NativeObjectCache.AddObject<BodyFrameArrivedEventArgs>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_BodyFrameArrivedEventArgs_get_FrameReference(RootSystem.IntPtr pNative);
		public  Windows.Kinect.BodyFrameReference FrameReference
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyFrameArrivedEventArgs");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_BodyFrameArrivedEventArgs_get_FrameReference(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.BodyFrameReference>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.BodyFrameReference(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.BodyFrameReference>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
	}
	
	//
	// Windows.Kinect.Body
	//
	public partial class Body : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal Body(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_Body_AddRefObject(ref _pNative);
		}
		
		~Body()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_Body_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_Body_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<Body>(_pNative);
			Windows_Kinect_Body_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_Body_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(Body other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator Body(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<Body>(other);
			if(obj == null)
			{
				obj = new Body(other);
				Helper.NativeObjectCache.AddObject<Body>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_Body_get_Activities(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.Activity[] outKeys, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.DetectionResult[] outValues, int collectionSize);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_Body_get_Activities_Length(RootSystem.IntPtr pNative);
		public  RootSystem.Collections.Generic.Dictionary<Windows.Kinect.Activity, Windows.Kinect.DetectionResult> Activities
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("Body");
				}
				
				int collectionSize = Windows_Kinect_Body_get_Activities_Length(_pNative);
				var outKeys = new Windows.Kinect.Activity[collectionSize];
				var outValues = new Windows.Kinect.DetectionResult[collectionSize];
				var managedDictionary = new RootSystem.Collections.Generic.Dictionary<Windows.Kinect.Activity, Windows.Kinect.DetectionResult>();
				
				collectionSize = Windows_Kinect_Body_get_Activities(_pNative, outKeys, outValues, collectionSize);
				for(int i=0;i<collectionSize;i++)
				{
					managedDictionary.Add(outKeys[i], outValues[i]);
				}
				return managedDictionary;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_Body_get_Appearance(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.Appearance[] outKeys, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.DetectionResult[] outValues, int collectionSize);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_Body_get_Appearance_Length(RootSystem.IntPtr pNative);
		public  RootSystem.Collections.Generic.Dictionary<Windows.Kinect.Appearance, Windows.Kinect.DetectionResult> Appearance
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("Body");
				}
				
				int collectionSize = Windows_Kinect_Body_get_Appearance_Length(_pNative);
				var outKeys = new Windows.Kinect.Appearance[collectionSize];
				var outValues = new Windows.Kinect.DetectionResult[collectionSize];
				var managedDictionary = new RootSystem.Collections.Generic.Dictionary<Windows.Kinect.Appearance, Windows.Kinect.DetectionResult>();
				
				collectionSize = Windows_Kinect_Body_get_Appearance(_pNative, outKeys, outValues, collectionSize);
				for(int i=0;i<collectionSize;i++)
				{
					managedDictionary.Add(outKeys[i], outValues[i]);
				}
				return managedDictionary;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.FrameEdges Windows_Kinect_Body_get_ClippedEdges(RootSystem.IntPtr pNative);
		public  Windows.Kinect.FrameEdges ClippedEdges
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("Body");
				}
				
				return Windows_Kinect_Body_get_ClippedEdges(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.DetectionResult Windows_Kinect_Body_get_Engaged(RootSystem.IntPtr pNative);
		public  Windows.Kinect.DetectionResult Engaged
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("Body");
				}
				
				return Windows_Kinect_Body_get_Engaged(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_Body_get_Expressions(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.Expression[] outKeys, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.DetectionResult[] outValues, int collectionSize);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_Body_get_Expressions_Length(RootSystem.IntPtr pNative);
		public  RootSystem.Collections.Generic.Dictionary<Windows.Kinect.Expression, Windows.Kinect.DetectionResult> Expressions
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("Body");
				}
				
				int collectionSize = Windows_Kinect_Body_get_Expressions_Length(_pNative);
				var outKeys = new Windows.Kinect.Expression[collectionSize];
				var outValues = new Windows.Kinect.DetectionResult[collectionSize];
				var managedDictionary = new RootSystem.Collections.Generic.Dictionary<Windows.Kinect.Expression, Windows.Kinect.DetectionResult>();
				
				collectionSize = Windows_Kinect_Body_get_Expressions(_pNative, outKeys, outValues, collectionSize);
				for(int i=0;i<collectionSize;i++)
				{
					managedDictionary.Add(outKeys[i], outValues[i]);
				}
				return managedDictionary;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.TrackingConfidence Windows_Kinect_Body_get_HandLeftConfidence(RootSystem.IntPtr pNative);
		public  Windows.Kinect.TrackingConfidence HandLeftConfidence
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("Body");
				}
				
				return Windows_Kinect_Body_get_HandLeftConfidence(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.HandState Windows_Kinect_Body_get_HandLeftState(RootSystem.IntPtr pNative);
		public  Windows.Kinect.HandState HandLeftState
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("Body");
				}
				
				return Windows_Kinect_Body_get_HandLeftState(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.TrackingConfidence Windows_Kinect_Body_get_HandRightConfidence(RootSystem.IntPtr pNative);
		public  Windows.Kinect.TrackingConfidence HandRightConfidence
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("Body");
				}
				
				return Windows_Kinect_Body_get_HandRightConfidence(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.HandState Windows_Kinect_Body_get_HandRightState(RootSystem.IntPtr pNative);
		public  Windows.Kinect.HandState HandRightState
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("Body");
				}
				
				return Windows_Kinect_Body_get_HandRightState(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_Body_get_IsRestricted(RootSystem.IntPtr pNative);
		public  bool IsRestricted
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("Body");
				}
				
				return Windows_Kinect_Body_get_IsRestricted(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_Body_get_IsTracked(RootSystem.IntPtr pNative);
		public  bool IsTracked
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("Body");
				}
				
				return Windows_Kinect_Body_get_IsTracked(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_Body_get_JointOrientations(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.JointType[] outKeys, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.JointOrientation[] outValues, int collectionSize);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_Body_get_JointOrientations_Length(RootSystem.IntPtr pNative);
		public  RootSystem.Collections.Generic.Dictionary<Windows.Kinect.JointType, Windows.Kinect.JointOrientation> JointOrientations
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("Body");
				}
				
				int collectionSize = Windows_Kinect_Body_get_JointOrientations_Length(_pNative);
				var outKeys = new Windows.Kinect.JointType[collectionSize];
				var outValues = new Windows.Kinect.JointOrientation[collectionSize];
				var managedDictionary = new RootSystem.Collections.Generic.Dictionary<Windows.Kinect.JointType, Windows.Kinect.JointOrientation>();
				
				collectionSize = Windows_Kinect_Body_get_JointOrientations(_pNative, outKeys, outValues, collectionSize);
				for(int i=0;i<collectionSize;i++)
				{
					managedDictionary.Add(outKeys[i], outValues[i]);
				}
				return managedDictionary;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_Body_get_Joints(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.JointType[] outKeys, [RootSystem.Runtime.InteropServices.Out] Windows.Kinect.Joint[] outValues, int collectionSize);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_Body_get_Joints_Length(RootSystem.IntPtr pNative);
		public  RootSystem.Collections.Generic.Dictionary<Windows.Kinect.JointType, Windows.Kinect.Joint> Joints
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("Body");
				}
				
				int collectionSize = Windows_Kinect_Body_get_Joints_Length(_pNative);
				var outKeys = new Windows.Kinect.JointType[collectionSize];
				var outValues = new Windows.Kinect.Joint[collectionSize];
				var managedDictionary = new RootSystem.Collections.Generic.Dictionary<Windows.Kinect.JointType, Windows.Kinect.Joint>();
				
				collectionSize = Windows_Kinect_Body_get_Joints(_pNative, outKeys, outValues, collectionSize);
				for(int i=0;i<collectionSize;i++)
				{
					managedDictionary.Add(outKeys[i], outValues[i]);
				}
				return managedDictionary;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.TrackingState Windows_Kinect_Body_get_LeanTrackingState(RootSystem.IntPtr pNative);
		public  Windows.Kinect.TrackingState LeanTrackingState
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("Body");
				}
				
				return Windows_Kinect_Body_get_LeanTrackingState(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern ulong Windows_Kinect_Body_get_TrackingId(RootSystem.IntPtr pNative);
		public  ulong TrackingId
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("Body");
				}
				
				return Windows_Kinect_Body_get_TrackingId(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_Body_get_JointCount();
		public static int JointCount
		{
			get
			{
				return Windows_Kinect_Body_get_JointCount();
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_Body_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("Body");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.BodyIndexFrame
	//
	public partial class BodyIndexFrame : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal BodyIndexFrame(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_BodyIndexFrame_AddRefObject(ref _pNative);
		}
		
		~BodyIndexFrame()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyIndexFrame_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyIndexFrame_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<BodyIndexFrame>(_pNative);
			Windows_Kinect_BodyIndexFrame_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_BodyIndexFrame_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(BodyIndexFrame other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator BodyIndexFrame(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<BodyIndexFrame>(other);
			if(obj == null)
			{
				obj = new BodyIndexFrame(other);
				Helper.NativeObjectCache.AddObject<BodyIndexFrame>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_BodyIndexFrame_get_BodyIndexFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.BodyIndexFrameSource BodyIndexFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyIndexFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_BodyIndexFrame_get_BodyIndexFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.BodyIndexFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.BodyIndexFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.BodyIndexFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_BodyIndexFrame_get_FrameDescription(RootSystem.IntPtr pNative);
		public  Windows.Kinect.FrameDescription FrameDescription
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyIndexFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_BodyIndexFrame_get_FrameDescription(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.FrameDescription>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.FrameDescription(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.FrameDescription>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_BodyIndexFrame_get_RelativeTime(RootSystem.IntPtr pNative);
		public  long RelativeTime
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyIndexFrame");
				}
				
				return Windows_Kinect_BodyIndexFrame_get_RelativeTime(_pNative);
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyIndexFrame_CopyFrameDataToArray(RootSystem.IntPtr pNative, byte[] frameData, int frameDataSize);
		public void CopyFrameDataToArray(byte[] frameData)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("BodyIndexFrame");
			}
			
			Windows_Kinect_BodyIndexFrame_CopyFrameDataToArray(_pNative, frameData, frameData.Length);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyIndexFrame_CopyFrameDataToBuffer(RootSystem.IntPtr pNative, RootSystem.IntPtr buffer);
		public void CopyFrameDataToBuffer(Windows.Storage.Streams.IBuffer buffer)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("BodyIndexFrame");
			}
			
			Windows_Kinect_BodyIndexFrame_CopyFrameDataToBuffer(_pNative, buffer);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_BodyIndexFrame_LockImageBuffer(RootSystem.IntPtr pNative);
		public Windows.Storage.Streams.IBuffer LockImageBuffer()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("BodyIndexFrame");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_BodyIndexFrame_LockImageBuffer(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Storage.Streams.IBuffer>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Storage.Streams.IBuffer(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Storage.Streams.IBuffer>(objectPointer, obj);
			}
			
			return obj;
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyIndexFrame_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("BodyIndexFrame");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.BodyIndexFrameReader
	//
	public partial class BodyIndexFrameReader : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal BodyIndexFrameReader(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_BodyIndexFrameReader_AddRefObject(ref _pNative);
		}
		
		~BodyIndexFrameReader()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyIndexFrameReader_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyIndexFrameReader_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<BodyIndexFrameReader>(_pNative);
			Windows_Kinect_BodyIndexFrameReader_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_BodyIndexFrameReader_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(BodyIndexFrameReader other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator BodyIndexFrameReader(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<BodyIndexFrameReader>(other);
			if(obj == null)
			{
				obj = new BodyIndexFrameReader(other);
				Helper.NativeObjectCache.AddObject<BodyIndexFrameReader>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_BodyIndexFrameReader_get_BodyIndexFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.BodyIndexFrameSource BodyIndexFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyIndexFrameReader");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_BodyIndexFrameReader_get_BodyIndexFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.BodyIndexFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.BodyIndexFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.BodyIndexFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_BodyIndexFrameReader_get_IsPaused(RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyIndexFrameReader_put_IsPaused(RootSystem.IntPtr pNative, bool isPaused);
		public  bool IsPaused
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyIndexFrameReader");
				}
				
				return Windows_Kinect_BodyIndexFrameReader_get_IsPaused(_pNative);
			}
			set
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyIndexFrameReader");
				}
				
				Windows_Kinect_BodyIndexFrameReader_put_IsPaused(_pNative, value);
			}
		}
		
		
		// Events
		[RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		public delegate void Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate(Windows.Kinect.BodyIndexFrameArrivedEventArgs args);
		private delegate void _Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate(RootSystem.IntPtr args);
		private static List<Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate> Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_callbacks = new List<Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate>();
		[AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate))]
		private static void Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_Handler(RootSystem.IntPtr result)
		{
			lock(Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_callbacks)
			{
				foreach(var func in Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_callbacks)
				{
					if(func != null)
					{
						func((Windows.Kinect.BodyIndexFrameArrivedEventArgs)result);
					}
				}
			}
		}
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyIndexFrameReader_add_FrameArrived(_Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate eventCallback, bool unsubscribe);
		public  event Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate FrameArrived
		{
			add
			{
				lock (Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_callbacks.Add(value);
					if(Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_callbacks.Count == 1)
					{
						Windows_Kinect_BodyIndexFrameReader_add_FrameArrived(Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_Handler, false);
					}
				}
			}
			remove
			{
				lock (Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_callbacks.Remove(value);
					if(Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_callbacks.Count == 0)
					{
						Windows_Kinect_BodyIndexFrameReader_add_FrameArrived(Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_Handler, true);
					}
				}
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_BodyIndexFrameReader_AcquireLatestFrame(RootSystem.IntPtr pNative);
		public Windows.Kinect.BodyIndexFrame AcquireLatestFrame()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("BodyIndexFrameReader");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_BodyIndexFrameReader_AcquireLatestFrame(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.BodyIndexFrame>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.BodyIndexFrame(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.BodyIndexFrame>(objectPointer, obj);
			}
			
			return obj;
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyIndexFrameReader_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("BodyIndexFrameReader");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.BodyIndexFrameArrivedEventArgs
	//
	public partial class BodyIndexFrameArrivedEventArgs
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal BodyIndexFrameArrivedEventArgs(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_BodyIndexFrameArrivedEventArgs_AddRefObject(ref _pNative);
		}
		
		~BodyIndexFrameArrivedEventArgs()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyIndexFrameArrivedEventArgs_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_BodyIndexFrameArrivedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<BodyIndexFrameArrivedEventArgs>(_pNative);
			Windows_Kinect_BodyIndexFrameArrivedEventArgs_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(BodyIndexFrameArrivedEventArgs other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator BodyIndexFrameArrivedEventArgs(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<BodyIndexFrameArrivedEventArgs>(other);
			if(obj == null)
			{
				obj = new BodyIndexFrameArrivedEventArgs(other);
				Helper.NativeObjectCache.AddObject<BodyIndexFrameArrivedEventArgs>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_BodyIndexFrameArrivedEventArgs_get_FrameReference(RootSystem.IntPtr pNative);
		public  Windows.Kinect.BodyIndexFrameReference FrameReference
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("BodyIndexFrameArrivedEventArgs");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_BodyIndexFrameArrivedEventArgs_get_FrameReference(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.BodyIndexFrameReference>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.BodyIndexFrameReference(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.BodyIndexFrameReference>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
	}
	
	//
	// Windows.Kinect.InfraredFrame
	//
	public partial class InfraredFrame : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal InfraredFrame(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_InfraredFrame_AddRefObject(ref _pNative);
		}
		
		~InfraredFrame()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_InfraredFrame_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_InfraredFrame_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<InfraredFrame>(_pNative);
			Windows_Kinect_InfraredFrame_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_InfraredFrame_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(InfraredFrame other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator InfraredFrame(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<InfraredFrame>(other);
			if(obj == null)
			{
				obj = new InfraredFrame(other);
				Helper.NativeObjectCache.AddObject<InfraredFrame>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_InfraredFrame_get_FrameDescription(RootSystem.IntPtr pNative);
		public  Windows.Kinect.FrameDescription FrameDescription
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("InfraredFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_InfraredFrame_get_FrameDescription(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.FrameDescription>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.FrameDescription(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.FrameDescription>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_InfraredFrame_get_InfraredFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.InfraredFrameSource InfraredFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("InfraredFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_InfraredFrame_get_InfraredFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.InfraredFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.InfraredFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.InfraredFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_InfraredFrame_get_RelativeTime(RootSystem.IntPtr pNative);
		public  long RelativeTime
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("InfraredFrame");
				}
				
				return Windows_Kinect_InfraredFrame_get_RelativeTime(_pNative);
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_InfraredFrame_CopyFrameDataToArray(RootSystem.IntPtr pNative, ushort[] frameData, int frameDataSize);
		public void CopyFrameDataToArray(ushort[] frameData)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("InfraredFrame");
			}
			
			Windows_Kinect_InfraredFrame_CopyFrameDataToArray(_pNative, frameData, frameData.Length);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_InfraredFrame_CopyFrameDataToBuffer(RootSystem.IntPtr pNative, RootSystem.IntPtr buffer);
		public void CopyFrameDataToBuffer(Windows.Storage.Streams.IBuffer buffer)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("InfraredFrame");
			}
			
			Windows_Kinect_InfraredFrame_CopyFrameDataToBuffer(_pNative, buffer);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_InfraredFrame_LockImageBuffer(RootSystem.IntPtr pNative);
		public Windows.Storage.Streams.IBuffer LockImageBuffer()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("InfraredFrame");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_InfraredFrame_LockImageBuffer(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Storage.Streams.IBuffer>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Storage.Streams.IBuffer(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Storage.Streams.IBuffer>(objectPointer, obj);
			}
			
			return obj;
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_InfraredFrame_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("InfraredFrame");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.InfraredFrameReader
	//
	public partial class InfraredFrameReader : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal InfraredFrameReader(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_InfraredFrameReader_AddRefObject(ref _pNative);
		}
		
		~InfraredFrameReader()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_InfraredFrameReader_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_InfraredFrameReader_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<InfraredFrameReader>(_pNative);
			Windows_Kinect_InfraredFrameReader_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_InfraredFrameReader_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(InfraredFrameReader other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator InfraredFrameReader(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<InfraredFrameReader>(other);
			if(obj == null)
			{
				obj = new InfraredFrameReader(other);
				Helper.NativeObjectCache.AddObject<InfraredFrameReader>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_InfraredFrameReader_get_InfraredFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.InfraredFrameSource InfraredFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("InfraredFrameReader");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_InfraredFrameReader_get_InfraredFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.InfraredFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.InfraredFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.InfraredFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_InfraredFrameReader_get_IsPaused(RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_InfraredFrameReader_put_IsPaused(RootSystem.IntPtr pNative, bool isPaused);
		public  bool IsPaused
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("InfraredFrameReader");
				}
				
				return Windows_Kinect_InfraredFrameReader_get_IsPaused(_pNative);
			}
			set
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("InfraredFrameReader");
				}
				
				Windows_Kinect_InfraredFrameReader_put_IsPaused(_pNative, value);
			}
		}
		
		
		// Events
		[RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		public delegate void Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate(Windows.Kinect.InfraredFrameArrivedEventArgs args);
		private delegate void _Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate(RootSystem.IntPtr args);
		private static List<Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate> Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate_callbacks = new List<Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate>();
		[AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate))]
		private static void Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate_Handler(RootSystem.IntPtr result)
		{
			lock(Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate_callbacks)
			{
				foreach(var func in Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate_callbacks)
				{
					if(func != null)
					{
						func((Windows.Kinect.InfraredFrameArrivedEventArgs)result);
					}
				}
			}
		}
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_InfraredFrameReader_add_FrameArrived(_Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate eventCallback, bool unsubscribe);
		public  event Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate FrameArrived
		{
			add
			{
				lock (Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate_callbacks.Add(value);
					if(Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate_callbacks.Count == 1)
					{
						Windows_Kinect_InfraredFrameReader_add_FrameArrived(Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate_Handler, false);
					}
				}
			}
			remove
			{
				lock (Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate_callbacks.Remove(value);
					if(Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate_callbacks.Count == 0)
					{
						Windows_Kinect_InfraredFrameReader_add_FrameArrived(Windows_Kinect_InfraredFrameArrivedEventArgs_Delegate_Handler, true);
					}
				}
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_InfraredFrameReader_AcquireLatestFrame(RootSystem.IntPtr pNative);
		public Windows.Kinect.InfraredFrame AcquireLatestFrame()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("InfraredFrameReader");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_InfraredFrameReader_AcquireLatestFrame(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.InfraredFrame>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.InfraredFrame(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.InfraredFrame>(objectPointer, obj);
			}
			
			return obj;
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_InfraredFrameReader_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("InfraredFrameReader");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.InfraredFrameArrivedEventArgs
	//
	public partial class InfraredFrameArrivedEventArgs
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal InfraredFrameArrivedEventArgs(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_InfraredFrameArrivedEventArgs_AddRefObject(ref _pNative);
		}
		
		~InfraredFrameArrivedEventArgs()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_InfraredFrameArrivedEventArgs_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_InfraredFrameArrivedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<InfraredFrameArrivedEventArgs>(_pNative);
			Windows_Kinect_InfraredFrameArrivedEventArgs_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(InfraredFrameArrivedEventArgs other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator InfraredFrameArrivedEventArgs(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<InfraredFrameArrivedEventArgs>(other);
			if(obj == null)
			{
				obj = new InfraredFrameArrivedEventArgs(other);
				Helper.NativeObjectCache.AddObject<InfraredFrameArrivedEventArgs>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_InfraredFrameArrivedEventArgs_get_FrameReference(RootSystem.IntPtr pNative);
		public  Windows.Kinect.InfraredFrameReference FrameReference
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("InfraredFrameArrivedEventArgs");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_InfraredFrameArrivedEventArgs_get_FrameReference(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.InfraredFrameReference>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.InfraredFrameReference(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.InfraredFrameReference>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
	}
	
	//
	// Windows.Kinect.LongExposureInfraredFrame
	//
	public partial class LongExposureInfraredFrame : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal LongExposureInfraredFrame(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_LongExposureInfraredFrame_AddRefObject(ref _pNative);
		}
		
		~LongExposureInfraredFrame()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_LongExposureInfraredFrame_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_LongExposureInfraredFrame_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<LongExposureInfraredFrame>(_pNative);
			Windows_Kinect_LongExposureInfraredFrame_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_LongExposureInfraredFrame_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(LongExposureInfraredFrame other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator LongExposureInfraredFrame(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<LongExposureInfraredFrame>(other);
			if(obj == null)
			{
				obj = new LongExposureInfraredFrame(other);
				Helper.NativeObjectCache.AddObject<LongExposureInfraredFrame>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_LongExposureInfraredFrame_get_FrameDescription(RootSystem.IntPtr pNative);
		public  Windows.Kinect.FrameDescription FrameDescription
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_LongExposureInfraredFrame_get_FrameDescription(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.FrameDescription>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.FrameDescription(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.FrameDescription>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_LongExposureInfraredFrame_get_LongExposureInfraredFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.LongExposureInfraredFrameSource LongExposureInfraredFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_LongExposureInfraredFrame_get_LongExposureInfraredFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.LongExposureInfraredFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.LongExposureInfraredFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.LongExposureInfraredFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_LongExposureInfraredFrame_get_RelativeTime(RootSystem.IntPtr pNative);
		public  long RelativeTime
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrame");
				}
				
				return Windows_Kinect_LongExposureInfraredFrame_get_RelativeTime(_pNative);
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_LongExposureInfraredFrame_CopyFrameDataToArray(RootSystem.IntPtr pNative, ushort[] frameData, int frameDataSize);
		public void CopyFrameDataToArray(ushort[] frameData)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrame");
			}
			
			Windows_Kinect_LongExposureInfraredFrame_CopyFrameDataToArray(_pNative, frameData, frameData.Length);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_LongExposureInfraredFrame_CopyFrameDataToBuffer(RootSystem.IntPtr pNative, RootSystem.IntPtr buffer);
		public void CopyFrameDataToBuffer(Windows.Storage.Streams.IBuffer buffer)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrame");
			}
			
			Windows_Kinect_LongExposureInfraredFrame_CopyFrameDataToBuffer(_pNative, buffer);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_LongExposureInfraredFrame_LockImageBuffer(RootSystem.IntPtr pNative);
		public Windows.Storage.Streams.IBuffer LockImageBuffer()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrame");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_LongExposureInfraredFrame_LockImageBuffer(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Storage.Streams.IBuffer>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Storage.Streams.IBuffer(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Storage.Streams.IBuffer>(objectPointer, obj);
			}
			
			return obj;
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_LongExposureInfraredFrame_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrame");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.LongExposureInfraredFrameReader
	//
	public partial class LongExposureInfraredFrameReader : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal LongExposureInfraredFrameReader(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_LongExposureInfraredFrameReader_AddRefObject(ref _pNative);
		}
		
		~LongExposureInfraredFrameReader()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_LongExposureInfraredFrameReader_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_LongExposureInfraredFrameReader_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<LongExposureInfraredFrameReader>(_pNative);
			Windows_Kinect_LongExposureInfraredFrameReader_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_LongExposureInfraredFrameReader_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(LongExposureInfraredFrameReader other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator LongExposureInfraredFrameReader(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<LongExposureInfraredFrameReader>(other);
			if(obj == null)
			{
				obj = new LongExposureInfraredFrameReader(other);
				Helper.NativeObjectCache.AddObject<LongExposureInfraredFrameReader>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_LongExposureInfraredFrameReader_get_IsPaused(RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_LongExposureInfraredFrameReader_put_IsPaused(RootSystem.IntPtr pNative, bool isPaused);
		public  bool IsPaused
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrameReader");
				}
				
				return Windows_Kinect_LongExposureInfraredFrameReader_get_IsPaused(_pNative);
			}
			set
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrameReader");
				}
				
				Windows_Kinect_LongExposureInfraredFrameReader_put_IsPaused(_pNative, value);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_LongExposureInfraredFrameReader_get_LongExposureInfraredFrameSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.LongExposureInfraredFrameSource LongExposureInfraredFrameSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrameReader");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_LongExposureInfraredFrameReader_get_LongExposureInfraredFrameSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.LongExposureInfraredFrameSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.LongExposureInfraredFrameSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.LongExposureInfraredFrameSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		
		// Events
		[RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		public delegate void Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate(Windows.Kinect.LongExposureInfraredFrameArrivedEventArgs args);
		private delegate void _Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate(RootSystem.IntPtr args);
		private static List<Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate> Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate_callbacks = new List<Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate>();
		[AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate))]
		private static void Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate_Handler(RootSystem.IntPtr result)
		{
			lock(Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate_callbacks)
			{
				foreach(var func in Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate_callbacks)
				{
					if(func != null)
					{
						func((Windows.Kinect.LongExposureInfraredFrameArrivedEventArgs)result);
					}
				}
			}
		}
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_LongExposureInfraredFrameReader_add_FrameArrived(_Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate eventCallback, bool unsubscribe);
		public  event Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate FrameArrived
		{
			add
			{
				lock (Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate_callbacks.Add(value);
					if(Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate_callbacks.Count == 1)
					{
						Windows_Kinect_LongExposureInfraredFrameReader_add_FrameArrived(Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate_Handler, false);
					}
				}
			}
			remove
			{
				lock (Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate_callbacks.Remove(value);
					if(Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate_callbacks.Count == 0)
					{
						Windows_Kinect_LongExposureInfraredFrameReader_add_FrameArrived(Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_Delegate_Handler, true);
					}
				}
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_LongExposureInfraredFrameReader_AcquireLatestFrame(RootSystem.IntPtr pNative);
		public Windows.Kinect.LongExposureInfraredFrame AcquireLatestFrame()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrameReader");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_LongExposureInfraredFrameReader_AcquireLatestFrame(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.LongExposureInfraredFrame>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Kinect.LongExposureInfraredFrame(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Kinect.LongExposureInfraredFrame>(objectPointer, obj);
			}
			
			return obj;
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_LongExposureInfraredFrameReader_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrameReader");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.LongExposureInfraredFrameArrivedEventArgs
	//
	public partial class LongExposureInfraredFrameArrivedEventArgs
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal LongExposureInfraredFrameArrivedEventArgs(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_AddRefObject(ref _pNative);
		}
		
		~LongExposureInfraredFrameArrivedEventArgs()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<LongExposureInfraredFrameArrivedEventArgs>(_pNative);
			Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(LongExposureInfraredFrameArrivedEventArgs other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator LongExposureInfraredFrameArrivedEventArgs(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<LongExposureInfraredFrameArrivedEventArgs>(other);
			if(obj == null)
			{
				obj = new LongExposureInfraredFrameArrivedEventArgs(other);
				Helper.NativeObjectCache.AddObject<LongExposureInfraredFrameArrivedEventArgs>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_get_FrameReference(RootSystem.IntPtr pNative);
		public  Windows.Kinect.LongExposureInfraredFrameReference FrameReference
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrameArrivedEventArgs");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_LongExposureInfraredFrameArrivedEventArgs_get_FrameReference(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.LongExposureInfraredFrameReference>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.LongExposureInfraredFrameReference(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.LongExposureInfraredFrameReference>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
	}
	
	//
	// Windows.Kinect.AudioBeam
	//
	public partial class AudioBeam
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal AudioBeam(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_AudioBeam_AddRefObject(ref _pNative);
		}
		
		~AudioBeam()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeam_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeam_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<AudioBeam>(_pNative);
			Windows_Kinect_AudioBeam_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(AudioBeam other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator AudioBeam(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<AudioBeam>(other);
			if(obj == null)
			{
				obj = new AudioBeam(other);
				Helper.NativeObjectCache.AddObject<AudioBeam>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.AudioBeamMode Windows_Kinect_AudioBeam_get_AudioBeamMode(RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeam_put_AudioBeamMode(RootSystem.IntPtr pNative, Windows.Kinect.AudioBeamMode audioBeamMode);
		public  Windows.Kinect.AudioBeamMode AudioBeamMode
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeam");
				}
				
				return Windows_Kinect_AudioBeam_get_AudioBeamMode(_pNative);
			}
			set
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeam");
				}
				
				Windows_Kinect_AudioBeam_put_AudioBeamMode(_pNative, value);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_AudioBeam_get_AudioSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.AudioSource AudioSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeam");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_AudioBeam_get_AudioSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.AudioSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.AudioSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.AudioSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern float Windows_Kinect_AudioBeam_get_BeamAngle(RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeam_put_BeamAngle(RootSystem.IntPtr pNative, float beamAngle);
		public  float BeamAngle
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeam");
				}
				
				return Windows_Kinect_AudioBeam_get_BeamAngle(_pNative);
			}
			set
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeam");
				}
				
				Windows_Kinect_AudioBeam_put_BeamAngle(_pNative, value);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern float Windows_Kinect_AudioBeam_get_BeamAngleConfidence(RootSystem.IntPtr pNative);
		public  float BeamAngleConfidence
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeam");
				}
				
				return Windows_Kinect_AudioBeam_get_BeamAngleConfidence(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_AudioBeam_get_RelativeTime(RootSystem.IntPtr pNative);
		public  long RelativeTime
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeam");
				}
				
				return Windows_Kinect_AudioBeam_get_RelativeTime(_pNative);
			}
		}
		
		
		// Public Methods
	}
	
	//
	// Windows.Kinect.AudioBeamSubFrame
	//
	public partial class AudioBeamSubFrame : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal AudioBeamSubFrame(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_AudioBeamSubFrame_AddRefObject(ref _pNative);
		}
		
		~AudioBeamSubFrame()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamSubFrame_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamSubFrame_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<AudioBeamSubFrame>(_pNative);
			Windows_Kinect_AudioBeamSubFrame_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_AudioBeamSubFrame_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(AudioBeamSubFrame other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator AudioBeamSubFrame(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<AudioBeamSubFrame>(other);
			if(obj == null)
			{
				obj = new AudioBeamSubFrame(other);
				Helper.NativeObjectCache.AddObject<AudioBeamSubFrame>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern Windows.Kinect.AudioBeamMode Windows_Kinect_AudioBeamSubFrame_get_AudioBeamMode(RootSystem.IntPtr pNative);
		public  Windows.Kinect.AudioBeamMode AudioBeamMode
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
				}
				
				return Windows_Kinect_AudioBeamSubFrame_get_AudioBeamMode(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_AudioBeamSubFrame_get_AudioBodyCorrelations(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] RootSystem.IntPtr[] outCollection, int collectionSize);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_AudioBeamSubFrame_get_AudioBodyCorrelations_Length(RootSystem.IntPtr pNative);
		public  Windows.Kinect.AudioBodyCorrelation[] AudioBodyCorrelations
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
				}
				
				int collectionSize = Windows_Kinect_AudioBeamSubFrame_get_AudioBodyCorrelations_Length(_pNative);
				var outCollection = new RootSystem.IntPtr[collectionSize];
				var managedCollection = new Windows.Kinect.AudioBodyCorrelation[collectionSize];
				
				collectionSize = Windows_Kinect_AudioBeamSubFrame_get_AudioBodyCorrelations(_pNative, outCollection, collectionSize);
				for(int i=0;i<collectionSize;i++)
				{
					if(outCollection[i] == RootSystem.IntPtr.Zero)
					{
						continue;
					}
					
					outCollection[i] = Helper.NativeObjectCache.MapToIUnknown(outCollection[i]);
					var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.AudioBodyCorrelation>(outCollection[i]);
					if (obj == null)
					{
						obj = new Windows.Kinect.AudioBodyCorrelation(outCollection[i]);
						Helper.NativeObjectCache.AddObject<Windows.Kinect.AudioBodyCorrelation>(outCollection[i], obj);
					}
					
					managedCollection[i] = obj;
				}
				return managedCollection;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern float Windows_Kinect_AudioBeamSubFrame_get_BeamAngle(RootSystem.IntPtr pNative);
		public  float BeamAngle
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
				}
				
				return Windows_Kinect_AudioBeamSubFrame_get_BeamAngle(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern float Windows_Kinect_AudioBeamSubFrame_get_BeamAngleConfidence(RootSystem.IntPtr pNative);
		public  float BeamAngleConfidence
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
				}
				
				return Windows_Kinect_AudioBeamSubFrame_get_BeamAngleConfidence(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_AudioBeamSubFrame_get_Duration(RootSystem.IntPtr pNative);
		public  long Duration
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
				}
				
				return Windows_Kinect_AudioBeamSubFrame_get_Duration(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern uint Windows_Kinect_AudioBeamSubFrame_get_FrameLengthInBytes(RootSystem.IntPtr pNative);
		public  uint FrameLengthInBytes
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
				}
				
				return Windows_Kinect_AudioBeamSubFrame_get_FrameLengthInBytes(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_AudioBeamSubFrame_get_RelativeTime(RootSystem.IntPtr pNative);
		public  long RelativeTime
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
				}
				
				return Windows_Kinect_AudioBeamSubFrame_get_RelativeTime(_pNative);
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamSubFrame_CopyFrameDataToArray(RootSystem.IntPtr pNative, byte[] frameData, int frameDataSize);
		public void CopyFrameDataToArray(byte[] frameData)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
			}
			
			Windows_Kinect_AudioBeamSubFrame_CopyFrameDataToArray(_pNative, frameData, frameData.Length);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamSubFrame_CopyFrameDataToBuffer(RootSystem.IntPtr pNative, RootSystem.IntPtr buffer);
		public void CopyFrameDataToBuffer(Windows.Storage.Streams.IBuffer buffer)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
			}
			
			Windows_Kinect_AudioBeamSubFrame_CopyFrameDataToBuffer(_pNative, buffer);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_AudioBeamSubFrame_LockAudioBuffer(RootSystem.IntPtr pNative);
		public Windows.Storage.Streams.IBuffer LockAudioBuffer()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
			}
			
			RootSystem.IntPtr objectPointer = Windows_Kinect_AudioBeamSubFrame_LockAudioBuffer(_pNative);
			if (objectPointer == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			
			objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
			var obj = Helper.NativeObjectCache.GetObject<Windows.Storage.Streams.IBuffer>(objectPointer);
			if (obj == null)
			{
				obj = new Windows.Storage.Streams.IBuffer(objectPointer);
				Helper.NativeObjectCache.AddObject<Windows.Storage.Streams.IBuffer>(objectPointer, obj);
			}
			
			return obj;
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamSubFrame_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.AudioBodyCorrelation
	//
	public partial class AudioBodyCorrelation
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal AudioBodyCorrelation(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_AudioBodyCorrelation_AddRefObject(ref _pNative);
		}
		
		~AudioBodyCorrelation()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBodyCorrelation_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBodyCorrelation_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<AudioBodyCorrelation>(_pNative);
			Windows_Kinect_AudioBodyCorrelation_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(AudioBodyCorrelation other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator AudioBodyCorrelation(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<AudioBodyCorrelation>(other);
			if(obj == null)
			{
				obj = new AudioBodyCorrelation(other);
				Helper.NativeObjectCache.AddObject<AudioBodyCorrelation>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern ulong Windows_Kinect_AudioBodyCorrelation_get_BodyTrackingId(RootSystem.IntPtr pNative);
		public  ulong BodyTrackingId
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBodyCorrelation");
				}
				
				return Windows_Kinect_AudioBodyCorrelation_get_BodyTrackingId(_pNative);
			}
		}
		
	}
	
	//
	// Windows.Kinect.AudioBeamFrame
	//
	public partial class AudioBeamFrame : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal AudioBeamFrame(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_AudioBeamFrame_AddRefObject(ref _pNative);
		}
		
		~AudioBeamFrame()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamFrame_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamFrame_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<AudioBeamFrame>(_pNative);
			Windows_Kinect_AudioBeamFrame_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_AudioBeamFrame_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(AudioBeamFrame other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator AudioBeamFrame(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<AudioBeamFrame>(other);
			if(obj == null)
			{
				obj = new AudioBeamFrame(other);
				Helper.NativeObjectCache.AddObject<AudioBeamFrame>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_AudioBeamFrame_get_AudioBeam(RootSystem.IntPtr pNative);
		public  Windows.Kinect.AudioBeam AudioBeam
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeamFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_AudioBeamFrame_get_AudioBeam(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.AudioBeam>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.AudioBeam(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.AudioBeam>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_AudioBeamFrame_get_AudioSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.AudioSource AudioSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeamFrame");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_AudioBeamFrame_get_AudioSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.AudioSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.AudioSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.AudioSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_AudioBeamFrame_get_Duration(RootSystem.IntPtr pNative);
		public  long Duration
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeamFrame");
				}
				
				return Windows_Kinect_AudioBeamFrame_get_Duration(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_AudioBeamFrame_get_RelativeTimeStart(RootSystem.IntPtr pNative);
		public  long RelativeTimeStart
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeamFrame");
				}
				
				return Windows_Kinect_AudioBeamFrame_get_RelativeTimeStart(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_AudioBeamFrame_get_SubFrames(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] RootSystem.IntPtr[] outCollection, int collectionSize);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_AudioBeamFrame_get_SubFrames_Length(RootSystem.IntPtr pNative);
		public  Windows.Kinect.AudioBeamSubFrame[] SubFrames
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeamFrame");
				}
				
				int collectionSize = Windows_Kinect_AudioBeamFrame_get_SubFrames_Length(_pNative);
				var outCollection = new RootSystem.IntPtr[collectionSize];
				var managedCollection = new Windows.Kinect.AudioBeamSubFrame[collectionSize];
				
				collectionSize = Windows_Kinect_AudioBeamFrame_get_SubFrames(_pNative, outCollection, collectionSize);
				for(int i=0;i<collectionSize;i++)
				{
					if(outCollection[i] == RootSystem.IntPtr.Zero)
					{
						continue;
					}
					
					outCollection[i] = Helper.NativeObjectCache.MapToIUnknown(outCollection[i]);
					var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.AudioBeamSubFrame>(outCollection[i]);
					if (obj == null)
					{
						obj = new Windows.Kinect.AudioBeamSubFrame(outCollection[i]);
						Helper.NativeObjectCache.AddObject<Windows.Kinect.AudioBeamSubFrame>(outCollection[i], obj);
					}
					
					managedCollection[i] = obj;
				}
				return managedCollection;
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamFrame_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("AudioBeamFrame");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.AudioBeamFrameReference
	//
	public partial class AudioBeamFrameReference
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal AudioBeamFrameReference(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_AudioBeamFrameReference_AddRefObject(ref _pNative);
		}
		
		~AudioBeamFrameReference()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamFrameReference_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamFrameReference_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<AudioBeamFrameReference>(_pNative);
			Windows_Kinect_AudioBeamFrameReference_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(AudioBeamFrameReference other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator AudioBeamFrameReference(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<AudioBeamFrameReference>(other);
			if(obj == null)
			{
				obj = new AudioBeamFrameReference(other);
				Helper.NativeObjectCache.AddObject<AudioBeamFrameReference>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern long Windows_Kinect_AudioBeamFrameReference_get_RelativeTime(RootSystem.IntPtr pNative);
		public  long RelativeTime
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeamFrameReference");
				}
				
				return Windows_Kinect_AudioBeamFrameReference_get_RelativeTime(_pNative);
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_AudioBeamFrameReference_AcquireBeamFrames_Length(RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_AudioBeamFrameReference_AcquireBeamFrames(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] RootSystem.IntPtr[] outCollection, int collectionSize);
		public Windows.Kinect.AudioBeamFrame[] AcquireBeamFrames()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("AudioBeamFrameReference");
			}
			
			int collectionSize = Windows_Kinect_AudioBeamFrameReference_AcquireBeamFrames_Length(_pNative);
			var outCollection = new RootSystem.IntPtr[collectionSize];
			var managedCollection = new Windows.Kinect.AudioBeamFrame[collectionSize];
			
			collectionSize = Windows_Kinect_AudioBeamFrameReference_AcquireBeamFrames(_pNative, outCollection, collectionSize);
			for(int i=0;i<collectionSize;i++)
			{
				if(outCollection[i] == RootSystem.IntPtr.Zero)
				{
					continue;
				}
				
				outCollection[i] = Helper.NativeObjectCache.MapToIUnknown(outCollection[i]);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.AudioBeamFrame>(outCollection[i]);
				if (obj == null)
				{
					obj = new Windows.Kinect.AudioBeamFrame(outCollection[i]);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.AudioBeamFrame>(outCollection[i], obj);
				}
				
				managedCollection[i] = obj;
			}
			return managedCollection;
		}
		
	}
	
	//
	// Windows.Kinect.AudioBeamFrameReader
	//
	public partial class AudioBeamFrameReader : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal AudioBeamFrameReader(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_AudioBeamFrameReader_AddRefObject(ref _pNative);
		}
		
		~AudioBeamFrameReader()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamFrameReader_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamFrameReader_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<AudioBeamFrameReader>(_pNative);
			Windows_Kinect_AudioBeamFrameReader_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_AudioBeamFrameReader_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(AudioBeamFrameReader other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator AudioBeamFrameReader(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<AudioBeamFrameReader>(other);
			if(obj == null)
			{
				obj = new AudioBeamFrameReader(other);
				Helper.NativeObjectCache.AddObject<AudioBeamFrameReader>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_AudioBeamFrameReader_get_AudioSource(RootSystem.IntPtr pNative);
		public  Windows.Kinect.AudioSource AudioSource
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeamFrameReader");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_AudioBeamFrameReader_get_AudioSource(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.AudioSource>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.AudioSource(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.AudioSource>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern bool Windows_Kinect_AudioBeamFrameReader_get_IsPaused(RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamFrameReader_put_IsPaused(RootSystem.IntPtr pNative, bool isPaused);
		public  bool IsPaused
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeamFrameReader");
				}
				
				return Windows_Kinect_AudioBeamFrameReader_get_IsPaused(_pNative);
			}
			set
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeamFrameReader");
				}
				
				Windows_Kinect_AudioBeamFrameReader_put_IsPaused(_pNative, value);
			}
		}
		
		
		// Events
		[RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		public delegate void Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate(Windows.Kinect.AudioBeamFrameArrivedEventArgs args);
		private delegate void _Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate(RootSystem.IntPtr args);
		private static List<Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate> Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate_callbacks = new List<Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate>();
		[AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate))]
		private static void Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate_Handler(RootSystem.IntPtr result)
		{
			lock(Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate_callbacks)
			{
				foreach(var func in Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate_callbacks)
				{
					if(func != null)
					{
						func((Windows.Kinect.AudioBeamFrameArrivedEventArgs)result);
					}
				}
			}
		}
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamFrameReader_add_FrameArrived(_Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate eventCallback, bool unsubscribe);
		public  event Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate FrameArrived
		{
			add
			{
				lock (Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate_callbacks.Add(value);
					if(Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate_callbacks.Count == 1)
					{
						Windows_Kinect_AudioBeamFrameReader_add_FrameArrived(Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate_Handler, false);
					}
				}
			}
			remove
			{
				lock (Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate_callbacks)
				{
					Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate_callbacks.Remove(value);
					if(Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate_callbacks.Count == 0)
					{
						Windows_Kinect_AudioBeamFrameReader_add_FrameArrived(Windows_Kinect_AudioBeamFrameArrivedEventArgs_Delegate_Handler, true);
					}
				}
			}
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_AudioBeamFrameReader_AcquireLatestBeamFrames_Length(RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern int Windows_Kinect_AudioBeamFrameReader_AcquireLatestBeamFrames(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] RootSystem.IntPtr[] outCollection, int collectionSize);
		public Windows.Kinect.AudioBeamFrame[] AcquireLatestBeamFrames()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("AudioBeamFrameReader");
			}
			
			int collectionSize = Windows_Kinect_AudioBeamFrameReader_AcquireLatestBeamFrames_Length(_pNative);
			var outCollection = new RootSystem.IntPtr[collectionSize];
			var managedCollection = new Windows.Kinect.AudioBeamFrame[collectionSize];
			
			collectionSize = Windows_Kinect_AudioBeamFrameReader_AcquireLatestBeamFrames(_pNative, outCollection, collectionSize);
			for(int i=0;i<collectionSize;i++)
			{
				if(outCollection[i] == RootSystem.IntPtr.Zero)
				{
					continue;
				}
				
				outCollection[i] = Helper.NativeObjectCache.MapToIUnknown(outCollection[i]);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.AudioBeamFrame>(outCollection[i]);
				if (obj == null)
				{
					obj = new Windows.Kinect.AudioBeamFrame(outCollection[i]);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.AudioBeamFrame>(outCollection[i], obj);
				}
				
				managedCollection[i] = obj;
			}
			return managedCollection;
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamFrameReader_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("AudioBeamFrameReader");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	//
	// Windows.Kinect.AudioBeamFrameArrivedEventArgs
	//
	public partial class AudioBeamFrameArrivedEventArgs
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal AudioBeamFrameArrivedEventArgs(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_AudioBeamFrameArrivedEventArgs_AddRefObject(ref _pNative);
		}
		
		~AudioBeamFrameArrivedEventArgs()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamFrameArrivedEventArgs_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamFrameArrivedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<AudioBeamFrameArrivedEventArgs>(_pNative);
			Windows_Kinect_AudioBeamFrameArrivedEventArgs_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(AudioBeamFrameArrivedEventArgs other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator AudioBeamFrameArrivedEventArgs(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<AudioBeamFrameArrivedEventArgs>(other);
			if(obj == null)
			{
				obj = new AudioBeamFrameArrivedEventArgs(other);
				Helper.NativeObjectCache.AddObject<AudioBeamFrameArrivedEventArgs>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern RootSystem.IntPtr Windows_Kinect_AudioBeamFrameArrivedEventArgs_get_FrameReference(RootSystem.IntPtr pNative);
		public  Windows.Kinect.AudioBeamFrameReference FrameReference
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("AudioBeamFrameArrivedEventArgs");
				}
				
				RootSystem.IntPtr objectPointer = Windows_Kinect_AudioBeamFrameArrivedEventArgs_get_FrameReference(_pNative);
				if (objectPointer == RootSystem.IntPtr.Zero)
				{
					return null;
				}
				
				objectPointer = Helper.NativeObjectCache.MapToIUnknown(objectPointer);
				var obj = Helper.NativeObjectCache.GetObject<Windows.Kinect.AudioBeamFrameReference>(objectPointer);
				if (obj == null)
				{
					obj = new Windows.Kinect.AudioBeamFrameReference(objectPointer);
					Helper.NativeObjectCache.AddObject<Windows.Kinect.AudioBeamFrameReference>(objectPointer, obj);
				}
				
				return obj;
			}
		}
		
	}
	
	//
	// Windows.Kinect.CoordinateMappingChangedEventArgs
	//
	public partial class CoordinateMappingChangedEventArgs
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal CoordinateMappingChangedEventArgs(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_CoordinateMappingChangedEventArgs_AddRefObject(ref _pNative);
		}
		
		~CoordinateMappingChangedEventArgs()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_CoordinateMappingChangedEventArgs_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_CoordinateMappingChangedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<CoordinateMappingChangedEventArgs>(_pNative);
			Windows_Kinect_CoordinateMappingChangedEventArgs_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(CoordinateMappingChangedEventArgs other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator CoordinateMappingChangedEventArgs(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<CoordinateMappingChangedEventArgs>(other);
			if(obj == null)
			{
				obj = new CoordinateMappingChangedEventArgs(other);
				Helper.NativeObjectCache.AddObject<CoordinateMappingChangedEventArgs>(other, obj);
			}
			return obj;
		}
		
	}
	
	//
	// Windows.Kinect.AudioBeamFrameList
	//
	public partial class AudioBeamFrameList : RootSystem.IDisposable
		
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal AudioBeamFrameList(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Kinect_AudioBeamFrameList_AddRefObject(ref _pNative);
		}
		
		~AudioBeamFrameList()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamFrameList_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamFrameList_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<AudioBeamFrameList>(_pNative);
			Windows_Kinect_AudioBeamFrameList_ReleaseObject(ref _pNative);
			
			if (disposing)
			{
				Windows_Kinect_AudioBeamFrameList_Dispose(_pNative);
			}
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(AudioBeamFrameList other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator AudioBeamFrameList(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<AudioBeamFrameList>(other);
			if(obj == null)
			{
				obj = new AudioBeamFrameList(other);
				Helper.NativeObjectCache.AddObject<AudioBeamFrameList>(other, obj);
			}
			return obj;
		}
		
		
		// Public Methods
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Kinect_AudioBeamFrameList_Dispose(RootSystem.IntPtr pNative);
		public void Dispose()
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				throw new RootSystem.ObjectDisposedException("AudioBeamFrameList");
			}
			
			Dispose(true);
			RootSystem.GC.SuppressFinalize(this);
		}
		
	}
	
	#endregion // Classes
}

namespace Windows.Kinect
{
	
	#region Structs
	
	#endregion // Structs
	
	#region Classes
	
	#endregion // Classes
}

namespace Windows.Storage.Streams
{
	
	#region Classes
	
	//
	// Windows.Storage.Streams.IBuffer
	//
	public partial class IBuffer
	{
		protected internal RootSystem.IntPtr _pNative;
		
		// Constructors and Finalizers
		internal IBuffer(RootSystem.IntPtr pNative)
		{
			_pNative = pNative;
			Windows_Storage_Streams_IBuffer_AddRefObject(ref _pNative);
		}
		
		~IBuffer()
		{
			Dispose(false);
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Storage_Streams_IBuffer_ReleaseObject(ref RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Storage_Streams_IBuffer_AddRefObject(ref RootSystem.IntPtr pNative);
		protected virtual void Dispose(bool disposing)
		{
			if (_pNative == RootSystem.IntPtr.Zero)
			{
				return;
			}
			
			Helper.NativeObjectCache.RemoveObject<IBuffer>(_pNative);
			Windows_Storage_Streams_IBuffer_ReleaseObject(ref _pNative);
			
			_pNative = RootSystem.IntPtr.Zero;
		}
		
		public static implicit operator RootSystem.IntPtr(IBuffer other)
		{
			if(other != null)
			{
				return other._pNative;
			}
			return RootSystem.IntPtr.Zero;
		}
		
		public static explicit operator IBuffer(RootSystem.IntPtr other)
		{
			if(other == RootSystem.IntPtr.Zero)
			{
				return null;
			}
			other = Helper.NativeObjectCache.MapToIUnknown(other);
			var obj = Helper.NativeObjectCache.GetObject<IBuffer>(other);
			if(obj == null)
			{
				obj = new IBuffer(other);
				Helper.NativeObjectCache.AddObject<IBuffer>(other, obj);
			}
			return obj;
		}
		
		
		// Public Properties
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern uint Windows_Storage_Streams_IBuffer_get_Capacity(RootSystem.IntPtr pNative);
		public  uint Capacity
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("IBuffer");
				}
				
				return Windows_Storage_Streams_IBuffer_get_Capacity(_pNative);
			}
		}
		
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern uint Windows_Storage_Streams_IBuffer_get_Length(RootSystem.IntPtr pNative);
		[RootSystem.Runtime.InteropServices.DllImport("KinectForUnity", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
		private static extern void Windows_Storage_Streams_IBuffer_put_Length(RootSystem.IntPtr pNative, uint value);
		public  uint Length
		{
			get
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("IBuffer");
				}
				
				return Windows_Storage_Streams_IBuffer_get_Length(_pNative);
			}
			set
			{
				if (_pNative == RootSystem.IntPtr.Zero)
				{
					throw new RootSystem.ObjectDisposedException("IBuffer");
				}
				
				Windows_Storage_Streams_IBuffer_put_Length(_pNative, value);
			}
		}
		
	}
	
	#endregion // Classes
}

