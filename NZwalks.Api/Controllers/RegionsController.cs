
using Microsoft.AspNetCore.Mvc;
using NZwalks.Api.Models.Domain;
using NZwalks.Api.Models.DTO;
using NZwalks.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using NZwalks.Api.Repositories;
using AutoMapper;


namespace NZwalks.Api.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IMapper mapper;

        // private readonly NZwalkDbContext dbContext;
        private readonly IRegionRepository regionRepository;

        public RegionsController(IRegionRepository regionRepository,IMapper mapper) //Constrctor Injection
        {
          this.mapper=mapper;
            this.regionRepository=regionRepository;
        }
        //Get the Regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get the model domain from database
            var Regions = await regionRepository.GetAllAsync();
            

            // map model domain to DTO

            //var RegionsDto = Regions.Select(x => MapRegionDto(x)).ToList();
            var RegionsDto=mapper.Map<List<RegionDto>>(Regions);


            return Ok(RegionsDto);
        }

        //get a single Region
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Region>> GetRegion([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var region = await regionRepository.GetRegionAsync(id);


                if (region != null)
                {
                    //map model to DTO
                    var regionDto = mapper.Map<RegionDto>(region);
                    return Ok(regionDto);
                }

            }
            return NotFound();
        }

        //create Regions
        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] AddRequestRegionDto addRequestRegionDto)
        {
            if(ModelState.IsValid){
            //map DTO to Model object 
           var region= mapper.Map<Region>(addRequestRegionDto);
            // var region = new Region
            // {
            //     // Id = Guid.NewGuid(), it auto generate even we didn't mention
            //     Name = addRequestRegionDto.Name,
            //     Code = addRequestRegionDto.Code,
            //     RegionImageUrl = addRequestRegionDto.RegionImageUrl
            // };

            //add Model object to Database
            await regionRepository.AddRegionAsync(region);

            //map Model to DTO
            var regionDto = mapper.Map<RegionDto>(region);



            return CreatedAtAction(nameof(GetRegion), new { id = regionDto.Id }, regionDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //update Region
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRequestRegionDto updateRequestRegionDto)
        {
           
            if(ModelState.IsValid){
            //map DTo to Model
            /* region.Name=updateRequestRegionDto.Name;
             region.Code=updateRequestRegionDto.Code;
             region.RegionImageUrl=updateRequestRegionDto.RegionImageUrl; */

             var updatedRegion=mapper.Map<Region>(updateRequestRegionDto);

            var region=await regionRepository.UpdateRegionAsync(id,updatedRegion);
            if (region == null)
            {
                return NotFound();
            }

            //map model to DTo
            var regionDto = mapper.Map<RegionDto>(region);


            return Ok(regionDto);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        //Delete Region
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var region = await regionRepository.RemoveRegionAsync(id);

            if (region == null)
            {
                return NotFound();
            }
          
            //map model to Dto
            var regionDto=mapper.Map<RegionDto>(region);

            return Ok(regionDto);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAllRegions()
        {
           await  regionRepository.RemoveAllAsync();
            return Ok();
        }
    }
}

