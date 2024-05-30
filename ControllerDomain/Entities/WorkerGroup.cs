using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerDomain.Entities
{
    public class WorkerGroup
    {
        [Key]
        public int Id { get; set; }
        public bool Arch { get; set; } = false;
        public string Name { get; set; } = string.Empty;
        public virtual IEnumerable<GroupAccess> GroupAccess { get; set; } = new List<GroupAccess>();
        public virtual IEnumerable<Worker> Workers { get; set; } = new List<Worker>();
    }
}