using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string SurName { get; set; }
        public ICollection<TestDto> Tests { get; set; }
    }
}
