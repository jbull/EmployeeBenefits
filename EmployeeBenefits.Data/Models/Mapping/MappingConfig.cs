using AutoMapper;
using EmployeeBenefits.Data.Models.Dto;

namespace EmployeeBenefits.Data.Models.Mapping
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<EmployeeDto, Employee>();
                config.CreateMap<Employee, EmployeeDto>();
                config.CreateMap<EmployeeAddDto, Employee>();

                config.CreateMap<DependentDto, Dependent>();
                config.CreateMap<Dependent, DependentDto>();
                config.CreateMap<DependentAddDto, Dependent>();
                config.CreateMap<Dependent, DependentAddDto>();
            });

            return mappingConfig;
        }
    }
}
