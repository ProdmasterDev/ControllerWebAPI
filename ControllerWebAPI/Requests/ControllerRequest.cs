namespace ControllerWebAPI.Requests
{
    public class ControllerRequest
    {
        public string Type { get; set; } = string.Empty;
        public int Sn { get; set; }
        public List<ControllerMessage> Messages { get; set; } = new List<ControllerMessage>();
    }
    public class ControllerMessage
    {
        public int Id { get; set; }
        public string? Operation { get; set; }
        public string? Fw { get; set; }
        public string? Conn_fw { get; set; }
        public int? Active { get; set; }
        public int? Mode { get; set; }
        public string? Controller_ip { get; set; }
        public string? Card { get; set; }
        public int? Reader { get; set; }
        public int? Granted { get; set; }
        public int? Success { get; set; }
        public List<ControllerEvent> Events { get; set; } = new List<ControllerEvent>();
        public string? Auth_hash { get; set; }
        public int? Last_event { get; set; }  // последнее событие
    }

    public class ControllerEvent
    {
        public int Event { get; set; }     // тип события
        public string? Card { get; set; }  // номер карты в шестнадцатеричном виде
        public string? Time { get; set; }  // время события
        public int Flag { get; set; }      // флаги события
    }
}
