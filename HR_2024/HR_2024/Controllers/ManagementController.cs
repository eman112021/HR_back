using HR_2024.Core;
using HR_2024.Core.Model;
using HR_2024.Core.Model.Dto;
using HR_2024.Ef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace HR_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork1;
        private readonly IMapper _mapper;
        public ManagementController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork1 = unitOfWork;

           _mapper = mapper;

        }


   
    [HttpGet("getall")]

    public async Task<ActionResult<List<GeneralManagement>>> getall()
    {
           

         var managements = await _unitOfWork1.generalManagement.GetAll();
        return Ok(managements);// await _unitOfWork1.edara.GetAll());

    }

    [HttpPost("add_Management")]
 //  public async Task<ActionResult> add_Management(GeneralManagement management)
    public async Task<ActionResult> add_Management(GeneralManagement_dto management_dto)
        {


            if (string.IsNullOrWhiteSpace(management_dto.management_name))
            {
                ModelState.AddModelError("error", "يجب ادخال اسم الادارة");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                // if (management == null)
                if (management_dto == null)
                {
                    return NotFound();
                }
                try
                {

                    var generalmanagement_dto = _mapper.Map<GeneralManagement>(management_dto);
                    // var result = _unitOfWork1.generalManagement.add(management);
                    var result = _unitOfWork1.generalManagement.add(generalmanagement_dto);
                    await _unitOfWork1.complete();
                    return Ok(result);
                }
                catch (Exception ex) { return StatusCode(500, ex.Message); }
            }
            

    

    [HttpDelete("delete_management")]
   public async Task<ActionResult> delete_management(GeneralManagement_dto management_dto)
    //public async Task<ActionResult> delete_management(GeneralManagement management_dto)
   {

            if (management_dto == null)
            {
             return NotFound();
            }
            try
            {
                var managemenrdto = _mapper.Map<GeneralManagement>(management_dto);
                // var data = await _unitOfWork1.generalManagement.find(x=>x.Id==management_dto.Id);

               // var data = await _unitOfWork1.generalManagement.findwithinclude(x => x.Id == management_dto.Id, y => y.management_sub);
                var data = await _unitOfWork1.generalManagement.findwithinclude(x => x.Id == managemenrdto.Id, y => y.management_sub,true);
            
                if (data == null)
                {
                    return NotFound("غير موجودة");
                }
                if (!ModelState.IsValid) 
                {
                    BadRequest(ModelState);                
                }
                // else
                // {

                // إلغاء تتبع الكائن القديم
              //  _unitOfWork1.Entry(data).State = EntityState.Detached;

                if (data.management_sub.Count > 0)
                        return Ok(1);

                    bool result = await _unitOfWork1.generalManagement.delete(managemenrdto);
                    if (result)
                    {
                        await _unitOfWork1.complete();
                        return Ok(true);
                    }
                    else { return StatusCode(500); }
               // }
        }
        catch (Exception ex) { return StatusCode(500,ex.Message); }

          
        }

        //[HttpPut("update_management")]
        [HttpPut]
        public async Task<ActionResult> update_management(GeneralManagement_dto management_dto)
        {
            var managementdto=_mapper.Map<GeneralManagement>(management_dto);
            // var generalmanagement_dto = await _unitOfWork1.generalManagement.Get(managementdto.Id);
            var generalmanagement_dto = await _unitOfWork1.generalManagement.find(x=>x.Id==managementdto.Id);

            if (generalmanagement_dto == null)
            {
                return NotFound("غير موجود");
            }
            else
            {
                try
                {
                    var result = await _unitOfWork1.generalManagement.update(managementdto);
                    await _unitOfWork1.complete();
                    return Ok(result);
                }
                catch { return BadRequest(); }
            }

        }

      

}
}
