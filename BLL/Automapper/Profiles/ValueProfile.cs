using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Models.Value;
using DAL.Entities;

namespace BLL.Automapper.Profiles
{
    public class ValueProfile : Profile
    {
        public ValueProfile()
        {
            CreateMap<ValueModel, Value>();
            CreateMap<Value, ValueModel>();
        }
    }
}
