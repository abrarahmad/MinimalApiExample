using Contract.Dtos;
using Repository.Movie;

namespace Domain.Services.Movie
{

    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
        }

        public async Task<MovieDto> Add(MovieDto movie)
        {
           return await _movieRepository.Add(movie).ConfigureAwait(false);
        }

        public async ValueTask<int> Delete(int id)
        {
            return  await _movieRepository.Delete(id).ConfigureAwait(false);
        }

        public async Task<MovieDto?> Get(int id)
        {
            return await _movieRepository.Get(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<MovieDto>> Gets()
        {
            return await _movieRepository.Gets().ConfigureAwait(false);
        }

        public async Task<MovieDto> Update(MovieDto movie)
        {
            return await _movieRepository.Update(movie).ConfigureAwait(false); 
        }
    }
}
