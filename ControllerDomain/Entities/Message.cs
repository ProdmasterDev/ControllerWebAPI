using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerDomain.Entities
{
    public class Message
    {
        [Key]
        public long Id { get; set; }
        public int ControllerId {  get; set; }
        public int OperationId {  get; set; }
        public int Flag { get; set; } = 0;
        public int Tz { get; set; } = 255;
        public bool IsComplited { get; set; } = false;
        public DateTime Create {  get; set; }
        public virtual Controller? Controller { get; set; }
        public virtual MessageOperation? Operation { get; set; }
        public virtual IEnumerable<MessageCard> Cards { get; set; } = new List<MessageCard>();
    }
}
