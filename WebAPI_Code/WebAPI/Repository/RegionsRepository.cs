using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Model.Domain;

namespace WebAPI.Repository
{
    public class RegionsRepository : IRegionsRepository
    {
        private readonly WalkDbContext walkDbContext;

        public RegionsRepository(WalkDbContext walkDbContext)
        {
            this.walkDbContext = walkDbContext;
        }
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await walkDbContext.Regions.ToListAsync();
        }

       
    }
}
