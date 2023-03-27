using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAcessLayer.Entity
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public virtual ICollection<Test> Tests { get; set; } = new HashSet<Test>();
    }
}
