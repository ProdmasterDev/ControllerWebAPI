using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerDomain.Entities
{
    public class Controller
    {
        [Key]
        public int Id { get; set; }
        public bool Arch { get; set; } = false;
        public string Sn {  get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // тип контроллера.
        public string FwVer { get; set; } = string.Empty; // версия прошивки контроллера
        public string ComFwVer { get; set; } = string.Empty; // версия прошивки модуля связи
        public string IpAddress { get; set; } = string.Empty; // ip адрес контроллера в локальной сети
        public DateTime LastPing { get; set; } // время последнего принятого ping запроса
        public DateTime LastPowerOn { get; set; } // время последнего принятого включения
        public int? ControllerLocationId { get; set; }
        public virtual IEnumerable<Event> Events { get; set; } = new List<Event>();
        public ControllerLocation? ControllerLocation { get; set; }
    }
}