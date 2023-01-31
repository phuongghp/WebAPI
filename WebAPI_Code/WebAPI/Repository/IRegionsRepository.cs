using WebAPI.Model.Domain;

namespace WebAPI.Repository
{
    public interface IRegionsRepository
    {
      Task<  IEnumerable<Region>> GetAllAsync();
        Task<Region> GetAsync(Guid Id);
        Task<Region>  AddSync(Region region);
        Task<Region> DeleteAsync(Guid id);
        Task<Region> UpdateAsync(Guid id,Region region);
    }
}
