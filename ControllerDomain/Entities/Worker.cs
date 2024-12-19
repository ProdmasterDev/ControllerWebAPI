using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerDomain.Entities
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        public bool Arch { get; set; } = false;
        public int DisanId {  get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string FatherName {  get; set; } = string.Empty;
        public string Position {  get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string ImagePath {  get; set; } = string.Empty;
        public int? GroupId {  get; set; }
        public int? AccessMethodId { get; set; }
        public DateTime? DateBlock { get; set; }
        public virtual IEnumerable<Card> Cards { get; set; } = new List<Card>();
        public virtual IEnumerable<Access> Accesses { get; set; } = new List<Access>();
        public virtual WorkerGroup? Group { get; set; }
        public virtual AccessMethod? AccessMethod { get; set; }
        public virtual IEnumerable<WorkerAccessGroup> WorkerAccessGroup { get; set; } = new List<WorkerAccessGroup>();
        public virtual IEnumerable<Event> Events { get; set; } = new List<Event>();
    }
}
