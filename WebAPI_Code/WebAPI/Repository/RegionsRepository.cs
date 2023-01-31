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

        public async Task<Region> AddSync(Region region)
        {
            region.Id = Guid.NewGuid();
           await walkDbContext.AddAsync(region);
            await walkDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
           var region = await walkDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if(region==null)
            {
                return null;
            }
            walkDbContext.Regions.Remove(region);
           await walkDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await walkDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid Id)
        {
            return await walkDbContext.Regions.FirstOrDefaultAsync(x=>x.Id== Id);
             

        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingregion = await walkDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingregion == null)
            {
                return null;
            }
            existingregion.Code = region.Code;
            existingregion.Name = region.Name;
            existingregion.Area= region.Area;
            existingregion.Lat = region.Lat;
            existingregion.Long= region.Long;
            existingregion.Population= region.Population;
            await walkDbContext.SaveChangesAsync();
            return existingregion;
        }
    }
}
