using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_2024.Core.Model
{
    public class Evaluation
    {
        public int Id { get; set; }
        public byte eval { get; set; }
      // [Range(1960, 2030)]
        public int year { get; set; }
        public int id_emp { get; set; }
        public byte degree { get; set; }
    }
}
