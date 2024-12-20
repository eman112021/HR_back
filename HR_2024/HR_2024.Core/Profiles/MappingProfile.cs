using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR_2024.Core.Model;
using HR_2024.Core.Model.Dto;

namespace HR_2024.Core.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<GeneralManagement_dto, GeneralManagement>();
            CreateMap<Management_sub_dto, Management_Sub>();

            CreateMap<Department_dto, Department>();
        }
    }
}
