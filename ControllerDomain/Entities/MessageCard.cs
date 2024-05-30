using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerDomain.Entities
{
    public class MessageCard
    {
        [Key]
        public long Id { get; set; }
        public long MessageId { get; set; }
        public int CardId { get; set; }
        public bool IsLoaded { get; set; } = false;
        public virtual Message? Message { get; set; }
        public virtual Card? Card { get; set; }
    }
}
