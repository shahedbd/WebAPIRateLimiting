using Core.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.GenericCRUD.Data;

namespace WebAPI.GenericCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private IRepository<Branch> _branchRepository;

        public BranchController(IRepository<Branch> branchRepository)
        {
            _branchRepository = branchRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Branch>>> GetAll()
        {
            return Ok(await _branchRepository.GetAllAsync());
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Branch>> GetById(Int64 id)
        {
            return Ok(await _branchRepository.GetByIdAsync(id));
        }
        [HttpGet]
        [Route("GetByName/{branchName}")]
        public async Task<ActionResult<Branch>> GetByName(string branchName)
        {
            return Ok(await _branchRepository.FindByConditionAsync(x => x.Name == branchName));
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] Branch branch)
        {
            _branchRepository.Add(branch);
            return Ok(await _branchRepository.SaveChangesAsync());
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Branch branch)
        {
            _branchRepository.Update(branch);
            return Ok(await _branchRepository.SaveChangesAsync());
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Int64 id)
        {
            await _branchRepository.Delete(id);
            return Ok(await _branchRepository.SaveChangesAsync());
        }
    }
}
