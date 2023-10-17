using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;


namespace RazorPagesMovie.Models;

public static class SeedData
{

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesMovieContext(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMovieContext>>()
        ))
        {
            if (context == null || context.Movie == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.

            if (context.Movie.Any())
            {
                /*
                 * If there are any movies in the database, 
                 * the seed initializer returns and no movies are added. 
                 */

                return; // DB has been seeded
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M, // M Convention c# decimal for money can be upper or lowercase doesn't matter
                    Rating = "18"
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating = "16"
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M,
                    Rating = "16"
                },
                new Movie
                {
                    Title = " Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rating = "12"
                },
                new Movie
                {
                    Title = "Kimetsu no Yaiba Film",
                    ReleaseDate = DateTime.Parse("2021-5-02"),
                    Genre = "Anime_Japanese",
                    Price = 6.99M,
                    Rating = "12"
                },
                new Movie
                {
                    Title = "Gake uke no Ponyo",
                    ReleaseDate = DateTime.Parse("1979-8-25"),
                    Genre = "Anime_Japanese",
                    Price = 1.99M,
                    Rating = "6"
                }

            );
            context.SaveChanges();

        }
    }

}