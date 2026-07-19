
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZwalks.Api.CustomActionFilters;
using NZwalks.Api.Models.Domain;
using NZwalks.Api.Models.DTO;
using NZwalks.Api.Repositories;

namespace NZwalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository repository;

        public WalksController(IMapper mapper,IWalkRepository walkRepository)
        {
            this.mapper=mapper;
            this.repository=walkRepository;
        }
        
        [HttpPost]
         [ActionModel]
        public async Task<IActionResult> CreateWalk([FromBody] AddRequestWalkDto addRequestWalkDto)
        {
            //Map DTO to model
           Walk walk= mapper.Map<Walk>(addRequestWalkDto);
           //call Repo
           if(walk==null) return NotFound();
          await  repository.CreateAsync(walk);
          //Map model to DTO
            var walkdto=(mapper.Map<WalkDto>(walk));
            return CreatedAtAction(nameof(GetWalk),new {id=walkdto.Id},walkdto);
        }

        
        //Get all walks
        [HttpGet]
        //Filtering
        //api/Walks?filterOn=Name&FilterQuery=londo&sortBy=Name&isascending=falser&pageNumber=&pageSize=5
        public async Task<ActionResult<List<WalkDto>>> GetAllWalks([FromQuery] string? filterOn,string? filterQuery,string? sortBy,bool? isAscending,int pageNumber,int pageSize)
        {
          var walk= await  repository.GetAllWalksAsync(filterOn,filterQuery,sortBy,isAscending ?? true,pageNumber,pageSize);
          //map model to DTO
        
          return Ok(mapper.Map<List<WalkDto>>(walk));
        }

        //GetWalk
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult<WalkDto>> GetWalk(Guid id){
            if(id==null)return NotFound();

            var walk=await repository.GetWalkAsync(id);
            if(walk==null) return NotFound();
            // map model to DTO



            return Ok(mapper.Map<WalkDto>(walk));
        }

        //Update method
        [HttpPut]
        [Route("{id:guid}")]
        [ActionModel]
        public async Task<ActionResult<WalkDto>> UpdateWalk(Guid id,[FromBody] UpdateRequestWalkDto updateRequestWalkDto)
        {

            //map dto to model
            var walk=mapper.Map<Walk>(updateRequestWalkDto);
            var updatedwalk=await repository.UpdateWalkAsync(id,walk);
            if(updatedwalk==null)return null;
            //map model to dto

            return Ok(mapper.Map<WalkDto>(updatedwalk));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var walk=await repository.DeleteWalkAsync(id);
            if(walk==null)return NotFound();

            return Ok();
        }


    }

    
}