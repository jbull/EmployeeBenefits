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
            });

            return mappingConfig;
        }
    }
}
