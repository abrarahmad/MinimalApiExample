using Bogus;
using Contract.Dtos;

namespace Repository.Data
{
    public static class FakeMovie
    {
        public static IList<MovieDto> GenerateMovies()
        {
            var movieFaker = new Faker<MovieDto>()
                .RuleFor(_ => _.Name, (f, u) => f.Random.Word());
            var movies = movieFaker.Generate(50);
            return movies;
        }
    }
    
}
