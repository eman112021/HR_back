using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_2024.Core.Model
{
    public class Bank
    {
        public int Id { get; set; }
        public string bank_name { get; set; }
        public List<Bank_branche> bank_Branche { get; set; }
    }
}
