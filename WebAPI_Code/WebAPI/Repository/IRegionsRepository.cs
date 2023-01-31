using WebAPI.Model.Domain;

namespace WebAPI.Repository
{
    public interface IRegionsRepository
    {
      Task<  IEnumerable<Region>> GetAllAsync();
    }
}
