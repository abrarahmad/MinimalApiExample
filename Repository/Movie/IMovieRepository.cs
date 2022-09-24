using Contract.Dtos;

namespace Repository.Movie
{
    public interface IMovieRepository
    {
        Task<MovieDto?> Get(int id);
        Task<IEnumerable<MovieDto>> Gets();
        Task<MovieDto> Add(MovieDto movie);
        Task<MovieDto> Update(MovieDto movie);
        ValueTask<int> Delete(int id);
    }
}
