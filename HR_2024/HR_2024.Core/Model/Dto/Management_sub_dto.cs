using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_2024.Core.Model.Dto
{
    public class Management_sub_dto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="يجب ادخال اسم الادارة الفرعية ")]
        public string Management_sub_name { get; set; }
        [Required]
        public int generalManagementid { get; set; }
    }
}
