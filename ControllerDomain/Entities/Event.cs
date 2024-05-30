using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerDomain.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public int ControllerLocationId {  get; set; }
        public int EventTypeId { get; set; }
        public int? WorkerId { get; set; }
        public string Card {  get; set; } = string.Empty;
        public DateTime Create { get; set; }
        public int Flag {  get; set; }
        public virtual ControllerLocation? ControllerLocation {  get; set; } 
        public virtual EventType? EventType { get; set; }
        public virtual Worker? Worker { get; set; }
    }
}