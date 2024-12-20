using HR_2024.Core;
using HR_2024.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public HelpController(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> get(int id)
        {
         // return Ok( await _unitOfWork.help.find(x=>x.Type1==id));
            return Ok(await _unitOfWork.help.search(x => x.Type1 == id,x=>new { x.Name ,x.Type1,x.Id}));

        }
        [HttpPost("add_help")]
        public async Task<IActionResult> add_help(Tb_Help help)
        {
            if (help == null) 
            {
                return BadRequest();
            
            }
            if (string.IsNullOrEmpty(help.Name))
            {
                ModelState.AddModelError("error","يرجى ادخال البيان");
            }
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);

            }
            await  _unitOfWork.help.add(help);
            var result=await _unitOfWork.complete();
            return Ok(result);
        }

        //public async Task<Tb_Help> find_help(Tb_Help help)
        //{
        //    var result = await _unitOfWork.help.find(x => x.Id == help.Id);
        //    return result;

        //}

        [HttpPut("update_help")]
        public async Task<IActionResult> update_help(Tb_Help help)
        {
            if (string.IsNullOrEmpty(help.Name)) 
            {
                ModelState.AddModelError("error", "يجب ادخال اسم البيان");
            
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var help1 = await _unitOfWork.help.find(x => x.Id == help.Id); ;// await find_help(help);
            if (help1 == null)
            { 
                return NotFound("غير موجودة");
            }
            await _unitOfWork.help.update(help);
            var result =await _unitOfWork.complete();
            return Ok(result);



        }

        [HttpDelete("delete_help")]
        public async Task<IActionResult> delete_help(Tb_Help help)
        {
            
            var help1 = await _unitOfWork.help.find(x => x.Id == help.Id); // await find_help(help);
            if (help1 == null)
            {
                return NotFound("غير موجودة");
            }
            await _unitOfWork.help.delete(help);
            var result = await _unitOfWork.complete();
            return Ok();

        }
    }
}
