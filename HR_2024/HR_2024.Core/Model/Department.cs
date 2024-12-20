using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_2024.Core.Model
{
    public class Department
    {

       
            public int Id { get; set; }
        
            [Required]
            public string Department_Name { get; set; }

        //  public int parent { get; set; }
        public bool state { get; set; } = true;
            public int management_subid { get; set; }
            public Management_Sub management_sub { get; set; }
            public List<Management_Unit> management_Unit { get; set; }

       
    }
}
