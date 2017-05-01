using System;
using System.Collections.Generic;
using System.Threading;

namespace IoCTesting.IoC
{
    public static class ResolutionTracker
    {
        static Dictionary<Type, int> _resolvedTypesCounter = new Dictionary<Type, int>();
        static readonly object _counterLock = new object();

        public static void TrackResolution(Type resolvedType)
        {
            lock (_counterLock)
            {
                if (_resolvedTypesCounter.ContainsKey(resolvedType))
                {
                    _resolvedTypesCounter[resolvedType]++;
                }
                else
                {
                    _resolvedTypesCounter.Add(resolvedType, 1);
                }
            }
        }

        public static void ResetTracking()
        {
            lock (_counterLock)
            {
                _resolvedTypesCounter = new Dictionary<Type, int>();
            }
        }

        public static int GetResolutionCount<T>()
        {
            Type resolvedType = typeof(T);
            lock (_counterLock)
            {
                if (_resolvedTypesCounter.ContainsKey(resolvedType))
                {
                    return _resolvedTypesCounter[resolvedType];
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}