using Microsoft.Practices.Unity;

namespace IoCTesting.IoC
{
    public interface ILifetimeManagerFactory
    {
        TransientLifetimeManager CreateTransientLifetimeManager();
        ContainerControlledLifetimeManager CreateContainerControlledLifetimeManager();
    }
}