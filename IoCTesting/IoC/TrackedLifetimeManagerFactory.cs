using Microsoft.Practices.Unity;

namespace IoCTesting.IoC
{
    public class TrackedLifetimeManagerFactory : ILifetimeManagerFactory
    {
        public TransientLifetimeManager CreateTransientLifetimeManager()
        {
            return new TrackedTransientLifetimeManager();
        }

        public ContainerControlledLifetimeManager CreateContainerControlledLifetimeManager()
        {
            return new TrackedContainerControlledLifetimeManager();
        }
    }
}