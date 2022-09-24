using Contract.Dtos;
using Microsoft.EntityFrameworkCore;
using Repository.Data;

namespace Repository.Movie
{
    public class MovieRepository : IMovieRepository
    {
        private readonly StorageContext _dbContext;
        public MovieRepository(StorageContext dbContext)
        {
            _dbContext = dbContext?? throw new ArgumentNullException(nameof(dbContext));
            if (!_dbContext.Movies.Any())
            {
                _dbContext.Movies.AddRange(FakeMovie.GenerateMovies());
                _dbContext.SaveChanges();
            }
        }
        public async Task<MovieDto> Add(MovieDto movie)
        {
           var addItem = _dbContext.Add(movie);
            addItem.State = EntityState.Added;
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return addItem.Entity;
        }

        public async ValueTask<int> Delete(int id)
        {

            var item = await _dbContext.Movies.FindAsync(id).ConfigureAwait(false);
            if (item is null)
                throw new Exception($"Not found id={id}");

            _dbContext.Remove(item);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return id;
        }

        public async Task<MovieDto?> Get(int id)
        {
            var item = await _dbContext.Movies.FindAsync(id).ConfigureAwait(false);
            if (item is null)
                throw new Exception($"Not found id={id}");
            return item;
        }

        public async Task<IEnumerable<MovieDto>> Gets()
        {
            return await _dbContext.Movies.ToListAsync().ConfigureAwait(false);
        }

        public async Task<MovieDto> Update(MovieDto movie)
        {
            var addItem = _dbContext.Movies.Add(movie);
            addItem.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return addItem.Entity;
        }
    }
}
