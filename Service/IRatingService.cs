using Entities;

namespace Repository
{
    public interface IRatingService
    {
        Task<Rating> addRating(Rating rating);
    }
}