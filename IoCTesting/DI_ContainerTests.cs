using System;
using System.Linq;
using IoCTesting.IoC;
using IoCTesting.Models;
using Xunit;

namespace IoCTesting
{
    public class DI_ContainerTests
    {
        private DI_Container _container;

        public DI_ContainerTests()
        {
            _container = new DI_Container(new TrackedLifetimeManagerFactory());
            _container.RegisterDependencies();

            ResolutionTracker.Instance.ResetTracking();
        }

        [Fact]
        public void TestVideoResolution()
        {
            IVideo video = _container.Resolve<IVideo>();
            Assert.IsType<Video>(video);
        }

        [Fact]
        public void TestEnglishAudioResolution()
        {
            IAudio audio = _container.Resolve<IAudio>(Language.English.ToString());
            Assert.IsType<EnglishAudio>(audio);
        }

        [Fact]
        public void TestSpanishAudioResolution()
        {
            IAudio audio = _container.Resolve<IAudio>(Language.Spanish.ToString());
            Assert.IsType<SpanishAudio>(audio);
        }

        [Fact]
        public void TestEnglishMovieResolution()
        {
            IMovie movie = _container.Resolve<IMovie>(Language.English.ToString());
            Assert.IsType<Movie>(movie);
            Assert.Equal(1, ResolutionTracker.Instance.GetResolutionCount<EnglishAudio>());
        }

        [Fact]
        public void TestSpanishMovieResolution()
        {
            IMovie movie = _container.Resolve<IMovie>(Language.Spanish.ToString());
            Assert.IsType<Movie>(movie);
            Assert.Equal(1, ResolutionTracker.Instance.GetResolutionCount<SpanishAudio>());
        }
    }
}