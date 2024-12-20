using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_2024.Core.Model.Dto
{
    public class GeneralManagement_dto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "nonononono")]
        public string management_name { get; set; }
        public byte flag { get; set; }
    }
}
