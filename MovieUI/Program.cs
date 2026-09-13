using MovieInfrastructure.Data;

namespace MovieUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new MovieDbContext();
            context.Database.EnsureCreated();
        }
    }
}
