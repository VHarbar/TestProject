using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Entity
{
    public class Test : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatedForUserId { get; set; }
        public virtual User CreatedForUser { get; set; }
        public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();
    }
}
