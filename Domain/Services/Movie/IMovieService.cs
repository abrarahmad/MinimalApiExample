using Contract.Dtos;
namespace Domain.Services.Movie
{
    public interface IMovieService
    {
        Task<MovieDto?> Get(int id);
        Task<IEnumerable<MovieDto>> Gets();
        Task<MovieDto> Add(MovieDto movie);
        Task<MovieDto> Update(MovieDto movie);
        ValueTask<int> Delete(int id);

    }
}
