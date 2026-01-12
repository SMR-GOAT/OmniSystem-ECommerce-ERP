using AutoMapper;
using OmniSystem.Models;
using OmniSystem.ViewModels;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // --- 1. خريطة عرض الموظفين (من الداتابيز للجدول) ---
        CreateMap<ApplicationUserModel, EmployeeListViewModel>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position != null ? src.Position.Name : "N/A"))
            .ForMember(dest => dest.Initials, opt => opt.MapFrom(src => 
                ((src.FirstName ?? " ").Substring(0, 1) + (src.LastName ?? " ").Substring(0, 1)).ToUpper()));

        // --- 2. خريطة إنشاء موظف (من الفورم للداتابيز) ---
        CreateMap<CreateEmployeeViewModel, ApplicationUserModel>()
            .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.SelectedPositionId))
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

        // --- 3. خرائط المستخدمين الأخرى (User) ---
        CreateMap<ApplicationUserModel, UserListViewModel>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));

        CreateMap<CreateUserViewModel, ApplicationUserModel>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

        CreateMap<EditUserViewModel, ApplicationUserModel>().ReverseMap();
    }
}