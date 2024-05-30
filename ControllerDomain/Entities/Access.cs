using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerDomain.Entities
{
    public class Access
    {
        [Key]
        public long Id { get; set; }
        public int ControllerLocationId { get; set; }
        public int WorkerId { get; set; }
        public DateTime? DateBlock { get; set; }
        public bool Enterance { get; set; }
        public bool Exit { get; set; }
        public virtual ControllerLocation? ControllerLocation { get; set; }
        public virtual Worker? Worker { get; set; }
    }
}