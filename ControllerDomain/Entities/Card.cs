using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerDomain.Entities
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public bool Arch { get; set; } = false;
        public int? WorkerId { get; set; }
        public string CardNumb16 {  get; set; } = string.Empty;
        public string CardNumb { get; set; } = string.Empty;
        public virtual Worker? Worker { get; set; }
    }
}