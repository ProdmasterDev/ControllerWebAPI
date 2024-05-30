﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerDomain.Entities
{
    public class EventType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual IEnumerable<Event> Events { get; set; } = new List<Event>();
    }
}