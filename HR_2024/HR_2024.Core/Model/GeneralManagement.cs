using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_2024.Core.Model
{
    public class GeneralManagement
    {

        
      public int Id { get; set; }
      [Required(ErrorMessage ="nonononono")]
      public string management_name { get; set; }
      public bool state { get; set; } = true;
     [Required]
      public byte flag { get; set; }
      public List<Management_Sub>? management_sub { get; set; } = new List<Management_Sub>();
            // public int Empid { get; set; }
        }
    }

