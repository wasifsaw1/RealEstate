using BusinessLogic.Inteface;
using BusinessRepository.Interface;
using BusinessRepository.Repository;
using Model.Models;
using Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class PropertyBL : IPropertyBL
    {
        private readonly IPropertyBR _iPropertyBR;
        public PropertyBL(IPropertyBR iPropertyBR)
        {
            _iPropertyBR = iPropertyBR;
        }
        public async Task<List<string>> GetAllEstateNames()
        {
            return await _iPropertyBR.GetAllEstateNames();
        }

        public async Task<List<Property>> GetEstateDetailsByid(int id)
        {
            return await _iPropertyBR.GetEstateDetailsByid(id);
        }

        public async Task<string> AddEstate(PropertyRequest propertyRequest)
        {
            Property property = propertyRequest.ToEstate();
            return await _iPropertyBR.AddEstate(property);
        }

        public async Task<string> UpdateEstate(int id, PropertyRequest propertyRequest)
        {
            return await _iPropertyBR.UpdateEstate(id, propertyRequest);
        }

        public async Task<string> DeleteEstate(int id)
        {
            return await _iPropertyBR.DeleteEstate(id);
        }

    }
}
