using Microsoft.Practices.Unity;

namespace IoCTesting.IoC
{
    public class TrackedTransientLifetimeManager : TransientLifetimeManager
    {
        public override void SetValue(object newValue)
        {
            ResolutionTracker.Instance.TrackResolution(resolvedType: newValue.GetType());
            base.SetValue(newValue);
        }
    }
}