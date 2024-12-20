using HR_2024.Core;
using HR_2024.Core.Model;
using HR_2024.Ef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private readonly  IUnitOfWork _unitOfWork;
        public EvaluationController(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }
        [HttpGet("get_evaluation")]
        public async Task<IActionResult> get_evaluation(int id_emp)
        {
           var eval= await _unitOfWork.evaluation.search(x=>x.id_emp==id_emp,x=>x );
            return Ok(eval);
        }
       
        [HttpPost("add_evaluation")]
        public async Task<IActionResult> add_evaluation(Evaluation eval)
        {
            try
            {
                if (eval == null) 
                { 
                    return BadRequest(); 
                }

                if (!ModelState.IsValid)
                {
                    // في حالة وجود أخطاء في الـ ModelState، ارجع الأخطاء كـ Response
                    return BadRequest(ModelState);
                }
                await _unitOfWork.evaluation.add(eval);
                var result=  await _unitOfWork.complete();
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(); }

        }
        [HttpPut("edit_evaluation")]
        public async Task<IActionResult> edit_evaluation(Evaluation evaluation)
        {
            try
            {
                if (evaluation == null)
                {
                    return BadRequest(false);
                }
                var eval = await _unitOfWork.evaluation.find(x=>x.Id==evaluation.Id);
                if (eval == null)
                {
                    return NotFound("غير موجودة");
                }
                var result = await _unitOfWork.evaluation.update(evaluation);
                await _unitOfWork.complete();
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        public async Task<IActionResult> delete_evaluation(Evaluation evaluation)
        {
            if(evaluation == null)
            { 
                return BadRequest();
            }
            try
            {
                var eval = await _unitOfWork.evaluation.find(x => x.Id == evaluation.Id);
                if (eval == null)
                {
                    return NotFound("غير موجود");
                }
               bool result= await _unitOfWork.evaluation.delete(evaluation);
                if (result)
                {
                    await _unitOfWork.complete();
                    return Ok(true);
                }
                else
                    return BadRequest(false);
            }
            catch (Exception ex) { return BadRequest(false);
            }


        }
    }
}
