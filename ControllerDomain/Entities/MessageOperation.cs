using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerDomain.Entities
{
    public class MessageOperation
    {
        [Key]
        public int Id { get; set; }
        public string OperationCode { get; set; } = string.Empty;
        public string Name {  get; set; } = string.Empty;
    }
}
