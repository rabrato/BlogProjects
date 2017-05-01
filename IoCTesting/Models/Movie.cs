namespace IoCTesting.Models
{
    public class Movie : IMovie
    {
        private IVideo _video;
        private IAudio _audio;

        public Movie(IVideo video, IAudio audio)
        {
            _video = video;
            _audio = audio;
        }
    }
}