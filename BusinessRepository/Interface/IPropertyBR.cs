using Model.Models;
using Model.Request;

namespace BusinessRepository.Interface
{
    public interface IPropertyBR
    {
        Task<List<string>> GetAllEstateNames();
        Task<List<Property>> GetEstateDetailsByid(int id);
        Task<string> AddEstate(Property property);
        Task<string> UpdateEstate(int id, PropertyRequest propertyRequest);
        Task<string> DeleteEstate(int id);
    }
}
