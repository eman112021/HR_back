﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_2024.Core.Model.Dto
{
    public class Vacation_dto
    {
            public int Id { get; set; }
            public DateTime vacation_start_date { get; set; }
            public DateTime vacation_end_date { get; set; }
            public int vacation_count { get; set; }
          //  public string national_num { get; set; }
            public int id_emp { get; set; }
            public int type_vacation { get; set; }
            public int flag { get; set; }
           // public DateTime date_insert { get; set; }
           // public DateTime date_update { get; set; }

        

    }
}
