using AutoMapper;
using BLL.Models.Result;
using DAL.Entities;

namespace BLL.Automapper.Profiles
{
    public class ResultProfile : Profile
    {
        public ResultProfile()
        {
            CreateMap<ResultModel, Result>();
            CreateMap<Result, ResultModel>();
        }
    }
}
