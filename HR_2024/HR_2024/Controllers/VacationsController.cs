using HR_2024.Core;
using HR_2024.Core.Model;
using HR_2024.Core.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public VacationsController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id_emp) 
        {
            var result = await _unitOfWork.vacation.search(x => x.id_emp == id_emp,y => new Vacation_dto 
            {
                vacation_count= y.vacation_count, vacation_start_date=y.vacation_start_date ,Id=y.Id,
                id_emp=y.id_emp
            });// { y.id_emp,y.vacation_count,y.type_vacation,y.vacation_end_date,y.vacation_start_date});

          return Ok(result);
        }
        [HttpPost("add_vacation")]
        public async Task<IActionResult> add_vacation(Vacation vacation)
        {
            await _unitOfWork.BeginTransctionAsync();
            try
            {

                if (vacation == null)
            {
                return BadRequest();

            }
            //else
            //{
                //try
                //{
                    await _unitOfWork.vacation.add(vacation);
                 //   var Results = await _unitOfWork.complete();
                 //   return Ok(Results);
                //  }
                //   catch (Exception ex) { return StatusCode(500); }
                // }

                //var employee = await _unitOfWork.employee.find(vacation.id_emp);
                //if (employee == null) 
                //{ 
                //}
                //  Employee.vacation_balance=Employee.vacation_balance-vacation.vacation_count;
                //await _unitOfWork.employee.update(employee);
                var Results = await _unitOfWork.complete();
               // await _unitOfWork.CommitAsync();
                return Ok(Results);
            }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackAsync();
                    return StatusCode(500);
                }
           // }
        }

        [HttpPut]
        public async Task<IActionResult> edit_vacation(Vacation vacation)
        {
           await _unitOfWork.BeginTransctionAsync();
            try
            {
                if (vacation == null)
                {
                    return NotFound();
                }
                var vaca = await _unitOfWork.vacation.find(x => x.Id == vacation.Id);
                if (vaca == null)
                {
                    return NotFound("غير موجود");
                }
                var vaction_count_old = vaca.vacation_count;
                await _unitOfWork.vacation.update(vacation);
                //***********
                //var employee = await _unitOfWork.employee.find(vacation.id_emp);
                //if (employee == null) 
                //{ }
                //employee.vacation_balance = employee.vacation_balance+vaction_count_old - vacation.vacation_count;
                //await _unitOfWork.employee.update(employee);
                //await _unitOfWork.CommitAsync();
                //***********

                var result = await _unitOfWork.complete();
                return Ok(result);
            }
            catch (Exception ex) 
            { 
                return StatusCode(500);
            }


        }
        [HttpDelete("delete_vacation")]
        public async Task<IActionResult> delete_vacation(Vacation vacation)
        {
           if(vacation == null)
            { 
                return BadRequest();
            }
           await _unitOfWork.BeginTransctionAsync();
            try
            {
                
                var vaca = await _unitOfWork.vacation.find(x => x.Id == vacation.Id);
                if(vaca == null)
                {
                    return NotFound("غير موجودة");
                }
                //var emp = await _unitOfWork.employee.find(x=>x.id==vaca.id_emp);
                //if (emp == null)
                //{
                //    return NotFound();
                //}
                //emp.vacation_balance = emp.vacation_balance + vaca.vacation_count;
                //await _unitOfWork.employee.update(emp);
                await _unitOfWork.vacation.delete(vaca);
                await _unitOfWork.CommitAsync();
                await _unitOfWork.complete();
                return Ok(true);  
            }
            catch (Exception ex)
            {
               await _unitOfWork.RollbackAsync();
                return StatusCode(500,ex.Message);
            }
           


        }
    }
}
