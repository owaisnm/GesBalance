using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class MonoPInvokeCallbackAttribute : System.Attribute
{
	public System.Type RootType { get; set; }
	public MonoPInvokeCallbackAttribute(System.Type t) { RootType = t; }
}

namespace Windows.Foundation
{
    public struct Point
    {
    }
}

namespace Helper
{
    public static class NativeObjectCache
    {
        private static object _lock = new object();
        private static Dictionary<Type, Dictionary<IntPtr, WeakReference>> _objectCache = new Dictionary<Type, Dictionary<IntPtr, WeakReference>>();
        
        public static IntPtr MapToIUnknown(IntPtr nativePtr)
        {
            //private static Guid _guidIUnknown = new Guid("00000000-0000-0000-C000-000000000046");
            // NOTE: The IntPtr needs to use the IUnknown identity
            return nativePtr;
        }
        
        public static void AddObject<T>(IntPtr nativePtr, T obj) where T : class
        {
            lock (_lock)
            {
                Dictionary<IntPtr, WeakReference> objCache = null;
                
				if (!_objectCache.TryGetValue(typeof(T), out objCache) || objCache == null)
                {
                    objCache = new Dictionary<IntPtr, WeakReference>();
                    _objectCache[typeof(T)] = objCache;
                }
                
                objCache[nativePtr] = new WeakReference (obj);
            }
        }
        
        public static void RemoveObject<T>(IntPtr nativePtr)
        {
            lock (_lock)
            {
                Dictionary<IntPtr, WeakReference> objCache = null;
                
				if (!_objectCache.TryGetValue(typeof(T), out objCache) || objCache == null)
                {
                    objCache = new Dictionary<IntPtr, WeakReference>();
                    _objectCache[typeof(T)] = objCache;
                }
                
                if (objCache.ContainsKey(nativePtr))
                {
                    objCache.Remove(nativePtr);
                }
            }
        }
        
        public static T GetObject<T>(IntPtr nativePtr) where T : class
        {
            lock (_lock) 
            {
                Dictionary<IntPtr, WeakReference> objCache = null;
                
                if (!_objectCache.TryGetValue(typeof(T), out objCache) || objCache == null)
                {
                    objCache = new Dictionary<IntPtr, WeakReference>();
                    _objectCache[typeof(T)] = objCache;
                }
                
                WeakReference reference = null;
                if (objCache.TryGetValue(nativePtr, out reference)) 
                {
                	if(reference != null)
                	{
	                    T obj = reference.Target as T; 
	                    if(obj != null)
	                    {
	                        return (T)obj;
	                    }
                    }
                }
                
                return null;
            }
        }
    }
}
