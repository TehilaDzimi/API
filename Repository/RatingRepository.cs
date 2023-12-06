using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RatingRepository: IRatingRepository
        
    {
        private readonly MyShop910Context DB_contect;
        public RatingRepository(MyShop910Context DBcontect)
        {
            DB_contect = DBcontect;
        }

        public async Task<Rating> addRating(Rating rating)
        {
            
            await DB_contect.Ratings.AddAsync(rating);
            await DB_contect.SaveChangesAsync();
            return rating;

        }

    }
}
