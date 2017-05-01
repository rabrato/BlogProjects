using IoCTesting.Models;
using Microsoft.Practices.Unity;

namespace IoCTesting.IoC
{
    public class DI_Container
    {
        private readonly ILifetimeManagerFactory _lifetimeManagerFactory;
        private readonly UnityContainer _container;

        public DI_Container(ILifetimeManagerFactory lifetimeManagerFactory)
        {
            _lifetimeManagerFactory = lifetimeManagerFactory;
            _container = new UnityContainer();
        }

        public void RegisterDependencies()
        {
            _container.RegisterType<IVideo, Video>(GetTransenLifetimeManager());

            _container.RegisterType<IAudio, EnglishAudio>(Language.English.ToString(), GetTransenLifetimeManager());
            _container.RegisterType<IAudio, SpanishAudio>(Language.Spanish.ToString(), GetTransenLifetimeManager());

            RegisterMovie(Language.English);
            RegisterMovie(Language.Spanish);
        }

        public T Resolve<T>(string resolutionName = null)
        {
            return _container.Resolve<T>(resolutionName);
        }

        private void RegisterMovie(Language language)
        {
            _container.RegisterType<IMovie, Movie>(language.ToString(), GetTransenLifetimeManager(),
                new InjectionFactory((c) => new Movie(
                    c.Resolve<IVideo>(),
                    c.Resolve<IAudio>(language.ToString())
                )));
        }

        private TransientLifetimeManager GetTransenLifetimeManager()
        {
            return _lifetimeManagerFactory.CreateTransientLifetimeManager();
        }
    }
}