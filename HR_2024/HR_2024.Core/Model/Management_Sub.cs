using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_2024.Core.Model
{
    public class Management_Sub
    {
       
            public int Id { get; set; }
        [Required]
            public string Management_sub_name { get; set; }
        //  public int perant { get; set; }
            public bool state { get; set; } = true;
            public GeneralManagement generalManagement { get; set; }
            public int generalManagementid { get; set; }
            public List<Department> Departments { get; set; } = new List<Department>();

        }
    }

