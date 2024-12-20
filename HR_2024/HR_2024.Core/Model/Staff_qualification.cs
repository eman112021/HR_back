using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_2024.Core.Model
{
    public class Staff_qualification
    {
        public int ID { get; set; }
        public int qualification { get; set; }//moa

        public int specialization { get; set; }//note

        public int specialization_type { get; set; }//note1

        public int qualification_Type { get; set; }//flg

        public string qualification_source { get; set; }//smoa
        public DateTime qualification_date { get; set; }//dmoa

        public int Employee_Dataid { get; set; }
        public virtual Employee_Data? emp { get; set; }
    }
}
