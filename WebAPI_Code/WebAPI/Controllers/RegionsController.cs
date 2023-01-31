using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model.Domain;
using WebAPI.Model.DTO;
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
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region=await regionsRepository.GetAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO= mapper.Map<Model.DTO.Region>(region);
            return Ok(regionDTO);
        }
        [HttpPost]
        public async Task<IActionResult> ActionRegionAsync(Model.DTO.RegionRequest regionRequest)
        {
            var region = new Model.Domain.Region()
            {
                Code = regionRequest.Code,
                Area = regionRequest.Area,
                Lat = regionRequest.Lat,
                Long = regionRequest.Long,
                Name = regionRequest.Name,
                Population = regionRequest.Population
            };
            region= await regionsRepository.AddSync(region);
            var regionDTO = new Model.DTO.Region
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };
            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO.Id }, regionDTO);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            //get region from datatbase
            var region = await regionsRepository.DeleteAsync(id);
            //if null notfound
            if (region == null)
            {
                return NotFound();
            }

            //conver response back to DTO

            var regionDTO = new Model.DTO.Region()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population,

            };
            //return ok
            return Ok(regionDTO);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute]Guid id,[FromBody] Model.DTO.UpdateRegionRequest regionRequest)
        {
            var region = new Model.Domain.Region()
            {
              
                Code = regionRequest.Code,
                Name = regionRequest.Name,
                Area = regionRequest.Area,
                Lat = regionRequest.Lat,
                Long = regionRequest.Long,
                Population = regionRequest.Population,

            };
            region= await regionsRepository.UpdateAsync(id,region);
            //if null notfound
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = new Model.DTO.Region()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population,

            };
            //return ok
            return Ok(regionDTO);

        }
    }
}
