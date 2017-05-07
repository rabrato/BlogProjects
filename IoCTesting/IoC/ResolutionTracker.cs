using System;
using System.Collections.Generic;
using System.Threading;

namespace IoCTesting.IoC
{
    public class ResolutionTracker
    {
        #region Fields

        private Dictionary<Type, int> _resolvedTypesCounter = new Dictionary<Type, int>();

        #endregion Fields

        #region static Fields

        private static volatile ResolutionTracker _instance;
        private static object syncRoot = new Object();

        #endregion static Fields

        #region Static Properties

        public static ResolutionTracker Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                            _instance = new ResolutionTracker();
                    }
                }

                return _instance;
            }
        }

        #endregion Static Properties

        #region Constructors

        private ResolutionTracker()
        {
        }

        #endregion Constructors

        #region Public Methods

        public void TrackResolution(Type resolvedType)
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

        public void ResetTracking()
        {
            _resolvedTypesCounter = new Dictionary<Type, int>();
        }

        public int GetResolutionCount<T>()
        {
            Type resolvedType = typeof(T);
            if (_resolvedTypesCounter.ContainsKey(resolvedType))
            {
                return _resolvedTypesCounter[resolvedType];
            }
            else
            {
                return 0;
            }
        }

        #endregion Public Methods
    }
}