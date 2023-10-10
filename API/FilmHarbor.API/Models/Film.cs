namespace FilmHarbor.API.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public IEnumerable<string> Genre { get; set; }

        public Film(int id, string title, int releaseYear, string director, IEnumerable<string> genre)
        {
            Id = id;
            Title = title;
            ReleaseYear = releaseYear;
            Director = director;
            Genre = genre;
        }
    }
}
