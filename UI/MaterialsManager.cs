using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Gorchun.UI.UIModels;
using Gorchun.Core.Models;
using Gorchun.DataBase;
using AutoMapper;
using Gorchun.Core;

namespace Gorchun.UI
{
    public class MaterialsManager
    {
        private readonly MaterialsProvider _provider;
        private static readonly IMapper _mapper = MyAutoMapper.Mapper;

        public MaterialsManager()
        {
            _provider = new MaterialsProvider();
        }

        public UiMaterial GetById(string cas)
        {
            CheckStringForNull(cas, nameof(cas));
            return _mapper.Map<UiMaterial>(_provider.GetById(cas));
        }


        public List<UiMaterial> GetAll()
        {
            return _mapper.Map<List<UiMaterial>>(_provider.GetAll());
        }


        public void AddNew(UiMaterial newItem)
        {
            CheckObjectForNull(newItem, nameof(newItem));
            CheckStringForNull(newItem.Cas, nameof(newItem.Cas));
            _provider.AddNew(_mapper.Map<Material>(newItem));
        }


        public void DeleteById(string cas)
        {
            CheckStringForNull(cas, nameof(cas));
        }

        private void CheckStringForNull(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException($"Can't be null or empty: {parameterName}");
            }
        }

        private void CheckObjectForNull(object value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"Can't be null or empty: {parameterName}");
            }
        }
    }
}
