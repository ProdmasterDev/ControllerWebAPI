using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerDomain.Entities
{
    public class ControllerLocation
    {
        [Key]
        public int Id { get; set; }
        public bool Arch { get; set; } = false;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual IEnumerable<Access> Accesses { get; set;} = new List<Access>();
        public virtual IEnumerable<GroupAccess> GroupAccesses { get; set; } = new List<GroupAccess>();
        public virtual IEnumerable<AccessGroupAccess> AccessGroupAccesses { get; set; } = new List<AccessGroupAccess>();
        public virtual IEnumerable<Event> Events { get; set; } = new List<Event>();
        public virtual Controller? Controller { get; set; }
    }
}