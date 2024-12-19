using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerDomain.Entities
{
    public class WorkerGroupAccess
    {
        [Key]
        public int Id { get; set; }
        public int WorkerGroupId { get; set; }
        public int AccessGroupId { get; set; }
        public bool isActive { get; set; }
        public virtual AccessGroup? AccessGroup { get; set; }
        //public virtual IEnumerable<AccessGroup> AccessGroup { get; set; } = new List<AccessGroup>();
        public virtual WorkerGroup? WorkerGroup { get; set; }
    }
}