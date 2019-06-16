using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gorchun.Core.Models;
using Gorchun.UI.UIModels;


namespace Gorchun.Core
{
    public static class MyAutoMapper
    {
        private static readonly MapperConfiguration _config;
        public static readonly IMapper Mapper;

        static MyAutoMapper()
        {
            _config = new MapperConfiguration(cfg => cfg.CreateMap<Material, UiMaterial>());
            Mapper = _config.CreateMapper();
        }
    }
}
