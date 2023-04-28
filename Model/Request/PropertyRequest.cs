using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Request
{
    public class PropertyRequest
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public int NoProjectsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Property ToEstate()
        {
            Property property = new Property()
            {
                Name = Name,
                Location = Location,
                City = City,
                NoProjectsCompleted = NoProjectsCompleted,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            return property;
        }
    }
}
