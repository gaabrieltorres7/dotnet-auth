using AutoMapper;
using dotnet_auth.Data.Dtos;
using dotnet_auth.Models;

namespace dotnet_auth.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
    }

}