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

                config.CreateMap<DependentDto, Dependent>();
                config.CreateMap<Dependent, DependentDto>();
            });

            return mappingConfig;
        }
    }
}
