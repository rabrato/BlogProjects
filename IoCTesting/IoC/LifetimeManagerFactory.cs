using Microsoft.Practices.Unity;

namespace IoCTesting.IoC
{
    public class LifetimeManagerFactory : ILifetimeManagerFactory
    {
        public TransientLifetimeManager CreateTransientLifetimeManager()
        {
            return new TransientLifetimeManager();
        }

        public ContainerControlledLifetimeManager CreateContainerControlledLifetimeManager()
        {
            return new ContainerControlledLifetimeManager();
        }
    }
}