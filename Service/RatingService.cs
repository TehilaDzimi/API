using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RatingService: IRatingService
    {
        IRatingRepository RatingRepository;
        public RatingService(IRatingRepository _RatingRepository)
        {
            RatingRepository = _RatingRepository;
        }
        public async Task<Rating> addRating(Rating rating)
        {

            return await RatingRepository.addRating(rating);
        }
    }
}
