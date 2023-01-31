using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model.Domain;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionsRepository regionsRepository;
        private readonly IMapper mapper;
        public RegionsController(IRegionsRepository regionsRepository, IMapper  mapper)
        {
            this.regionsRepository=regionsRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task< IActionResult> GetAllRegions()
        {
         var regions=await regionsRepository.GetAllAsync();
            //return DTO
            /* var regionsDTO = new List<Model.DTO.Region>();
             regions.ToList().ForEach(regions =>
             {
                 var regionDTO = new Model.DTO.Region()
                 {
                     Id = regions.Id,
                     Code = regions.Code,
                     Name = regions.Name,
                     Area = regions.Area,
                     Lat = regions.Lat,
                     Long = regions.Long,
                     Population = regions.Population,

                 };
                 regionsDTO.Add(regionDTO);
             });*/
          var regionsDTO= mapper.Map<List<Model.DTO.Region>>(regions);
            return Ok(regionsDTO);
        }
    }
}
