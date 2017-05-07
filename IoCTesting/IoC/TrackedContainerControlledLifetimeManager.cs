using Microsoft.Practices.Unity;

namespace IoCTesting.IoC
{
    public class TrackedContainerControlledLifetimeManager : ContainerControlledLifetimeManager
    {
        public override void SetValue(object newValue)
        {
            ResolutionTracker.Instance.TrackResolution(resolvedType: newValue.GetType());
            base.SetValue(newValue);
        }
    }
}