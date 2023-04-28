using Model.Models;
using Model.Request;

namespace BusinessLogic.Inteface
{
    public interface IPropertyBL
    {
        Task<List<string>> GetAllEstateNames();
        Task<List<Property>> GetEstateDetailsByid(int id);
        Task<string> AddEstate(PropertyRequest propertyRequest);
        Task<string> UpdateEstate(int id,PropertyRequest propertyRequest);
        Task<string> DeleteEstate(int id);
    }
}
