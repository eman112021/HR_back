using HR_2024.Core;
using HR_2024.Core.Model;
using HR_2024.Core.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HR_2024.Ef;
using Microsoft.IdentityModel.Tokens;

namespace HR_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Management_subController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Management_subController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }


        [HttpGet("get_all")]
        public async Task<IActionResult> get_all()
        {
           

            var result = await _unitOfWork.management_sub.GetAll();
                                                                  
            return Ok(result);
        }

        [HttpGet("get_sub")]
        public async Task<IActionResult> get_sub(string ii)
        {
            var a = Convert.ToInt32(ii);
         
           
            var test = await _unitOfWork.management_sub.search(x => x.generalManagementid == a, y => new Management_sub_dto { Id = y.Id, Management_sub_name = y.Management_sub_name });
                                                                     
            return Ok(test);// await _unitwork.edara_sub.find(x => x.Edaraid == a)); 
        }

        [HttpPost("add_Management_sub")]
        public async Task<ActionResult> add_Management_sub(Management_sub_dto management_sub_dto) 
        {
            if (string.IsNullOrEmpty(management_sub_dto.Management_sub_name) || (management_sub_dto.generalManagementid==0))
            {
                ModelState.AddModelError("error", "يجب ادخال اسم الادارة");

            }

            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }

            if (management_sub_dto == null) 
            { 
                return NotFound();
            }
            try
            {
                   

               var managementsub_dto = _mapper.Map<Management_Sub>(management_sub_dto);
               await _unitOfWork.management_sub.add(managementsub_dto);
               await _unitOfWork.complete();
               return Ok(managementsub_dto);
            }
            catch (Exception ex) {return NotFound(); };


        }

        [HttpPut("update_management_sub")]
        public async Task<ActionResult> update_management_sub(Management_sub_dto management_Sub_Dto)
        {
            if (string.IsNullOrEmpty(management_Sub_Dto.Management_sub_name) )
            {
               
                ModelState.AddModelError("error", "يجب ادخال اسم الادارة الفرعية");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);    
            }

            if (management_Sub_Dto == null) { return NotFound(); }
            try
            {
                var managementsub_dto = _mapper.Map<Management_Sub>(management_Sub_Dto);

                var management_sub_dto = await _unitOfWork.management_sub.find(x => x.Id == management_Sub_Dto.Id);
                if (management_sub_dto == null)
                {
                    return NotFound();
                }
                else
                {
                    await _unitOfWork.management_sub.update(managementsub_dto);
                    await _unitOfWork.complete();
                    return Ok(managementsub_dto);
                }
            }
            catch (Exception ex) { return NotFound(); };

        }

        [HttpDelete("delete_management_sub")]
        public async Task<ActionResult> delete_management_sub(Management_sub_dto management_Sub_Dto) 
        {
            if (management_Sub_Dto == null) 
            { 
                return NotFound(); 
            }
            try
            {
                var managementsub_dto = _mapper.Map<Management_Sub>(management_Sub_Dto);

                // var management_sub_dto = await _unitOfWork.management_sub.find(x => x.Id == management_Sub_Dto.Id);
                var management_sub_dto = await _unitOfWork.management_sub.findwithinclude(x=>x.Id==managementsub_dto.Id,y=>y.Departments,true);
                if (management_sub_dto == null)
                {
                    return NotFound();
                }
                else
                {
                    if (management_sub_dto.Departments.Count > 0) 
                
                        return Ok(1);
                 

                   bool result= await _unitOfWork.management_sub.delete(managementsub_dto);
                    if (result)
                    {
                        await _unitOfWork.complete();
                        return Ok(true);
                    }
                    else { return StatusCode(500); }
                }
            }
            catch (Exception ex) {return NotFound(); };

        }
    }
}
