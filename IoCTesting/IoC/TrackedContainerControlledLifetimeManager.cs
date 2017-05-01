using Microsoft.Practices.Unity;

namespace IoCTesting.IoC
{
    public class TrackedContainerControlledLifetimeManager : ContainerControlledLifetimeManager
    {
        public override void SetValue(object newValue)
        {
            ResolutionTracker.TrackResolution(resolvedType: newValue.GetType());
            base.SetValue(newValue);
        }
    }
}