using Contract.Dtos;
using Domain.Services.Movie;

namespace MinimalApi.APIs
{
    public static class MovieApi
    {
        public static void RegisterMovieApi(this WebApplication app)
        {
            app.MapGet("/movie/get", async (IMovieService movieService, int id) =>
            {
                var response = await movieService.Get(id).ConfigureAwait(false);
                return response;

            }).WithName("GetMovie").WithTags("Movie")
             .Produces(400).Produces(200)
             .Produces(404).Produces(500);

            app.MapGet("/movie/gets", async (IMovieService movieService) =>
            {
                var response = await movieService.Gets().ConfigureAwait(false);
                return response;

            }).WithName("GetMovies").WithTags("Movie")
             .Produces(400).Produces(200)
             .Produces(404).Produces(500);

            app.MapPost("/movie/add", async (IMovieService movieService, MovieDto movieDto) =>
            {
                var response = await movieService.Add(movieDto).ConfigureAwait(false);
                return response;

            }).WithName("AddMovie").WithTags("Movie")
             .Produces(400).Produces(200)
             .Produces(404).Produces(500);

            app.MapPut("/movie/update", async (IMovieService movieService, MovieDto movieDto) =>
            {
                var response = await movieService.Update(movieDto).ConfigureAwait(false);
                return response;

            }).WithName("UpdateMovie").WithTags("Movie")
             .Produces(400).Produces(200)
             .Produces(404).Produces(500);

            app.MapDelete("/movie/delete", async (IMovieService movieService, int id) =>
            {
                var response = await movieService.Delete(id).ConfigureAwait(false);
                return response;

            }).WithName("DeleteMovie").WithTags("Movie")
             .Produces(400).Produces(200)
             .Produces(404).Produces(500);
        }
    }
}
