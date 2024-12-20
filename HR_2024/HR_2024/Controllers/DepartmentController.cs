using AutoMapper;
using HR_2024.Core;
using HR_2024.Core.Model;
using HR_2024.Core.Model.Dto;
using HR_2024.Ef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HR_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly  IMapper _mapper;
        public DepartmentController(IUnitOfWork unitOfWork , IMapper mapper) 
        { 
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("get_all")]

        public async Task<IActionResult> get_all()
        {
            var result = await _unitOfWork.department.GetAll();
            return Ok(result);

        }

        [HttpGet("get_department")]
        public async Task<IActionResult> get_department(string id)
        {
            var id_sub=Convert.ToInt32(id);
          var result= await _unitOfWork.department.search(x=>x.management_subid==id_sub,y=> new Department_dto { Id = y.Id, department_Name =y.Department_Name});

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> add_department(Department_dto department_dto)
        {
            if (department_dto == null)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(department_dto.department_Name))
            {
                ModelState.AddModelError("error", "يجب ادخال اسم القسم");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var department = _mapper.Map<Department>(department_dto);
                await _unitOfWork.department.add(department);
                await _unitOfWork.complete();
                return Ok(department);
            }
            catch (Exception ex) { return NotFound(); }

        }

        [HttpPut]
        public async Task<IActionResult> update_department(Department_dto department_dto)
        {
            //if(string.IsNullOrEmpty(department_dto.department_Name))
            //{
            //    ModelState.AddModelError("erorr","");
            //}
            //if (!ModelState.IsValid)
            //{ 
            //    return BadRequest(ModelState);
            //}
            //try
            //{
            var deprat_dto=_mapper.Map<Department>(department_dto);
            var department = await _unitOfWork.department.find(x=>x.Id==deprat_dto.Id);
            if (department == null)
                return NotFound();
            else
            {

              var result=   await _unitOfWork.department.update(deprat_dto);
                            await _unitOfWork.complete();
                return Ok(result);
            }

            //}
            //catch (Exception ex) { return BadRequest(); }

        }

        [HttpDelete]
        public async Task<IActionResult> delete_department(Department_dto department_dto)
        {
            try
            {
                var depart_dto = _mapper.Map<Department>(department_dto);
                var department = await _unitOfWork.department.find(x => x.Id == department_dto.Id);
                if (department == null)
                {
                    return NotFound();
                }

                var result = await _unitOfWork.department.delete(department);
                if (result)
                {
                    await _unitOfWork.complete();

                    return Ok(result);
                }
                else
                {
                     return StatusCode(500); 
                }
            }
            catch (Exception ex) { return StatusCode(500); }

        }
    }
}
