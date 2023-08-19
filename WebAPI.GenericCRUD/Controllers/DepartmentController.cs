using Core.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.GenericCRUD.Data;

namespace WebAPI.GenericCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IRepository<Department> _departmentRepository;

        public DepartmentController(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Department>>> GetAll()
        {
            return Ok(await _departmentRepository.GetAllAsync());
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Department>> GetById(Int64 id)
        {
            return Ok(await _departmentRepository.GetByIdAsync(id));
        }
        [HttpGet]
        [Route("GetByName/{DepartmentName}")]
        public async Task<ActionResult<Department>> GetByName(string DepartmentName)
        {
            return Ok(await _departmentRepository.FindByConditionAsync(x => x.Name == DepartmentName));
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] Department Department)
        {
            _departmentRepository.Add(Department);
            return Ok(await _departmentRepository.SaveChangesAsync());
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Department Department)
        {
            _departmentRepository.Update(Department);
            return Ok(await _departmentRepository.SaveChangesAsync());
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Int64 id)
        {
            await _departmentRepository.Delete(id);
            return Ok(await _departmentRepository.SaveChangesAsync());
        }
    }
}
