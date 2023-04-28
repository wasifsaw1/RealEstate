using BusinessRepository.Interface;
using Microsoft.EntityFrameworkCore;
using Model.Constant;
using Model.DBContext;
using Model.Helper;
using Model.Models;
using Model.Request;

namespace BusinessRepository.Repository
{
    public class PropertyBR : IPropertyBR
    {
        private readonly CommonDbContext _dbContext;

        public PropertyBR(CommonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<string>> GetAllEstateNames()
        {
            List<string> property = await _dbContext.Property.Select(x=>x.Name).ToListAsync();
            return property;
        }

        public async Task<List<Property>> GetEstateDetailsByid(int Id)
        {
            List<Property> property = await _dbContext.Property.Where(x=>x.Id == Id).ToListAsync();
            return property;
        }

        public async Task<string> AddEstate(Property property)
        {
            await _dbContext.Property.AddAsync(property);
            await _dbContext.SaveChangesAsync();
            return $"{property.Name} created successfully";
        }

        public async Task<string> UpdateEstate(int id, PropertyRequest propertyRequest)
        {
            Property property = _dbContext.Property.Where(x => x.Id == id).FirstOrDefault();
            if (property != null)
            {
               property.Name= propertyRequest.Name;
               property.City= propertyRequest.City;
               property.Location= propertyRequest.Location;
               property.NoProjectsCompleted= propertyRequest.NoProjectsCompleted;
               property.UpdatedAt= propertyRequest.UpdatedAt;
                property.CreatedAt = property.CreatedAt;
                _dbContext.Property.Update(property);
            }
            else
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, String.Format(ExceptionConstants.NOT_FOUND, "Property", id));
            }
            await _dbContext.SaveChangesAsync();
            return $"{property.Name} Updated successfully";
        }

        public async Task<string> DeleteEstate(int id)
        {
            Property property = _dbContext.Property.Where(x => x.Id == id).FirstOrDefault();
            if (property == null)
            {
                return $"Property with {id} doesn't Exist";
            }
            _dbContext.Property.Remove(property);
            await _dbContext.SaveChangesAsync();
            return $"{property.Id} Deleted successfully";
        }
    }
}
