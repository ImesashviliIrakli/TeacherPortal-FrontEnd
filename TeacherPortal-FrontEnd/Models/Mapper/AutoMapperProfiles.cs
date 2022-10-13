using AutoMapper;
using TeacherPortal_FrontEnd.Models.TeacherModels;

namespace TeacherPortal_FrontEnd.Models.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddTeacher, Teacher>();
        }
    }
}
