using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerDomain.Entities
{
    public class QuickAccess
    {
        [Key]
        public long Id { get; set; }
        public string Sn { get; set; } = string.Empty;
        public int Reader { get; set; }
        public string Card { get; set; } = string.Empty;
        public int Granted { get; set; } = 0;
        public DateTime? DateBlock {  get; set; }
    }
}
