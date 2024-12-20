using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_2024.Core.Model
{
    public class Management_Unit
    {
       
            public int Id { get; set; }
            [Required] 
  
            public string unit_name { get; set; }

            public bool state { get; set; } = true;
            public Department department { get; set; }
            public int departmentid { get; set; }
        

    }
}
