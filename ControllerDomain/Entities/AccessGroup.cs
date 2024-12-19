using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerDomain.Entities
{
    public class AccessGroup
    {
        [Key]
        public int Id { get; set; }
        public bool Arch { get; set; } = false;
        public string Name { get; set; } = string.Empty;
        public virtual IEnumerable<AccessGroupAccess> Accesses { get; set; } = new List<AccessGroupAccess>();
        public virtual IEnumerable<WorkerAccessGroup> WorkerAccessGroups { get; set; } = new List<WorkerAccessGroup>();
        public virtual IEnumerable<WorkerGroupAccess> WorkerGroupAccess { get; set; } = new List<WorkerGroupAccess>();
    }
}
